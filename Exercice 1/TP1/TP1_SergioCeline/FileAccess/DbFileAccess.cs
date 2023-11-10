using MySqlConnector;
using TP1_SergioCeline.Business;
using TP1_SergioCeline.DefineName;
using TP1_SergioCeline.Tools;

namespace TP1_SergioCeline.FileAccess
{
    public class DbFileAccess : IFileAccess
    {
        private INameDefiner _nameDefiner;
        private IConvertImage _convertImage;
        private string _connString;
        public DbFileAccess(INameDefiner nameDefiner, IConvertImage convertImage)
        {
            _nameDefiner = nameDefiner;
            _convertImage = convertImage;
            _connString = System.Configuration.ConfigurationManager.ConnectionStrings
                  ["ConnectionString"].ConnectionString;
        }
        public List<string> GetListName()
        {
            List<string> names = new List<string>();

            using (MySqlConnection conn = new MySqlConnection(_connString))
            {
                using (MySqlCommand selcmd = new MySqlCommand("SELECT name FROM Image", conn))
                {
                    conn.Open();
                    using (MySqlDataReader rdr = selcmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            names.Add(rdr["name"].ToString());
                        }
                    }
                }
            }
            return names;
        }

        /// <summary>
        /// Ask the user for a file to upload in any of the accepted formats, which are png, jpg and bmp.
        /// </summary>
        /// <returns>Bitmap with the chosen image</returns>
        public Bitmap LoadImage()
        {
            List<string> names = GetListName();

            string name = _nameDefiner.SelectName(names);

            // If user clicks on OK, load image, else return nothing
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Load operation cancelled");
            }

            using (MySqlConnection conn = new MySqlConnection(_connString))
            {
                using (MySqlCommand selcmd = new MySqlCommand("SELECT image FROM Image where name=@name", conn))
                {
                    selcmd.Parameters.Add("name", MySqlDbType.VarString).Value = name;
                    conn.Open();
                    using (MySqlDataReader rdr = selcmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            return _convertImage.GetBitmapFromByteArray((byte[])rdr["image"]);
                        }
                    }
                }
            }
            throw new ArgumentException("Load operation failed"); ;
        }

        /// <summary>
        /// Save an image to the user's chosen path
        /// </summary>
        /// <param name="image">Image to be saved</param>
        /// <returns>True when the save process was successful, else false</returns>
        public bool SaveImage(Image image)
        {
            if (image == null)
            {
                throw new NullReferenceException("You need to load and process a file before saving it");
            }

            // Ask for save location
            string name = _nameDefiner.DefineName();

            // If user clicks on OK, save image else do nothing
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Save operation cancelled");
            }

            using (MySqlConnection conn = new MySqlConnection(_connString))
            {
                using (MySqlCommand insertcommand = new MySqlCommand("Insert into Image (name, image) Values (@name, @image)", conn))
                {
                    conn.Open();
                    insertcommand.Parameters.Add("image", MySqlDbType.Blob, 0).Value = _convertImage.ConvertImageToByteArray(image, System.Drawing.Imaging.ImageFormat.Jpeg);
                    insertcommand.Parameters.Add("name", MySqlDbType.VarChar).Value = name;
                    int result = insertcommand.ExecuteNonQuery();

                    return result == 1;
                }
            }
            throw new ArgumentException("Save operation failed");
        }
    }
}

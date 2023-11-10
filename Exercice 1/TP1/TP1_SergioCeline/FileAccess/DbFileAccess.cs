using MySqlConnector;
using TP1_SergioCeline.DefineName;
using TP1_SergioCeline.Tools;

namespace TP1_SergioCeline.FileAccess
{
    public class DbFileAccess : IFileAccess
    {
        private INameDefiner _nameDefiner;
        private string _connString;
        public DbFileAccess(INameDefiner nameDefiner)
        {
            _nameDefiner = nameDefiner;
            _connString = System.Configuration.ConfigurationManager.ConnectionStrings
                  ["ConnectionString"].ConnectionString;
        }

        /// <summary>
        /// Ask the user for a file to upload in any of the accepted formats, which are png, jpg and bmp.
        /// </summary>
        /// <returns>Bitmap with the chosen image</returns>
        public Bitmap LoadImage()
        {
            List<string> names = new List<string> ();
            try
            {
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
            }
            catch (Exception ex)
            {
                // TODO show error :)
            }

            string name = _nameDefiner.SelectName(names);

            // If user clicks on OK, load image, else return nothing
            if (!string.IsNullOrEmpty(name))
            {
                try
                {
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
                                    return _GetBitmapFromByteArray((byte[])rdr["image"]);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                    // TODO show exception :)
                }
            }
            throw new ArgumentException("Load operation cancelled");
        }

        /// <summary>
        /// Convert an array of bytes into a bitmap
        /// </summary>
        /// <param name="data">Image data in the form of an array of bytes</param>
        /// <returns>Bitmap with the image</returns>
        private Bitmap _GetBitmapFromByteArray(byte[] data)
        {
            using(MemoryStream ms = new MemoryStream(data))
            {
                return new Bitmap(ms);
            }
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
            if (!string.IsNullOrEmpty(name))
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(_connString))
                    {
                        using (MySqlCommand insertcommand = new MySqlCommand("Insert into Image (name, image) Values (@name, @image)", conn))
                        {
                            conn.Open();
                            insertcommand.Parameters.Add("image", MySqlDbType.Blob, 0).Value =
                        (new ConvertImage()).ConvertImageToByteArray(image, System.Drawing.Imaging.ImageFormat.Jpeg);
                            insertcommand.Parameters.Add("name", MySqlDbType.VarChar).Value = name;
                            int result = insertcommand.ExecuteNonQuery();

                            if (result == 1)
                                return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                    // TODO show exception :)
                }
            }
            throw new ArgumentException("Save operation cancelled");
        }
    }
}

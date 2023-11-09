using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.Intrinsics.Arm;
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
            SqlDataReader rdr = null;
            SqlConnection conn = null;
            SqlCommand selcmd = null;
            try
            {
                conn = new SqlConnection(_connString);
                selcmd = new SqlCommand
              ("select name from [Image]", conn);
                conn.Open();
                rdr = selcmd.ExecuteReader();
                while (rdr.Read())
                {
                    names.Add(rdr["name"].ToString());
                }
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            string name = _nameDefiner.SelectName(names);

            // If user clicks on OK, load image, else return nothing
            if (!string.IsNullOrEmpty(name))
            {
                // Load and return the image
                 rdr = null;
                 conn = null;
                 selcmd = null;
                try
                {
                    conn = new SqlConnection(_connString);
                    selcmd = new SqlCommand
                  ("select image from [Image] where name=@name", conn);
                    selcmd.Parameters.Add("name",SqlDbType.NVarChar).Value = name;
                    conn.Open();
                    rdr = selcmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        //TODO
                        return new Bitmap((byte[])rdr["image"]);
                    }
                    if (rdr != null)
                        rdr.Close();
                }
                finally
                {
                    if (conn != null)
                        conn.Close();
                }
            }

            throw new ArgumentException("Load operation cancelled");
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
                SqlConnection conn = null;
                try
                {
                    conn = new SqlConnection(_connString);
                    conn.Open();
                    SqlCommand insertCommand =
                        new SqlCommand(
                        "Insert into [Image] (name, image) Values (@name, @image)", conn);
                    insertCommand.Parameters.Add("image", SqlDbType.Image, 0).Value =
                        (new ConvertImage()).ConvertImageToByteArray(image, System.Drawing.Imaging.ImageFormat.Jpeg);
                    insertCommand.Parameters.Add("name", SqlDbType.NVarChar).Value = name;
                    int queryResult = insertCommand.ExecuteNonQuery();
                    if (queryResult == 1)
                        return true;

                }
                finally
                {
                    if (conn != null)
                        conn.Close();
                }
            }
            throw new ArgumentException("Save operation cancelled");
        }
    }
}

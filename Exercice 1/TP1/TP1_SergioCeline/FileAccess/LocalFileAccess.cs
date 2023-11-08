using System.Drawing.Imaging;

namespace TP1_SergioCeline.FileAccess
{
    public class LocalFileAccess : IFileAccess
    {
        private IPathDefiner _pathDefiner;
        public LocalFileAccess(IPathDefiner pathDefiner)
        {
            _pathDefiner = pathDefiner;
        }

        /// <summary>
        /// Ask the user for a file to upload in any of the accepted formats, which are png, jpg and bmp.
        /// </summary>
        /// <returns>Bitmap with the chosen image</returns>
        public Bitmap LoadImage()
        {
            string file = _pathDefiner.DefinePath(true);

            // If user clicks on OK, load image, else return nothing
            if (!string.IsNullOrEmpty(file))
            {
                // Load and return the image
                StreamReader streamReader = new StreamReader(file);
                Bitmap imageInit = new Bitmap(streamReader.BaseStream);
                streamReader.Close();

                return imageInit;
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
            if(image == null)
            {
                throw new NullReferenceException("You need to load a file before saving it");
            }

            // Ask for save location
            string file = _pathDefiner.DefinePath(false);

            // If user clicks on OK, save image else do nothing
            if (!string.IsNullOrEmpty(file))
            {
                string fileExtension = Path.GetExtension(file).ToUpper();
                ImageFormat imgFormat = null!;

                // Define the file extension
                switch (fileExtension)
                {
                    case ".PNG":
                        imgFormat = ImageFormat.Png;
                        break;
                    case ".JPG":
                        imgFormat = ImageFormat.Jpeg;
                        break;
                    case ".BMP":
                        imgFormat = ImageFormat.Bmp;
                        break;
                }

                // Save the image
                image.Save(file, imgFormat);

                return true;
            }
            throw new ArgumentException("Save operation cancelled");
        }
    }
}

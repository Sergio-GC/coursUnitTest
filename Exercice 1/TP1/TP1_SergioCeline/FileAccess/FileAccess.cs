using System.Drawing.Imaging;

namespace TP1_SergioCeline.FileAccess
{
    public class FileAccess : IFileAccess
    {
        /// <summary>
        /// Ask the user for a file to upload in any of the accepted formats, which are png, jpg and bmp.
        /// </summary>
        /// <returns>Bitmap with the chosen image</returns>
        public Bitmap LoadImage()
        {
            // Ask user for image
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Title = "Select image ";
            OpenFileDialog.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg|Bitmap Images(*.bmp)|*.bmp";

            // If user clicks on OK, load image, else return nothing
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Load and return the image
                StreamReader streamReader = new StreamReader(OpenFileDialog.FileName);
                Bitmap imageInit = new Bitmap(streamReader.BaseStream);
                streamReader.Close();

                return imageInit;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Save image at the chosen location by the user.
        /// </summary>
        /// <param name="image"></param>
        public void SaveImage(Image image)
        {
            // Ask for save location
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Specify a file name and file path";
            sfd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg|Bitmap Images(*.bmp)|*.bmp";

            // If user clicks on OK, save image else do nothing
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string fileExtension = Path.GetExtension(sfd.FileName).ToUpper();
                ImageFormat imgFormat = null;

                // Define the file extension
                switch (fileExtension)
                {
                    case "PNG":
                        imgFormat = ImageFormat.Png;
                        break;
                    case "JPG":
                        imgFormat = ImageFormat.Jpeg;
                        break;
                    case "BMP":
                        imgFormat = ImageFormat.Bmp;
                        break;
                }

                // Save the image
                image.Save(sfd.FileName, imgFormat);
            }
        }
    }
}

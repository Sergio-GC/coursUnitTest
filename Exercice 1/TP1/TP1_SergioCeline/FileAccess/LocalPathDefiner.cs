namespace TP1_SergioCeline.FileAccess
{
    public class LocalPathDefiner : IPathDefiner
    {
        /// <summary>
        /// Ask the user for a file in their system
        /// </summary>
        /// <returns>Path to the chosen file</returns>
        public string DefinePath()
        {
            // Ask user for image
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Title = "Select image ";
            OpenFileDialog.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg|Bitmap Images(*.bmp)|*.bmp";

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                return OpenFileDialog.FileName;
            }
            else
            {
                return null;
            }
        }
    }
}

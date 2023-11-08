using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace TP1_SergioCeline.FileAccess
{
    public class LocalPathDefiner : IPathDefiner
    {
        /// <summary>
        /// Ask the user for a file in their system
        /// </summary>
        /// <param name="openMode">If the file need to exist</param>
        /// <returns>Path to the chosen file</returns>
        public string DefinePath(bool openMode)
        {
            FileDialog dialog;

            // Ask user for image
            if (openMode)
            {
                dialog = new OpenFileDialog();
                dialog.Title = "Select image";
            }
            else
            {
                dialog = new SaveFileDialog();
                dialog.Title = "Specify a file name and file path";
            }
            dialog.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg|Bitmap Images(*.bmp)|*.bmp";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return null!;
        }
    }
}

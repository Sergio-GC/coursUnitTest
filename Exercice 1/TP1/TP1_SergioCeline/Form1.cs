using System.Drawing;
using System.Drawing.Imaging;

namespace TP1_SergioCeline
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Title = "Select image ";
            OpenFileDialog.Filter = "Jpeg Images(*.jpg)|*.jpg|Png Images(*.png)|*.png|Bitmap Images(*.bmp)|*.bmp";

            if (OpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(OpenFileDialog.FileName);
                Bitmap image = new Bitmap(streamReader.BaseStream);
                streamReader.Close();

                pbInit.Image = image;

            }
        }

        private void btnTrasform_Click(object sender, EventArgs e)
        {

        }

        private void btnSavePicture_Click(object sender, EventArgs e)
        {
           Bitmap image = (Bitmap) pbResult.Image;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Specify a file name and file path";
            sfd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
            sfd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileExtension = Path.GetExtension(sfd.FileName).ToUpper();
                ImageFormat imgFormat = ImageFormat.Png;

                if (fileExtension == "BMP")
                {
                    imgFormat = ImageFormat.Bmp;
                }
                else if (fileExtension == "JPG")
                {
                    imgFormat = ImageFormat.Jpeg;
                }

                StreamWriter streamWriter = new StreamWriter(sfd.FileName, false);
                image.Save(streamWriter.BaseStream, imgFormat);
                streamWriter.Flush();
                streamWriter.Close();

            }
        }
}
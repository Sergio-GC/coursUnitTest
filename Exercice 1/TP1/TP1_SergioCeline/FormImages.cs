using System.Drawing;
using System.Drawing.Imaging;
using TP1_SergioCeline.AlgoEdges;
using TP1_SergioCeline.AlgoFilters;

namespace TP1_SergioCeline
{
    public partial class FormImages : Form
    {
        AlgoEdge[] algoEdge = { new Laplacian(), new Sobel() };
        AlgoFilter[] filters = { new Rainbow(), new BlackWhite(), new ColorSwap() };
        public FormImages()
        {
            InitializeComponent();
            InitCmbAlgoEdge();
            InitLbFilter();
        }

        private void InitLbFilter()
        {
            lbFilter.Items.AddRange(filters);
        }

        private void InitCmbAlgoEdge()
        {
            cmbAlgoEdge.Items.AddRange(algoEdge);
            cmbAlgoEdge.SelectedIndex = 0;
        }

        private void btnLoadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Title = "Select image ";
            OpenFileDialog.Filter = "Jpeg Images(*.jpg)|*.jpg|Png Images(*.png)|*.png|Bitmap Images(*.bmp)|*.bmp";

            if (OpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(OpenFileDialog.FileName);
                Bitmap imageInit = new Bitmap(streamReader.BaseStream);
                streamReader.Close();

                pbInit.Image = imageInit;

            }
        }

        private void btnSavePicture_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Specify a file name and file path";
            sfd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
            sfd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

            if (sfd.ShowDialog() == DialogResult.OK)
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
                pbResult.Image.Save(sfd.FileName, imgFormat);

            }
        }

        private void btnTransform_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pbInit.Image);
            // application du filtre
            foreach (var item in lbFilter.SelectedItems)
            {
                bitmap = ((AlgoFilter)item).algo(bitmap);
            }
            // application du Edge
            bitmap = ((AlgoEdge)cmbAlgoEdge.SelectedItem).algo(bitmap);

            pbResult.Image = bitmap;
        }
    }
}
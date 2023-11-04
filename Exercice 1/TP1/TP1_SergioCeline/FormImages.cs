using System.Drawing.Imaging;
using TP1_SergioCeline.AlgoEdges;
using TP1_SergioCeline.AlgoFilters;
using TP1_SergioCeline.FileAccess;

namespace TP1_SergioCeline
{
    public partial class FormImages : Form
    {
        AlgoEdge[] algoEdge = { new Laplacian(), new Sobel() };
        AlgoFilter[] filters = { new Rainbow(), new BlackWhite(), new ColorSwap() };

        IFileAccess fileAccess;

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
            pbInit.Image = fileAccess.LoadImage();
        }

        private void btnSavePicture_Click(object sender, EventArgs e)
        {
            fileAccess.SaveImage(pbResult.Image);
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
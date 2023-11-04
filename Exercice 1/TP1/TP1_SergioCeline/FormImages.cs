using System.Drawing.Imaging;
using TP1_SergioCeline.AlgoEdges;
using TP1_SergioCeline.AlgoFilters;
using TP1_SergioCeline.FileAccess;

namespace TP1_SergioCeline
{
    public partial class FormImages : Form
    {
        AlgoEdge[] algoEdge = { new NoEdgeDetection(), new Laplacian(), new Sobel(), new Prewitt() };
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
            cmbEdgeDetection.Items.AddRange(algoEdge);
            cmbEdgeDetection.SelectedIndex = 0;
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
            bitmap = ((AlgoEdge)cmbEdgeDetection.SelectedItem).algo(bitmap);

            pbResult.Image = bitmap;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lbFilter.SelectedItems.Clear();
            cmbEdgeDetection.SelectedIndex = 0;
            pbResult.Image = null;
            pbInit.Image = null;
        }
    }
}
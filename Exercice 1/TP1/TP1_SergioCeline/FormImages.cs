using TP1_SergioCeline.AlgoEdges;
using TP1_SergioCeline.AlgoFilters;
using TP1_SergioCeline.Business;
using TP1_SergioCeline.DefineName;
using TP1_SergioCeline.FileAccess;
using TP1_SergioCeline.Tools;

namespace TP1_SergioCeline
{
    public partial class FormImages : Form
    {
        AlgoEdge[] algoEdge = { new NoEdgeDetection(), new Laplacian(), new Sobel(), new Prewitt() };
        AlgoFilter[] filters = { new Rainbow(), new BlackWhite(), new ColorSwap() };
        CustomToolTip _customToolTip;

        private IFileAccess _fileAccess, _dbFile;
        private IManager _manager;

        public FormImages()
        {
            InitializeComponent();
            InitCmbAlgoEdge();
            InitLbFilter();
            _manager = new Manager();
            _fileAccess = new LocalFileAccess(new LocalPathDefiner());
            _dbFile = new DbFileAccess(new WindowsNameDefiner(), new ConvertImage());
            _customToolTip = new CustomToolTip();
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
            try
            {
                pbInit.Image = _fileAccess.LoadImage();
            }
            catch(ArgumentException ex)
            {
                // User cancelled load of image
                _customToolTip.Show(ex.Message, this, (Width - _customToolTip.SIZE_X) / 2, (int)(Height - (1.5 * _customToolTip.SIZE_Y)), 2500);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSavePicture_Click(object sender, EventArgs e)
        {
            try
            {
                _dbFile.SaveImage(pbResult.Image);
            }
            catch (ArgumentException ex)
            {
                // User cancelled save of image
                _customToolTip.Show(ex.Message, this, (Width - _customToolTip.SIZE_X) / 2, (int)(Height - (1.5 * _customToolTip.SIZE_Y)), 2500);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTransform_Click(object sender, EventArgs e)
        {
            try
            {
                pbResult.Image = _manager.Process(pbInit.Image, lbFilter.SelectedItems.Cast<AlgoFilter>().ToList(), (AlgoEdge)cmbEdgeDetection.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
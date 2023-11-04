using TP1_SergioCeline.FileAccess;

namespace TP1_SergioCeline
{
    partial class FormImages
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            fileAccess = new LocalFileAccess(new LocalPathDefiner());

            pbInit = new PictureBox();
            cmbEdgeDetection = new ComboBox();
            btnLoadPicture = new Button();
            btnTransform = new Button();
            btnSavePicture = new Button();
            pbResult = new PictureBox();
            lbFilter = new ListBox();
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)pbInit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbResult).BeginInit();
            SuspendLayout();
            // 
            // pbInit
            // 
            pbInit.Location = new Point(12, 12);
            pbInit.Name = "pbInit";
            pbInit.Size = new Size(420, 426);
            pbInit.SizeMode = PictureBoxSizeMode.StretchImage;
            pbInit.TabIndex = 0;
            pbInit.TabStop = false;
            // 
            // cmbEdgeDetection
            // 
            cmbEdgeDetection.FormattingEnabled = true;
            cmbEdgeDetection.Location = new Point(451, 229);
            cmbEdgeDetection.Name = "cmbEdgeDetection";
            cmbEdgeDetection.Size = new Size(185, 33);
            cmbEdgeDetection.TabIndex = 2;
            // 
            // btnLoadPicture
            // 
            btnLoadPicture.Location = new Point(451, 12);
            btnLoadPicture.Name = "btnLoadPicture";
            btnLoadPicture.Size = new Size(185, 48);
            btnLoadPicture.TabIndex = 3;
            btnLoadPicture.Text = "Load";
            btnLoadPicture.UseVisualStyleBackColor = true;
            btnLoadPicture.Click += btnLoadPicture_Click;
            // 
            // btnTransform
            // 
            btnTransform.Location = new Point(451, 282);
            btnTransform.Name = "btnTransform";
            btnTransform.Size = new Size(185, 48);
            btnTransform.TabIndex = 4;
            btnTransform.Text = "Process";
            btnTransform.UseVisualStyleBackColor = true;
            btnTransform.Click += btnTransform_Click;
            // 
            // btnSavePicture
            // 
            btnSavePicture.Location = new Point(451, 336);
            btnSavePicture.Name = "btnSavePicture";
            btnSavePicture.Size = new Size(185, 48);
            btnSavePicture.TabIndex = 5;
            btnSavePicture.Text = "Save";
            btnSavePicture.UseVisualStyleBackColor = true;
            btnSavePicture.Click += btnSavePicture_Click;
            // 
            // pbResult
            // 
            pbResult.Location = new Point(660, 12);
            pbResult.Name = "pbResult";
            pbResult.Size = new Size(420, 426);
            pbResult.SizeMode = PictureBoxSizeMode.StretchImage;
            pbResult.TabIndex = 6;
            pbResult.TabStop = false;
            // 
            // lbFilter
            // 
            lbFilter.FormattingEnabled = true;
            lbFilter.ItemHeight = 25;
            lbFilter.Location = new Point(451, 80);
            lbFilter.Name = "lbFilter";
            lbFilter.SelectionMode = SelectionMode.MultiSimple;
            lbFilter.Size = new Size(185, 129);
            lbFilter.TabIndex = 7;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(451, 390);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(185, 48);
            btnReset.TabIndex = 8;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // FormImages
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1115, 455);
            Controls.Add(btnReset);
            Controls.Add(cmbEdgeDetection);
            Controls.Add(lbFilter);
            Controls.Add(pbResult);
            Controls.Add(btnSavePicture);
            Controls.Add(btnTransform);
            Controls.Add(btnLoadPicture);
            Controls.Add(pbInit);
            Name = "FormImages";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pbInit).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbResult).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbInit;
        private ComboBox cmbEdgeDetection;
        private Button btnLoadPicture;
        private Button btnTransform;
        private Button btnSavePicture;
        private PictureBox pbResult;
        private ListBox lbFilter;
        private Button btnReset;
    }
}
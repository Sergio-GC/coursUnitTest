namespace TP1_SergioCeline
{
    partial class Form1
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
            pbInit = new PictureBox();
            cmbFilter = new ComboBox();
            cmbAlgoEdge = new ComboBox();
            btnLoadPicture = new Button();
            btnTransform = new Button();
            btnSavePicture = new Button();
            pbResult = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbInit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbResult).BeginInit();
            SuspendLayout();
            // 
            // pbInit
            // 
            pbInit.Location = new Point(12, 12);
            pbInit.Name = "pbInit";
            pbInit.Size = new Size(420, 426);
            pbInit.TabIndex = 0;
            pbInit.TabStop = false;
            pbInit.SizeMode = PictureBoxSizeMode.StretchImage;
            // 
            // cmbFilter
            // 
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Location = new Point(451, 82);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(185, 33);
            cmbFilter.TabIndex = 1;
            // 
            // cmbAlgoEdge
            // 
            cmbAlgoEdge.FormattingEnabled = true;
            cmbAlgoEdge.Location = new Point(451, 149);
            cmbAlgoEdge.Name = "cmbAlgoEdge";
            cmbAlgoEdge.Size = new Size(185, 33);
            cmbAlgoEdge.TabIndex = 2;
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
            btnTransform.Location = new Point(451, 219);
            btnTransform.Name = "btnTransform";
            btnTransform.Size = new Size(185, 48);
            btnTransform.TabIndex = 4;
            btnTransform.Text = "Process";
            btnTransform.UseVisualStyleBackColor = true;
            btnTransform.Click += btnTransform_Click;
            // 
            // btnSavePicture
            // 
            btnSavePicture.Location = new Point(451, 390);
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
            pbResult.TabIndex = 6;
            pbResult.TabStop = false;
            pbResult.SizeMode = PictureBoxSizeMode.StretchImage;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1115, 455);
            Controls.Add(pbResult);
            Controls.Add(btnSavePicture);
            Controls.Add(btnTransform);
            Controls.Add(btnLoadPicture);
            Controls.Add(cmbAlgoEdge);
            Controls.Add(cmbFilter);
            Controls.Add(pbInit);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pbInit).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbResult).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbInit;
        private ComboBox cmbFilter;
        private ComboBox cmbAlgoEdge;
        private Button btnLoadPicture;
        private Button btnTransform;
        private Button btnSavePicture;
        private PictureBox pbResult;
    }
}
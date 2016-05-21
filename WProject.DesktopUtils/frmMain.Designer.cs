namespace WProject.DesktopUtils
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpFileToBinary = new System.Windows.Forms.TabPage();
            this.btnConvert = new System.Windows.Forms.Button();
            this.lblFile = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.tcMain.SuspendLayout();
            this.tpFileToBinary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpFileToBinary);
            this.tcMain.Controls.Add(this.tabPage2);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(626, 443);
            this.tcMain.TabIndex = 0;
            // 
            // tpFileToBinary
            // 
            this.tpFileToBinary.Controls.Add(this.btnConvert);
            this.tpFileToBinary.Controls.Add(this.lblFile);
            this.tpFileToBinary.Controls.Add(this.btnSave);
            this.tpFileToBinary.Controls.Add(this.btnCopy);
            this.tpFileToBinary.Controls.Add(this.txtData);
            this.tpFileToBinary.Controls.Add(this.btnBrowse);
            this.tpFileToBinary.Controls.Add(this.txtPath);
            this.tpFileToBinary.Controls.Add(this.pbImage);
            this.tpFileToBinary.Location = new System.Drawing.Point(4, 37);
            this.tpFileToBinary.Name = "tpFileToBinary";
            this.tpFileToBinary.Padding = new System.Windows.Forms.Padding(3);
            this.tpFileToBinary.Size = new System.Drawing.Size(618, 402);
            this.tpFileToBinary.TabIndex = 0;
            this.tpFileToBinary.Text = "File to binary";
            this.tpFileToBinary.UseVisualStyleBackColor = true;
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvert.Location = new System.Drawing.Point(386, 154);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(109, 93);
            this.btnConvert.TabIndex = 7;
            this.btnConvert.Text = "Convert \r\n\\/";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(291, 34);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(42, 28);
            this.lblFile.TabIndex = 6;
            this.lblFile.Text = "File";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(386, 358);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 36);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Location = new System.Drawing.Point(501, 358);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(109, 36);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // txtData
            // 
            this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Location = new System.Drawing.Point(8, 253);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(602, 99);
            this.txtData.TabIndex = 3;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(501, 75);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(109, 36);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Location = new System.Drawing.Point(339, 34);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(271, 34);
            this.txtPath.TabIndex = 1;
            // 
            // pbImage
            // 
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Location = new System.Drawing.Point(8, 6);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(277, 241);
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 37);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(618, 402);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ofd
            // 
            this.ofd.Title = "Select file";
            this.ofd.FileOk += new System.ComponentModel.CancelEventHandler(this.ofd_FileOk);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 443);
            this.Controls.Add(this.tcMain);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.tcMain.ResumeLayout(false);
            this.tpFileToBinary.ResumeLayout(false);
            this.tpFileToBinary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpFileToBinary;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.OpenFileDialog ofd;
    }
}


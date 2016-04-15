namespace WProject.UiLibrary.Controls
{
    partial class WpTextEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.flwTop = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBold = new WProject.UiLibrary.Controls.WpButton();
            this.btnItalic = new WProject.UiLibrary.Controls.WpButton();
            this.btnUnderline = new WProject.UiLibrary.Controls.WpButton();
            this.btnList = new WProject.UiLibrary.Controls.WpButton();
            this.btnImage = new WProject.UiLibrary.Controls.WpButton();
            this.imageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.flwTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbText
            // 
            this.rtbText.AcceptsTab = true;
            this.rtbText.AutoWordSelection = true;
            this.rtbText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbText.BulletIndent = 1;
            this.rtbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbText.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbText.HideSelection = false;
            this.rtbText.Location = new System.Drawing.Point(0, 30);
            this.rtbText.Name = "rtbText";
            this.rtbText.Size = new System.Drawing.Size(408, 264);
            this.rtbText.TabIndex = 0;
            this.rtbText.Text = "";
            // 
            // flwTop
            // 
            this.flwTop.Controls.Add(this.btnBold);
            this.flwTop.Controls.Add(this.btnItalic);
            this.flwTop.Controls.Add(this.btnUnderline);
            this.flwTop.Controls.Add(this.btnList);
            this.flwTop.Controls.Add(this.btnImage);
            this.flwTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.flwTop.Location = new System.Drawing.Point(0, 0);
            this.flwTop.Name = "flwTop";
            this.flwTop.Size = new System.Drawing.Size(408, 30);
            this.flwTop.TabIndex = 1;
            // 
            // btnBold
            // 
            this.btnBold.FlatAppearance.BorderSize = 0;
            this.btnBold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBold.Location = new System.Drawing.Point(3, 3);
            this.btnBold.Name = "btnBold";
            this.btnBold.Selected = false;
            this.btnBold.Size = new System.Drawing.Size(24, 24);
            this.btnBold.TabIndex = 0;
            this.btnBold.Text = "B";
            this.btnBold.UseVisualStyleBackColor = true;
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);
            // 
            // btnItalic
            // 
            this.btnItalic.FlatAppearance.BorderSize = 0;
            this.btnItalic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItalic.Location = new System.Drawing.Point(33, 3);
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Selected = false;
            this.btnItalic.Size = new System.Drawing.Size(24, 24);
            this.btnItalic.TabIndex = 1;
            this.btnItalic.Text = "I";
            this.btnItalic.UseVisualStyleBackColor = true;
            this.btnItalic.Click += new System.EventHandler(this.btnItalic_Click);
            // 
            // btnUnderline
            // 
            this.btnUnderline.FlatAppearance.BorderSize = 0;
            this.btnUnderline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnderline.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnderline.Location = new System.Drawing.Point(63, 3);
            this.btnUnderline.Name = "btnUnderline";
            this.btnUnderline.Selected = false;
            this.btnUnderline.Size = new System.Drawing.Size(24, 24);
            this.btnUnderline.TabIndex = 2;
            this.btnUnderline.Text = "U";
            this.btnUnderline.UseVisualStyleBackColor = true;
            this.btnUnderline.Click += new System.EventHandler(this.btnUnderline_Click);
            // 
            // btnList
            // 
            this.btnList.FlatAppearance.BorderSize = 0;
            this.btnList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnList.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Image = global::WProject.UiLibrary.Properties.Resources.list_s;
            this.btnList.Location = new System.Drawing.Point(93, 3);
            this.btnList.Name = "btnList";
            this.btnList.Selected = false;
            this.btnList.Size = new System.Drawing.Size(24, 24);
            this.btnList.TabIndex = 3;
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnImage
            // 
            this.btnImage.FlatAppearance.BorderSize = 0;
            this.btnImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImage.Image = global::WProject.UiLibrary.Properties.Resources.image_s;
            this.btnImage.Location = new System.Drawing.Point(123, 3);
            this.btnImage.Name = "btnImage";
            this.btnImage.Selected = false;
            this.btnImage.Size = new System.Drawing.Size(24, 24);
            this.btnImage.TabIndex = 5;
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // imageFileDialog
            // 
            this.imageFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif;" +
    " *.png";
            this.imageFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.imageFileDialog_FileOk);
            // 
            // WpTextEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.rtbText);
            this.Controls.Add(this.flwTop);
            this.Name = "WpTextEditor";
            this.Size = new System.Drawing.Size(408, 294);
            this.Load += new System.EventHandler(this.WpTextEditor_Load);
            this.flwTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbText;
        private System.Windows.Forms.FlowLayoutPanel flwTop;
        private UiLibrary.Controls.WpButton btnBold;
        private UiLibrary.Controls.WpButton btnItalic;
        private UiLibrary.Controls.WpButton btnUnderline;
        private UiLibrary.Controls.WpButton btnList;
        private UiLibrary.Controls.WpButton btnImage;
        private System.Windows.Forms.OpenFileDialog imageFileDialog;
    }
}

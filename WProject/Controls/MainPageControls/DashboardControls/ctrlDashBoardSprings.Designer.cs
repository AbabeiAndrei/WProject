namespace WProject.Controls.MainPageControls.DashboardControls
{
    partial class ctrlDashBoardSprings
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
            WProject.UiLibrary.Style.UiStyle uiStyle1 = new WProject.UiLibrary.Style.UiStyle();
            WProject.UiLibrary.Style.Style style1 = new WProject.UiLibrary.Style.Style();
            WProject.UiLibrary.Style.UiStyle uiStyle2 = new WProject.UiLibrary.Style.UiStyle();
            WProject.UiLibrary.Style.Style style2 = new WProject.UiLibrary.Style.Style();
            this.flwTop = new System.Windows.Forms.FlowLayoutPanel();
            this.pbColapseIcon = new WProject.UiLibrary.Controls.WpPictureBox();
            this.tvSprings = new System.Windows.Forms.TreeView();
            this.flwTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // flwTop
            // 
            this.flwTop.Controls.Add(this.pbColapseIcon);
            this.flwTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.flwTop.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flwTop.Location = new System.Drawing.Point(0, 0);
            this.flwTop.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.flwTop.Name = "flwTop";
            this.flwTop.Size = new System.Drawing.Size(250, 39);
            this.flwTop.TabIndex = 0;
            // 
            // pbColapseIcon
            // 
            this.pbColapseIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbColapseIcon.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbColapseIcon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pbColapseIcon.ForeColor = System.Drawing.Color.White;
            this.pbColapseIcon.Image = null;
            this.pbColapseIcon.Location = new System.Drawing.Point(224, 3);
            this.pbColapseIcon.Name = "pbColapseIcon";
            this.pbColapseIcon.OwnStyle = false;
            this.pbColapseIcon.Size = new System.Drawing.Size(23, 27);
            this.pbColapseIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
            uiStyle1.ClickStyle = null;
            uiStyle1.HoverStyle = null;
            style1.BackColor = System.Drawing.Color.Transparent;
            style1.BorderColor = null;
            style1.BorderWidth = null;
            style1.Cursor = System.Windows.Forms.Cursors.Default;
            style1.Font = new System.Drawing.Font("Segoe UI", 12F);
            style1.ForeColor = System.Drawing.Color.White;
            style1.Margin = new System.Windows.Forms.Padding(3);
            style1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            uiStyle1.NormalStyle = style1;
            uiStyle1.SelectedStyle = null;
            this.pbColapseIcon.Style = uiStyle1;
            this.pbColapseIcon.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.pbColapseIcon.TabIndex = 0;
            this.pbColapseIcon.Click += new System.EventHandler(this.pbColapseIcon_Click);
            // 
            // tvSprings
            // 
            this.tvSprings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvSprings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSprings.FullRowSelect = true;
            this.tvSprings.HideSelection = false;
            this.tvSprings.Location = new System.Drawing.Point(0, 39);
            this.tvSprings.Name = "tvSprings";
            this.tvSprings.ShowLines = false;
            this.tvSprings.Size = new System.Drawing.Size(250, 409);
            this.tvSprings.TabIndex = 1;
            this.tvSprings.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSprings_AfterSelect);
            // 
            // ctrlDashBoardSprings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tvSprings);
            this.Controls.Add(this.flwTop);
            this.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.Name = "ctrlDashBoardSprings";
            this.Size = new System.Drawing.Size(250, 448);
            uiStyle2.ClickStyle = null;
            uiStyle2.HoverStyle = null;
            style2.BackColor = System.Drawing.Color.Transparent;
            style2.BorderColor = null;
            style2.BorderWidth = null;
            style2.Cursor = System.Windows.Forms.Cursors.Default;
            style2.Font = new System.Drawing.Font("Segoe UI", 14F);
            style2.ForeColor = System.Drawing.Color.Black;
            style2.Margin = new System.Windows.Forms.Padding(3);
            style2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            uiStyle2.NormalStyle = style2;
            uiStyle2.SelectedStyle = null;
            this.Style = uiStyle2;
            this.flwTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flwTop;
        private UiLibrary.Controls.WpPictureBox pbColapseIcon;
        private System.Windows.Forms.TreeView tvSprings;
    }
}

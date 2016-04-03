using WProject.WebApiClasses.Classes;

namespace WProject.Controls.MainPageControls.DashboardControls
{
    partial class ctrlDashBoardTaskItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlDashBoardTaskItem));
            WProject.UiLibrary.Style.UiStyle uiStyle1 = new WProject.UiLibrary.Style.UiStyle();
            WProject.UiLibrary.Style.Style style1 = new WProject.UiLibrary.Style.Style();
            WProject.UiLibrary.Style.Style style2 = new WProject.UiLibrary.Style.Style();
            WProject.UiLibrary.Style.UiStyle uiStyle2 = new WProject.UiLibrary.Style.UiStyle();
            WProject.UiLibrary.Style.Style style3 = new WProject.UiLibrary.Style.Style();
            WProject.UiLibrary.Style.UiStyle uiStyle3 = new WProject.UiLibrary.Style.UiStyle();
            WProject.UiLibrary.Style.Style style4 = new WProject.UiLibrary.Style.Style();
            this.ddUsers = new WProject.UiLibrary.Controls.WpDropDown<User>();
            this.SuspendLayout();
            // 
            // ddUsers
            // 
            this.ddUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddUsers.BackColor = System.Drawing.Color.White;
            this.ddUsers.Cursor = System.Windows.Forms.Cursors.Default;
            this.ddUsers.CustomControl = null;
            this.ddUsers.DisplayMember = null;
            this.ddUsers.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ddUsers.ForeColor = System.Drawing.Color.Black;
            this.ddUsers.ImageMember = null;
            uiStyle1.ClickStyle = null;
            style1.BackColor = System.Drawing.Color.LightGray;
            style1.BorderColor = null;
            style1.BorderWidth = null;
            style1.Cursor = System.Windows.Forms.Cursors.Default;
            style1.Font = new System.Drawing.Font("Segoe UI", 12F);
            style1.ForeColor = System.Drawing.Color.Black;
            style1.Margin = new System.Windows.Forms.Padding(3);
            style1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            uiStyle1.HoverStyle = style1;
            style2.BackColor = System.Drawing.Color.White;
            style2.BorderColor = null;
            style2.BorderWidth = null;
            style2.Cursor = System.Windows.Forms.Cursors.Default;
            style2.Font = new System.Drawing.Font("Segoe UI", 12F);
            style2.ForeColor = System.Drawing.Color.Black;
            style2.Margin = new System.Windows.Forms.Padding(3);
            style2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            uiStyle1.NormalStyle = style2;
            uiStyle1.SelectedStyle = null;
            this.ddUsers.ItemStyle = uiStyle1;
            this.ddUsers.Location = new System.Drawing.Point(13, 142);
            this.ddUsers.Name = "ddUsers";
            this.ddUsers.SelectedIndex = 0;
            this.ddUsers.ShowImage = true;
            this.ddUsers.Size = new System.Drawing.Size(243, 27);
            this.ddUsers.SortMember = null;
            uiStyle2.ClickStyle = null;
            uiStyle2.HoverStyle = null;
            style3.BackColor = System.Drawing.Color.White;
            style3.BorderColor = null;
            style3.BorderWidth = null;
            style3.Cursor = System.Windows.Forms.Cursors.Default;
            style3.Font = new System.Drawing.Font("Segoe UI", 12F);
            style3.ForeColor = System.Drawing.Color.Black;
            style3.Margin = new System.Windows.Forms.Padding(3);
            style3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            uiStyle2.NormalStyle = style3;
            uiStyle2.SelectedStyle = null;
            this.ddUsers.Style = uiStyle2;
            this.ddUsers.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.ddUsers.TabIndex = 0;
            this.ddUsers.ValueMember = null;
            // 
            // ctrlDashBoardTaskItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ddUsers);
            this.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.Name = "ctrlDashBoardTaskItem";
            this.Size = new System.Drawing.Size(268, 172);
            uiStyle3.ClickStyle = null;
            uiStyle3.HoverStyle = null;
            style4.BackColor = System.Drawing.Color.Transparent;
            style4.BorderColor = null;
            style4.BorderWidth = null;
            style4.Cursor = System.Windows.Forms.Cursors.Default;
            style4.Font = new System.Drawing.Font("Segoe UI", 14F);
            style4.ForeColor = System.Drawing.Color.Black;
            style4.Margin = new System.Windows.Forms.Padding(3);
            style4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            uiStyle3.NormalStyle = style4;
            uiStyle3.SelectedStyle = null;
            this.Style = uiStyle3;
            this.ResumeLayout(false);

        }

        #endregion

        private UiLibrary.Controls.WpDropDown<User> ddUsers;
    }
}

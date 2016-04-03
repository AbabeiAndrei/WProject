using System.Windows.Forms;
using WProject.WebApiClasses.Classes;

namespace WProject.Controls.MainPageControls.DashboardControls
{
    partial class ctrlDashBoardBacklogItemControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlDashBoardBacklogItemControl));
            WProject.UiLibrary.Style.UiStyle uiStyle1 = new WProject.UiLibrary.Style.UiStyle();
            WProject.UiLibrary.Style.Style style1 = new WProject.UiLibrary.Style.Style();
            WProject.UiLibrary.Style.Style style2 = new WProject.UiLibrary.Style.Style();
            WProject.UiLibrary.Style.UiStyle uiStyle2 = new WProject.UiLibrary.Style.UiStyle();
            WProject.UiLibrary.Style.Style style3 = new WProject.UiLibrary.Style.Style();
            WProject.UiLibrary.Style.UiStyle uiStyle3 = new WProject.UiLibrary.Style.UiStyle();
            WProject.UiLibrary.Style.Style style4 = new WProject.UiLibrary.Style.Style();
            WProject.UiLibrary.Style.Style style5 = new WProject.UiLibrary.Style.Style();
            WProject.UiLibrary.Style.UiStyle uiStyle4 = new WProject.UiLibrary.Style.UiStyle();
            WProject.UiLibrary.Style.Style style6 = new WProject.UiLibrary.Style.Style();
            WProject.UiLibrary.Style.UiStyle uiStyle5 = new WProject.UiLibrary.Style.UiStyle();
            WProject.UiLibrary.Style.Style style7 = new WProject.UiLibrary.Style.Style();
            this.lblName = new WProject.UiLibrary.Controls.WpLabel();
            this.ddUsers = new WProject.UiLibrary.Controls.WpDropDown<User>();
            this.ddStates = new WProject.UiLibrary.Controls.WpDropDown<DictItem>();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Selected = false;
            this.lblName.Size = new System.Drawing.Size(275, 101);
            this.lblName.Style = null;
            this.lblName.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.lblName.TabIndex = 0;
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
            this.ddUsers.Location = new System.Drawing.Point(6, 104);
            this.ddUsers.Name = "ddUsers";
            this.ddUsers.SelectedIndex = 0;
            this.ddUsers.ShowImage = true;
            this.ddUsers.Size = new System.Drawing.Size(170, 27);
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
            this.ddUsers.TabIndex = 1;
            this.ddUsers.ValueMember = null;
            // 
            // ddStates
            // 
            this.ddStates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ddStates.BackColor = System.Drawing.Color.White;
            this.ddStates.Cursor = System.Windows.Forms.Cursors.Default;
            this.ddStates.CustomControl = null;
            this.ddStates.DisplayMember = null;
            this.ddStates.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ddStates.ForeColor = System.Drawing.Color.Black;
            this.ddStates.ImageMember = null;
            uiStyle3.ClickStyle = null;
            style4.BackColor = System.Drawing.Color.LightGray;
            style4.BorderColor = null;
            style4.BorderWidth = null;
            style4.Cursor = System.Windows.Forms.Cursors.Default;
            style4.Font = new System.Drawing.Font("Segoe UI", 12F);
            style4.ForeColor = System.Drawing.Color.Black;
            style4.Margin = new System.Windows.Forms.Padding(3);
            style4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            uiStyle3.HoverStyle = style4;
            style5.BackColor = System.Drawing.Color.White;
            style5.BorderColor = null;
            style5.BorderWidth = null;
            style5.Cursor = System.Windows.Forms.Cursors.Default;
            style5.Font = new System.Drawing.Font("Segoe UI", 12F);
            style5.ForeColor = System.Drawing.Color.Black;
            style5.Margin = new System.Windows.Forms.Padding(3);
            style5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            uiStyle3.NormalStyle = style5;
            uiStyle3.SelectedStyle = null;
            this.ddStates.ItemStyle = uiStyle3;
            this.ddStates.Location = new System.Drawing.Point(182, 104);
            this.ddStates.Name = "ddStates";
            this.ddStates.SelectedIndex = 0;
            this.ddStates.ShowImage = false;
            this.ddStates.Size = new System.Drawing.Size(90, 27);
            this.ddStates.SortMember = null;
            uiStyle4.ClickStyle = null;
            uiStyle4.HoverStyle = null;
            style6.BackColor = System.Drawing.Color.White;
            style6.BorderColor = null;
            style6.BorderWidth = null;
            style6.Cursor = System.Windows.Forms.Cursors.Default;
            style6.Font = new System.Drawing.Font("Segoe UI", 12F);
            style6.ForeColor = System.Drawing.Color.Black;
            style6.Margin = new System.Windows.Forms.Padding(3);
            style6.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            uiStyle4.NormalStyle = style6;
            uiStyle4.SelectedStyle = null;
            this.ddStates.Style = uiStyle4;
            this.ddStates.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.ddStates.TabIndex = 2;
            this.ddStates.ValueMember = null;
            // 
            // ctrlDashBoardBacklogItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ddStates);
            this.Controls.Add(this.ddUsers);
            this.Controls.Add(this.lblName);
            this.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.Name = "ctrlDashBoardBacklogItemControl";
            this.Size = new System.Drawing.Size(275, 138);
            uiStyle5.ClickStyle = null;
            uiStyle5.HoverStyle = null;
            style7.BackColor = System.Drawing.Color.Transparent;
            style7.BorderColor = null;
            style7.BorderWidth = null;
            style7.Cursor = System.Windows.Forms.Cursors.Default;
            style7.Font = new System.Drawing.Font("Segoe UI", 14F);
            style7.ForeColor = System.Drawing.Color.Black;
            style7.Margin = new System.Windows.Forms.Padding(3);
            style7.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            uiStyle5.NormalStyle = style7;
            uiStyle5.SelectedStyle = null;
            this.Style = uiStyle5;
            this.ResumeLayout(false);

        }

        #endregion

        private UiLibrary.Controls.WpLabel lblName;
        private UiLibrary.Controls.WpDropDown<User> ddUsers;
        private UiLibrary.Controls.WpDropDown<DictItem> ddStates;
    }
}

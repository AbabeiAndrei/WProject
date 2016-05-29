namespace WProject.Controls.MainPageControls.Task_Editor_Controls
{
    partial class ctrlTaskHistoryItem
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
            this.pbExpandColapse = new WProject.UiLibrary.Controls.WpPictureBox();
            this.lblTitle = new WProject.UiLibrary.Controls.WpLabel();
            this.lvChanges = new System.Windows.Forms.ListView();
            this.chField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNewValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOldValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // pbExpandColapse
            // 
            this.pbExpandColapse.BackColor = System.Drawing.Color.Transparent;
            this.pbExpandColapse.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbExpandColapse.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pbExpandColapse.ForeColor = System.Drawing.Color.Black;
            this.pbExpandColapse.Image = null;
            this.pbExpandColapse.Location = new System.Drawing.Point(0, 0);
            this.pbExpandColapse.Name = "pbExpandColapse";
            this.pbExpandColapse.OwnStyle = true;
            this.pbExpandColapse.Size = new System.Drawing.Size(32, 32);
            this.pbExpandColapse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbExpandColapse.TabIndex = 0;
            this.pbExpandColapse.Click += new System.EventHandler(this.pbExpandColapse_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(38, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Selected = false;
            this.lblTitle.Size = new System.Drawing.Size(224, 28);
            this.lblTitle.Style = null;
            this.lblTitle.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "User made field changes";
            // 
            // lvChanges
            // 
            this.lvChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvChanges.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvChanges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chField,
            this.chNewValue,
            this.chOldValue});
            this.lvChanges.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvChanges.FullRowSelect = true;
            this.lvChanges.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvChanges.Location = new System.Drawing.Point(43, 41);
            this.lvChanges.MultiSelect = false;
            this.lvChanges.Name = "lvChanges";
            this.lvChanges.Size = new System.Drawing.Size(630, 0);
            this.lvChanges.TabIndex = 2;
            this.lvChanges.UseCompatibleStateImageBehavior = false;
            this.lvChanges.View = System.Windows.Forms.View.Details;
            this.lvChanges.Visible = false;
            // 
            // chField
            // 
            this.chField.Text = "Field";
            this.chField.Width = 117;
            // 
            // chNewValue
            // 
            this.chNewValue.Text = "New Value";
            this.chNewValue.Width = 244;
            // 
            // chOldValue
            // 
            this.chOldValue.Text = "Old Value";
            this.chOldValue.Width = 269;
            // 
            // ctrlTaskHistoryItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lvChanges);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbExpandColapse);
            this.Name = "ctrlTaskHistoryItem";
            this.Size = new System.Drawing.Size(682, 32);
            this.Load += new System.EventHandler(this.ctrlTaskHistoryItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UiLibrary.Controls.WpPictureBox pbExpandColapse;
        private UiLibrary.Controls.WpLabel lblTitle;
        private System.Windows.Forms.ListView lvChanges;
        private System.Windows.Forms.ColumnHeader chField;
        private System.Windows.Forms.ColumnHeader chNewValue;
        private System.Windows.Forms.ColumnHeader chOldValue;
    }
}

namespace WProject.Controls.MainPageControls
{
    partial class ctrlAdmin
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
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpUsers = new System.Windows.Forms.TabPage();
            this.lvUsers = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chGroups = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlActions = new WProject.UiLibrary.Controls.WpPanel();
            this.btnUserAdd = new WProject.UiLibrary.Controls.WpButton();
            this.tpGroups = new System.Windows.Forms.TabPage();
            this.lvGroups = new System.Windows.Forms.ListView();
            this.chGroupName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chGroupUsers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wpPanel1 = new WProject.UiLibrary.Controls.WpPanel();
            this.btnAddGroup = new WProject.UiLibrary.Controls.WpButton();
            this.tpProjects = new System.Windows.Forms.TabPage();
            this.pnlIterațions = new WProject.UiLibrary.Controls.WpPanel();
            this.tvSprings = new System.Windows.Forms.TreeView();
            this.pnlProjects = new WProject.UiLibrary.Controls.WpPanel();
            this.lvProjects = new System.Windows.Forms.ListView();
            this.chProjects = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wpPanel2 = new WProject.UiLibrary.Controls.WpPanel();
            this.wpButton1 = new WProject.UiLibrary.Controls.WpButton();
            this.btnAddSpring = new WProject.UiLibrary.Controls.WpButton();
            this.wpPanel3 = new WProject.UiLibrary.Controls.WpPanel();
            this.wpButton2 = new WProject.UiLibrary.Controls.WpButton();
            this.wpButton3 = new WProject.UiLibrary.Controls.WpButton();
            this.btnAddProject = new WProject.UiLibrary.Controls.WpButton();
            this.tcMain.SuspendLayout();
            this.tpUsers.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.tpGroups.SuspendLayout();
            this.wpPanel1.SuspendLayout();
            this.tpProjects.SuspendLayout();
            this.pnlIterațions.SuspendLayout();
            this.pnlProjects.SuspendLayout();
            this.wpPanel2.SuspendLayout();
            this.wpPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpUsers);
            this.tcMain.Controls.Add(this.tpGroups);
            this.tcMain.Controls.Add(this.tpProjects);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(840, 528);
            this.tcMain.TabIndex = 0;
            // 
            // tpUsers
            // 
            this.tpUsers.Controls.Add(this.lvUsers);
            this.tpUsers.Controls.Add(this.pnlActions);
            this.tpUsers.Location = new System.Drawing.Point(4, 30);
            this.tpUsers.Name = "tpUsers";
            this.tpUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tpUsers.Size = new System.Drawing.Size(832, 494);
            this.tpUsers.TabIndex = 0;
            this.tpUsers.Text = "Users";
            this.tpUsers.UseVisualStyleBackColor = true;
            // 
            // lvUsers
            // 
            this.lvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chGroups});
            this.lvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvUsers.FullRowSelect = true;
            this.lvUsers.GridLines = true;
            this.lvUsers.Location = new System.Drawing.Point(3, 3);
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.Size = new System.Drawing.Size(826, 433);
            this.lvUsers.TabIndex = 1;
            this.lvUsers.UseCompatibleStateImageBehavior = false;
            this.lvUsers.View = System.Windows.Forms.View.Details;
            this.lvUsers.DoubleClick += new System.EventHandler(this.lvUsers_DoubleClick);
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 442;
            // 
            // chGroups
            // 
            this.chGroups.Text = "Groups";
            this.chGroups.Width = 360;
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.Transparent;
            this.pnlActions.Controls.Add(this.btnUserAdd);
            this.pnlActions.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.DoubleBuffered = true;
            this.pnlActions.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlActions.ForeColor = System.Drawing.Color.Black;
            this.pnlActions.Location = new System.Drawing.Point(3, 436);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.OwnStyle = false;
            this.pnlActions.Size = new System.Drawing.Size(826, 55);
            this.pnlActions.TabIndex = 0;
            // 
            // btnUserAdd
            // 
            this.btnUserAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserAdd.Location = new System.Drawing.Point(699, 6);
            this.btnUserAdd.Name = "btnUserAdd";
            this.btnUserAdd.Selected = false;
            this.btnUserAdd.Size = new System.Drawing.Size(124, 46);
            this.btnUserAdd.TabIndex = 0;
            this.btnUserAdd.Text = "Add";
            this.btnUserAdd.UseVisualStyleBackColor = true;
            this.btnUserAdd.Click += new System.EventHandler(this.btnUserAdd_Click);
            // 
            // tpGroups
            // 
            this.tpGroups.Controls.Add(this.lvGroups);
            this.tpGroups.Controls.Add(this.wpPanel1);
            this.tpGroups.Location = new System.Drawing.Point(4, 30);
            this.tpGroups.Name = "tpGroups";
            this.tpGroups.Padding = new System.Windows.Forms.Padding(3);
            this.tpGroups.Size = new System.Drawing.Size(832, 494);
            this.tpGroups.TabIndex = 1;
            this.tpGroups.Text = "Groups";
            this.tpGroups.UseVisualStyleBackColor = true;
            // 
            // lvGroups
            // 
            this.lvGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chGroupName,
            this.chGroupUsers});
            this.lvGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvGroups.FullRowSelect = true;
            this.lvGroups.GridLines = true;
            this.lvGroups.Location = new System.Drawing.Point(3, 3);
            this.lvGroups.Name = "lvGroups";
            this.lvGroups.Size = new System.Drawing.Size(826, 433);
            this.lvGroups.TabIndex = 3;
            this.lvGroups.UseCompatibleStateImageBehavior = false;
            this.lvGroups.View = System.Windows.Forms.View.Details;
            this.lvGroups.DoubleClick += new System.EventHandler(this.lvGroups_DoubleClick);
            // 
            // chGroupName
            // 
            this.chGroupName.Text = "Name";
            this.chGroupName.Width = 442;
            // 
            // chGroupUsers
            // 
            this.chGroupUsers.Text = "Users";
            this.chGroupUsers.Width = 360;
            // 
            // wpPanel1
            // 
            this.wpPanel1.BackColor = System.Drawing.Color.Transparent;
            this.wpPanel1.Controls.Add(this.btnAddGroup);
            this.wpPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.wpPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.wpPanel1.DoubleBuffered = true;
            this.wpPanel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.wpPanel1.ForeColor = System.Drawing.Color.Black;
            this.wpPanel1.Location = new System.Drawing.Point(3, 436);
            this.wpPanel1.Name = "wpPanel1";
            this.wpPanel1.OwnStyle = false;
            this.wpPanel1.Size = new System.Drawing.Size(826, 55);
            this.wpPanel1.TabIndex = 2;
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddGroup.Location = new System.Drawing.Point(699, 6);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Selected = false;
            this.btnAddGroup.Size = new System.Drawing.Size(124, 46);
            this.btnAddGroup.TabIndex = 0;
            this.btnAddGroup.Text = "Add";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // tpProjects
            // 
            this.tpProjects.Controls.Add(this.pnlIterațions);
            this.tpProjects.Controls.Add(this.pnlProjects);
            this.tpProjects.Location = new System.Drawing.Point(4, 30);
            this.tpProjects.Name = "tpProjects";
            this.tpProjects.Padding = new System.Windows.Forms.Padding(3);
            this.tpProjects.Size = new System.Drawing.Size(832, 494);
            this.tpProjects.TabIndex = 2;
            this.tpProjects.Text = "Projects";
            this.tpProjects.UseVisualStyleBackColor = true;
            // 
            // pnlIterațions
            // 
            this.pnlIterațions.BackColor = System.Drawing.Color.Transparent;
            this.pnlIterațions.Controls.Add(this.tvSprings);
            this.pnlIterațions.Controls.Add(this.wpPanel2);
            this.pnlIterațions.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlIterațions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlIterațions.DoubleBuffered = true;
            this.pnlIterațions.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlIterațions.ForeColor = System.Drawing.Color.Black;
            this.pnlIterațions.Location = new System.Drawing.Point(248, 3);
            this.pnlIterațions.Name = "pnlIterațions";
            this.pnlIterațions.OwnStyle = false;
            this.pnlIterațions.Size = new System.Drawing.Size(581, 488);
            this.pnlIterațions.TabIndex = 1;
            // 
            // tvSprings
            // 
            this.tvSprings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSprings.FullRowSelect = true;
            this.tvSprings.Location = new System.Drawing.Point(0, 0);
            this.tvSprings.Name = "tvSprings";
            this.tvSprings.Size = new System.Drawing.Size(581, 433);
            this.tvSprings.TabIndex = 0;
            this.tvSprings.DoubleClick += new System.EventHandler(this.tvSprings_DoubleClick);
            // 
            // pnlProjects
            // 
            this.pnlProjects.BackColor = System.Drawing.Color.Transparent;
            this.pnlProjects.Controls.Add(this.lvProjects);
            this.pnlProjects.Controls.Add(this.wpPanel3);
            this.pnlProjects.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlProjects.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlProjects.DoubleBuffered = true;
            this.pnlProjects.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlProjects.ForeColor = System.Drawing.Color.Black;
            this.pnlProjects.Location = new System.Drawing.Point(3, 3);
            this.pnlProjects.Name = "pnlProjects";
            this.pnlProjects.OwnStyle = false;
            this.pnlProjects.Size = new System.Drawing.Size(245, 488);
            this.pnlProjects.TabIndex = 0;
            // 
            // lvProjects
            // 
            this.lvProjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chProjects});
            this.lvProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProjects.FullRowSelect = true;
            this.lvProjects.GridLines = true;
            this.lvProjects.Location = new System.Drawing.Point(0, 0);
            this.lvProjects.MultiSelect = false;
            this.lvProjects.Name = "lvProjects";
            this.lvProjects.Size = new System.Drawing.Size(245, 433);
            this.lvProjects.TabIndex = 0;
            this.lvProjects.UseCompatibleStateImageBehavior = false;
            this.lvProjects.View = System.Windows.Forms.View.Details;
            this.lvProjects.Click += new System.EventHandler(this.lvProjects_Click);
            this.lvProjects.DoubleClick += new System.EventHandler(this.lvProjects_DoubleClick);
            // 
            // chProjects
            // 
            this.chProjects.Text = "Projects";
            this.chProjects.Width = 235;
            // 
            // wpPanel2
            // 
            this.wpPanel2.BackColor = System.Drawing.Color.Transparent;
            this.wpPanel2.Controls.Add(this.btnAddSpring);
            this.wpPanel2.Controls.Add(this.wpButton1);
            this.wpPanel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.wpPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.wpPanel2.DoubleBuffered = true;
            this.wpPanel2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.wpPanel2.ForeColor = System.Drawing.Color.Black;
            this.wpPanel2.Location = new System.Drawing.Point(0, 433);
            this.wpPanel2.Name = "wpPanel2";
            this.wpPanel2.OwnStyle = false;
            this.wpPanel2.Size = new System.Drawing.Size(581, 55);
            this.wpPanel2.TabIndex = 1;
            // 
            // wpButton1
            // 
            this.wpButton1.Location = new System.Drawing.Point(699, 6);
            this.wpButton1.Name = "wpButton1";
            this.wpButton1.Selected = false;
            this.wpButton1.Size = new System.Drawing.Size(124, 46);
            this.wpButton1.TabIndex = 0;
            this.wpButton1.Text = "Add";
            this.wpButton1.UseVisualStyleBackColor = true;
            // 
            // btnAddSpring
            // 
            this.btnAddSpring.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSpring.Location = new System.Drawing.Point(454, 6);
            this.btnAddSpring.Name = "btnAddSpring";
            this.btnAddSpring.Selected = false;
            this.btnAddSpring.Size = new System.Drawing.Size(124, 46);
            this.btnAddSpring.TabIndex = 1;
            this.btnAddSpring.Text = "Add";
            this.btnAddSpring.UseVisualStyleBackColor = true;
            this.btnAddSpring.Click += new System.EventHandler(this.btnAddSpring_Click);
            // 
            // wpPanel3
            // 
            this.wpPanel3.BackColor = System.Drawing.Color.Transparent;
            this.wpPanel3.Controls.Add(this.btnAddProject);
            this.wpPanel3.Controls.Add(this.wpButton2);
            this.wpPanel3.Controls.Add(this.wpButton3);
            this.wpPanel3.Cursor = System.Windows.Forms.Cursors.Default;
            this.wpPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.wpPanel3.DoubleBuffered = true;
            this.wpPanel3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.wpPanel3.ForeColor = System.Drawing.Color.Black;
            this.wpPanel3.Location = new System.Drawing.Point(0, 433);
            this.wpPanel3.Name = "wpPanel3";
            this.wpPanel3.OwnStyle = false;
            this.wpPanel3.Size = new System.Drawing.Size(245, 55);
            this.wpPanel3.TabIndex = 2;
            // 
            // wpButton2
            // 
            this.wpButton2.Location = new System.Drawing.Point(454, 6);
            this.wpButton2.Name = "wpButton2";
            this.wpButton2.Selected = false;
            this.wpButton2.Size = new System.Drawing.Size(124, 46);
            this.wpButton2.TabIndex = 1;
            this.wpButton2.Text = "Add";
            this.wpButton2.UseVisualStyleBackColor = true;
            // 
            // wpButton3
            // 
            this.wpButton3.Location = new System.Drawing.Point(699, 6);
            this.wpButton3.Name = "wpButton3";
            this.wpButton3.Selected = false;
            this.wpButton3.Size = new System.Drawing.Size(124, 46);
            this.wpButton3.TabIndex = 0;
            this.wpButton3.Text = "Add";
            this.wpButton3.UseVisualStyleBackColor = true;
            // 
            // btnAddProject
            // 
            this.btnAddProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddProject.Location = new System.Drawing.Point(115, 6);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Selected = false;
            this.btnAddProject.Size = new System.Drawing.Size(124, 46);
            this.btnAddProject.TabIndex = 2;
            this.btnAddProject.Text = "Add";
            this.btnAddProject.UseVisualStyleBackColor = true;
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // ctrlAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcMain);
            this.Name = "ctrlAdmin";
            this.Size = new System.Drawing.Size(840, 528);
            this.tcMain.ResumeLayout(false);
            this.tpUsers.ResumeLayout(false);
            this.pnlActions.ResumeLayout(false);
            this.tpGroups.ResumeLayout(false);
            this.wpPanel1.ResumeLayout(false);
            this.tpProjects.ResumeLayout(false);
            this.pnlIterațions.ResumeLayout(false);
            this.pnlProjects.ResumeLayout(false);
            this.wpPanel2.ResumeLayout(false);
            this.wpPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpUsers;
        private System.Windows.Forms.TabPage tpGroups;
        private System.Windows.Forms.TabPage tpProjects;
        private UiLibrary.Controls.WpPanel pnlActions;
        private System.Windows.Forms.ListView lvUsers;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chGroups;
        private UiLibrary.Controls.WpButton btnUserAdd;
        private System.Windows.Forms.ListView lvGroups;
        private System.Windows.Forms.ColumnHeader chGroupName;
        private System.Windows.Forms.ColumnHeader chGroupUsers;
        private UiLibrary.Controls.WpPanel wpPanel1;
        private UiLibrary.Controls.WpButton btnAddGroup;
        private UiLibrary.Controls.WpPanel pnlProjects;
        private UiLibrary.Controls.WpPanel pnlIterațions;
        private System.Windows.Forms.ListView lvProjects;
        private System.Windows.Forms.ColumnHeader chProjects;
        private System.Windows.Forms.TreeView tvSprings;
        private UiLibrary.Controls.WpPanel wpPanel2;
        private UiLibrary.Controls.WpButton btnAddSpring;
        private UiLibrary.Controls.WpButton wpButton1;
        private UiLibrary.Controls.WpPanel wpPanel3;
        private UiLibrary.Controls.WpButton btnAddProject;
        private UiLibrary.Controls.WpButton wpButton2;
        private UiLibrary.Controls.WpButton wpButton3;
    }
}

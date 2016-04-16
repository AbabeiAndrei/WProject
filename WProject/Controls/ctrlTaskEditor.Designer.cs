namespace WProject.Controls
{
    partial class ctrlTaskEditor
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
            System.Windows.Forms.TabPage tpAttachements;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlTaskEditor));
            this.pnlTop = new WProject.UiLibrary.Controls.WpPanel();
            this.btnFullScreen = new WProject.UiLibrary.Controls.WpButton();
            this.txtLeft = new WProject.UiLibrary.Controls.WpTextBox();
            this.nudPriority = new System.Windows.Forms.NumericUpDown();
            this.lblLeft = new WProject.UiLibrary.Controls.WpLabel();
            this.lblPriority = new WProject.UiLibrary.Controls.WpLabel();
            this.ddUser = new WProject.UiLibrary.Controls.WpDropDown();
            this.ddState = new WProject.UiLibrary.Controls.WpDropDown();
            this.btnClose = new WProject.UiLibrary.Controls.WpButton();
            this.txtName = new WProject.UiLibrary.Controls.WpTextBox();
            this.lblTask = new WProject.UiLibrary.Controls.WpLabel();
            this.pnlLeftDock = new WProject.UiLibrary.Controls.WpPanel();
            this.pnlBotom = new WProject.UiLibrary.Controls.WpPanel();
            this.flwActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrint = new WProject.UiLibrary.Controls.WpButton();
            this.btnFollow = new WProject.UiLibrary.Controls.WpButton();
            this.btnRefresh = new WProject.UiLibrary.Controls.WpButton();
            this.btnUndo = new WProject.UiLibrary.Controls.WpButton();
            this.btnSaveAndClose = new WProject.UiLibrary.Controls.WpButton();
            this.btnSave = new WProject.UiLibrary.Controls.WpButton();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.pnlDetails = new WProject.UiLibrary.Controls.WpPanel();
            this.txtDetails = new WProject.UiLibrary.Controls.WpTextEditor();
            this.lblDetails = new WProject.UiLibrary.Controls.WpLabel();
            this.pnlComents = new WProject.UiLibrary.Controls.WpPanel();
            this.ttComents = new WProject.UiLibrary.Controls.WpTextThread();
            this.wpPanel1 = new WProject.UiLibrary.Controls.WpPanel();
            this.tpDetails = new System.Windows.Forms.TabPage();
            this.tpDiscusion = new System.Windows.Forms.TabPage();
            this.ttDiscution = new WProject.UiLibrary.Controls.WpTextThread();
            this.tpHistory = new System.Windows.Forms.TabPage();
            this.tpLinks = new System.Windows.Forms.TabPage();
            this.tpConstraints = new System.Windows.Forms.TabPage();
            this.tpSettings = new System.Windows.Forms.TabPage();
            tpAttachements = new System.Windows.Forms.TabPage();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriority)).BeginInit();
            this.pnlBotom.SuspendLayout();
            this.flwActions.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.pnlComents.SuspendLayout();
            this.tpDiscusion.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpAttachements
            // 
            tpAttachements.Location = new System.Drawing.Point(4, 30);
            tpAttachements.Name = "tpAttachements";
            tpAttachements.Size = new System.Drawing.Size(791, 288);
            tpAttachements.TabIndex = 4;
            tpAttachements.Text = "Attachements";
            tpAttachements.UseVisualStyleBackColor = true;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.Controls.Add(this.btnFullScreen);
            this.pnlTop.Controls.Add(this.txtLeft);
            this.pnlTop.Controls.Add(this.nudPriority);
            this.pnlTop.Controls.Add(this.lblLeft);
            this.pnlTop.Controls.Add(this.lblPriority);
            this.pnlTop.Controls.Add(this.ddUser);
            this.pnlTop.Controls.Add(this.ddState);
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.txtName);
            this.pnlTop.Controls.Add(this.lblTask);
            this.pnlTop.Controls.Add(this.pnlLeftDock);
            this.pnlTop.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.DoubleBuffered = true;
            this.pnlTop.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlTop.ForeColor = System.Drawing.Color.Black;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.OwnStyle = false;
            this.pnlTop.Size = new System.Drawing.Size(799, 87);
            this.pnlTop.TabIndex = 0;
            // 
            // btnFullScreen
            // 
            this.btnFullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFullScreen.FlatAppearance.BorderSize = 0;
            this.btnFullScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFullScreen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFullScreen.Image = global::WProject.Properties.Resources.fullscreen_arrow_s;
            this.btnFullScreen.Location = new System.Drawing.Point(724, 4);
            this.btnFullScreen.Name = "btnFullScreen";
            this.btnFullScreen.Selected = false;
            this.btnFullScreen.Size = new System.Drawing.Size(32, 34);
            this.btnFullScreen.TabIndex = 10;
            this.btnFullScreen.UseVisualStyleBackColor = true;
            // 
            // txtLeft
            // 
            this.txtLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLeft.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeft.LeftButton = null;
            this.txtLeft.Location = new System.Drawing.Point(712, 44);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.ShowClear = false;
            this.txtLeft.Size = new System.Drawing.Size(84, 29);
            this.txtLeft.TabIndex = 9;
            // 
            // nudPriority
            // 
            this.nudPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPriority.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPriority.Location = new System.Drawing.Point(495, 44);
            this.nudPriority.Name = "nudPriority";
            this.nudPriority.Size = new System.Drawing.Size(74, 29);
            this.nudPriority.TabIndex = 8;
            this.nudPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblLeft
            // 
            this.lblLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLeft.AutoSize = true;
            this.lblLeft.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeft.Location = new System.Drawing.Point(575, 47);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Selected = false;
            this.lblLeft.Size = new System.Drawing.Size(104, 21);
            this.lblLeft.Style = null;
            this.lblLeft.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.lblLeft.TabIndex = 7;
            this.lblLeft.Text = "Estimated left";
            // 
            // lblPriority
            // 
            this.lblPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPriority.AutoSize = true;
            this.lblPriority.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriority.Location = new System.Drawing.Point(413, 47);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Selected = false;
            this.lblPriority.Size = new System.Drawing.Size(61, 21);
            this.lblPriority.Style = null;
            this.lblPriority.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.lblPriority.TabIndex = 6;
            this.lblPriority.Text = "Priority";
            // 
            // ddUser
            // 
            this.ddUser.BackColor = System.Drawing.Color.White;
            this.ddUser.Cursor = System.Windows.Forms.Cursors.Default;
            this.ddUser.CustomControl = null;
            this.ddUser.DisplayMember = null;
            this.ddUser.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ddUser.ForeColor = System.Drawing.Color.Black;
            this.ddUser.ImageMember = null;
            this.ddUser.Items = ((System.Collections.Generic.IList<string>)(resources.GetObject("ddUser.Items")));
            this.ddUser.ItemStyle = null;
            this.ddUser.Location = new System.Drawing.Point(182, 48);
            this.ddUser.Name = "ddUser";
            this.ddUser.SelectedIndex = 0;
            this.ddUser.ShowImage = true;
            this.ddUser.Size = new System.Drawing.Size(153, 22);
            this.ddUser.SortMember = null;
            this.ddUser.TabIndex = 5;
            this.ddUser.ValueMember = null;
            // 
            // ddState
            // 
            this.ddState.BackColor = System.Drawing.Color.White;
            this.ddState.Cursor = System.Windows.Forms.Cursors.Default;
            this.ddState.CustomControl = null;
            this.ddState.DisplayMember = null;
            this.ddState.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ddState.ForeColor = System.Drawing.Color.Black;
            this.ddState.ImageMember = null;
            this.ddState.Items = ((System.Collections.Generic.IList<string>)(resources.GetObject("ddState.Items")));
            this.ddState.ItemStyle = null;
            this.ddState.Location = new System.Drawing.Point(26, 48);
            this.ddState.Name = "ddState";
            this.ddState.SelectedIndex = 0;
            this.ddState.ShowImage = false;
            this.ddState.Size = new System.Drawing.Size(153, 22);
            this.ddState.SortMember = null;
            this.ddState.TabIndex = 4;
            this.ddState.ValueMember = null;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::WProject.Properties.Resources.x_s;
            this.btnClose.Location = new System.Drawing.Point(762, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Selected = false;
            this.btnClose.Size = new System.Drawing.Size(32, 34);
            this.btnClose.TabIndex = 3;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.LeftButton = null;
            this.txtName.Location = new System.Drawing.Point(159, 4);
            this.txtName.Name = "txtName";
            this.txtName.ShowClear = false;
            this.txtName.Size = new System.Drawing.Size(559, 29);
            this.txtName.TabIndex = 2;
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTask.Location = new System.Drawing.Point(21, 7);
            this.lblTask.Name = "lblTask";
            this.lblTask.Selected = false;
            this.lblTask.Size = new System.Drawing.Size(59, 21);
            this.lblTask.Style = null;
            this.lblTask.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.lblTask.TabIndex = 1;
            this.lblTask.Text = "TASK 0";
            // 
            // pnlLeftDock
            // 
            this.pnlLeftDock.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeftDock.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlLeftDock.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftDock.DoubleBuffered = true;
            this.pnlLeftDock.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlLeftDock.ForeColor = System.Drawing.Color.Black;
            this.pnlLeftDock.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftDock.Name = "pnlLeftDock";
            this.pnlLeftDock.OwnStyle = false;
            this.pnlLeftDock.Size = new System.Drawing.Size(15, 87);
            this.pnlLeftDock.TabIndex = 0;
            // 
            // pnlBotom
            // 
            this.pnlBotom.BackColor = System.Drawing.Color.Transparent;
            this.pnlBotom.Controls.Add(this.flwActions);
            this.pnlBotom.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlBotom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotom.DoubleBuffered = true;
            this.pnlBotom.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlBotom.ForeColor = System.Drawing.Color.Black;
            this.pnlBotom.Location = new System.Drawing.Point(0, 409);
            this.pnlBotom.Name = "pnlBotom";
            this.pnlBotom.OwnStyle = false;
            this.pnlBotom.Size = new System.Drawing.Size(799, 38);
            this.pnlBotom.TabIndex = 1;
            // 
            // flwActions
            // 
            this.flwActions.Controls.Add(this.btnPrint);
            this.flwActions.Controls.Add(this.btnFollow);
            this.flwActions.Controls.Add(this.btnRefresh);
            this.flwActions.Controls.Add(this.btnUndo);
            this.flwActions.Controls.Add(this.btnSaveAndClose);
            this.flwActions.Controls.Add(this.btnSave);
            this.flwActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.flwActions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flwActions.Location = new System.Drawing.Point(434, 0);
            this.flwActions.Name = "flwActions";
            this.flwActions.Size = new System.Drawing.Size(365, 38);
            this.flwActions.TabIndex = 2;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Gray;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::WProject.Properties.Resources.print_s;
            this.btnPrint.Location = new System.Drawing.Point(327, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Selected = false;
            this.btnPrint.Size = new System.Drawing.Size(35, 30);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnFollow
            // 
            this.btnFollow.BackColor = System.Drawing.Color.Gray;
            this.btnFollow.FlatAppearance.BorderSize = 0;
            this.btnFollow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFollow.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFollow.Image = global::WProject.Properties.Resources.heart_empty_s;
            this.btnFollow.Location = new System.Drawing.Point(286, 3);
            this.btnFollow.Name = "btnFollow";
            this.btnFollow.Selected = false;
            this.btnFollow.Size = new System.Drawing.Size(35, 30);
            this.btnFollow.TabIndex = 4;
            this.btnFollow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFollow.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Gray;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::WProject.Properties.Resources.refresh_s;
            this.btnRefresh.Location = new System.Drawing.Point(245, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Selected = false;
            this.btnRefresh.Size = new System.Drawing.Size(35, 30);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.Gray;
            this.btnUndo.FlatAppearance.BorderSize = 0;
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.Image = global::WProject.Properties.Resources.undo_s;
            this.btnUndo.Location = new System.Drawing.Point(204, 3);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Selected = false;
            this.btnUndo.Size = new System.Drawing.Size(35, 30);
            this.btnUndo.TabIndex = 2;
            this.btnUndo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUndo.UseVisualStyleBackColor = false;
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.BackColor = System.Drawing.Color.Gray;
            this.btnSaveAndClose.FlatAppearance.BorderSize = 0;
            this.btnSaveAndClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAndClose.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndClose.Image = global::WProject.Properties.Resources.save_s;
            this.btnSaveAndClose.Location = new System.Drawing.Point(163, 3);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Selected = false;
            this.btnSaveAndClose.Size = new System.Drawing.Size(35, 30);
            this.btnSaveAndClose.TabIndex = 0;
            this.btnSaveAndClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveAndClose.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Gray;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::WProject.Properties.Resources.save_outline_s;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(82, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Selected = false;
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpGeneral);
            this.tcMain.Controls.Add(this.tpDetails);
            this.tcMain.Controls.Add(this.tpDiscusion);
            this.tcMain.Controls.Add(this.tpHistory);
            this.tcMain.Controls.Add(tpAttachements);
            this.tcMain.Controls.Add(this.tpLinks);
            this.tcMain.Controls.Add(this.tpConstraints);
            this.tcMain.Controls.Add(this.tpSettings);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMain.Location = new System.Drawing.Point(0, 87);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(799, 322);
            this.tcMain.TabIndex = 2;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.pnlDetails);
            this.tpGeneral.Controls.Add(this.pnlComents);
            this.tpGeneral.Controls.Add(this.wpPanel1);
            this.tpGeneral.Location = new System.Drawing.Point(4, 30);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(791, 288);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "General";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.Color.Transparent;
            this.pnlDetails.Controls.Add(this.txtDetails);
            this.pnlDetails.Controls.Add(this.lblDetails);
            this.pnlDetails.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetails.DoubleBuffered = true;
            this.pnlDetails.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlDetails.ForeColor = System.Drawing.Color.Black;
            this.pnlDetails.Location = new System.Drawing.Point(3, 3);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.OwnStyle = false;
            this.pnlDetails.Size = new System.Drawing.Size(459, 282);
            this.pnlDetails.TabIndex = 1;
            // 
            // txtDetails
            // 
            this.txtDetails.AllowImageBiggerThanClient = false;
            this.txtDetails.BackColor = System.Drawing.Color.Transparent;
            this.txtDetails.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetails.ForeColor = System.Drawing.Color.Black;
            this.txtDetails.Location = new System.Drawing.Point(0, 21);
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.OwnStyle = false;
            this.txtDetails.Size = new System.Drawing.Size(459, 261);
            this.txtDetails.TabIndex = 0;
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDetails.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.Location = new System.Drawing.Point(0, 0);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Selected = false;
            this.lblDetails.Size = new System.Drawing.Size(57, 21);
            this.lblDetails.Style = null;
            this.lblDetails.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.lblDetails.TabIndex = 1;
            this.lblDetails.Text = "Details";
            // 
            // pnlComents
            // 
            this.pnlComents.BackColor = System.Drawing.Color.Transparent;
            this.pnlComents.Controls.Add(this.ttComents);
            this.pnlComents.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlComents.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlComents.DoubleBuffered = true;
            this.pnlComents.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlComents.ForeColor = System.Drawing.Color.Black;
            this.pnlComents.Location = new System.Drawing.Point(462, 3);
            this.pnlComents.Name = "pnlComents";
            this.pnlComents.OwnStyle = false;
            this.pnlComents.Size = new System.Drawing.Size(326, 282);
            this.pnlComents.TabIndex = 2;
            // 
            // ttComents
            // 
            this.ttComents.BackColor = System.Drawing.Color.White;
            this.ttComents.Cursor = System.Windows.Forms.Cursors.Default;
            this.ttComents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ttComents.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ttComents.ForeColor = System.Drawing.Color.Black;
            this.ttComents.Location = new System.Drawing.Point(0, 0);
            this.ttComents.Name = "ttComents";
            this.ttComents.OwnStyle = true;
            this.ttComents.ReciveMessageColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.ttComents.ReciveMessageForeColor = System.Drawing.Color.Empty;
            this.ttComents.SendMessageColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.ttComents.SendMessageForeColor = System.Drawing.Color.Empty;
            this.ttComents.Size = new System.Drawing.Size(326, 282);
            this.ttComents.TabIndex = 0;
            // 
            // wpPanel1
            // 
            this.wpPanel1.BackColor = System.Drawing.Color.Transparent;
            this.wpPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.wpPanel1.DoubleBuffered = true;
            this.wpPanel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.wpPanel1.ForeColor = System.Drawing.Color.Black;
            this.wpPanel1.Location = new System.Drawing.Point(-23, -135);
            this.wpPanel1.Name = "wpPanel1";
            this.wpPanel1.OwnStyle = false;
            this.wpPanel1.Size = new System.Drawing.Size(150, 150);
            this.wpPanel1.TabIndex = 0;
            // 
            // tpDetails
            // 
            this.tpDetails.Location = new System.Drawing.Point(4, 30);
            this.tpDetails.Name = "tpDetails";
            this.tpDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tpDetails.Size = new System.Drawing.Size(791, 288);
            this.tpDetails.TabIndex = 1;
            this.tpDetails.Text = "Details";
            this.tpDetails.UseVisualStyleBackColor = true;
            // 
            // tpDiscusion
            // 
            this.tpDiscusion.Controls.Add(this.ttDiscution);
            this.tpDiscusion.Location = new System.Drawing.Point(4, 30);
            this.tpDiscusion.Name = "tpDiscusion";
            this.tpDiscusion.Size = new System.Drawing.Size(791, 288);
            this.tpDiscusion.TabIndex = 2;
            this.tpDiscusion.Text = "Discusion";
            this.tpDiscusion.UseVisualStyleBackColor = true;
            // 
            // ttDiscution
            // 
            this.ttDiscution.BackColor = System.Drawing.Color.Transparent;
            this.ttDiscution.Cursor = System.Windows.Forms.Cursors.Default;
            this.ttDiscution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ttDiscution.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ttDiscution.ForeColor = System.Drawing.Color.Black;
            this.ttDiscution.Location = new System.Drawing.Point(0, 0);
            this.ttDiscution.Name = "ttDiscution";
            this.ttDiscution.OwnStyle = false;
            this.ttDiscution.ReciveMessageColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.ttDiscution.ReciveMessageForeColor = System.Drawing.Color.Empty;
            this.ttDiscution.SendMessageColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.ttDiscution.SendMessageForeColor = System.Drawing.Color.Empty;
            this.ttDiscution.Size = new System.Drawing.Size(791, 288);
            this.ttDiscution.TabIndex = 1;
            // 
            // tpHistory
            // 
            this.tpHistory.Location = new System.Drawing.Point(4, 30);
            this.tpHistory.Name = "tpHistory";
            this.tpHistory.Size = new System.Drawing.Size(791, 288);
            this.tpHistory.TabIndex = 3;
            this.tpHistory.Text = "History";
            this.tpHistory.UseVisualStyleBackColor = true;
            // 
            // tpLinks
            // 
            this.tpLinks.Location = new System.Drawing.Point(4, 30);
            this.tpLinks.Name = "tpLinks";
            this.tpLinks.Size = new System.Drawing.Size(791, 288);
            this.tpLinks.TabIndex = 5;
            this.tpLinks.Text = "Links";
            this.tpLinks.UseVisualStyleBackColor = true;
            // 
            // tpConstraints
            // 
            this.tpConstraints.Location = new System.Drawing.Point(4, 30);
            this.tpConstraints.Name = "tpConstraints";
            this.tpConstraints.Size = new System.Drawing.Size(791, 288);
            this.tpConstraints.TabIndex = 6;
            this.tpConstraints.Text = "Constraints";
            this.tpConstraints.UseVisualStyleBackColor = true;
            // 
            // tpSettings
            // 
            this.tpSettings.Location = new System.Drawing.Point(4, 30);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Size = new System.Drawing.Size(791, 288);
            this.tpSettings.TabIndex = 7;
            this.tpSettings.Text = "Settings";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // ctrlTaskEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.pnlBotom);
            this.Controls.Add(this.pnlTop);
            this.Name = "ctrlTaskEditor";
            this.Size = new System.Drawing.Size(799, 447);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriority)).EndInit();
            this.pnlBotom.ResumeLayout(false);
            this.flwActions.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.pnlComents.ResumeLayout(false);
            this.tpDiscusion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UiLibrary.Controls.WpPanel pnlTop;
        private UiLibrary.Controls.WpPanel pnlLeftDock;
        private UiLibrary.Controls.WpLabel lblTask;
        private UiLibrary.Controls.WpTextBox txtName;
        private UiLibrary.Controls.WpButton btnClose;
        private UiLibrary.Controls.WpDropDown ddState;
        private UiLibrary.Controls.WpDropDown ddUser;
        private System.Windows.Forms.NumericUpDown nudPriority;
        private UiLibrary.Controls.WpLabel lblLeft;
        private UiLibrary.Controls.WpLabel lblPriority;
        private UiLibrary.Controls.WpTextBox txtLeft;
        private UiLibrary.Controls.WpButton btnFullScreen;
        private UiLibrary.Controls.WpPanel pnlBotom;
        private UiLibrary.Controls.WpButton btnSaveAndClose;
        private UiLibrary.Controls.WpButton btnSave;
        private UiLibrary.Controls.WpButton btnRefresh;
        private UiLibrary.Controls.WpButton btnUndo;
        private System.Windows.Forms.FlowLayoutPanel flwActions;
        private UiLibrary.Controls.WpButton btnFollow;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.TabPage tpDetails;
        private UiLibrary.Controls.WpPanel pnlDetails;
        private UiLibrary.Controls.WpPanel wpPanel1;
        private System.Windows.Forms.TabPage tpDiscusion;
        private System.Windows.Forms.TabPage tpHistory;
        private System.Windows.Forms.TabPage tpLinks;
        private System.Windows.Forms.TabPage tpConstraints;
        private System.Windows.Forms.TabPage tpSettings;
        private UiLibrary.Controls.WpPanel pnlComents;
        private UiLibrary.Controls.WpButton btnPrint;
        private UiLibrary.Controls.WpTextEditor txtDetails;
        private UiLibrary.Controls.WpLabel lblDetails;
        private UiLibrary.Controls.WpTextThread ttComents;
        private UiLibrary.Controls.WpTextThread ttDiscution;
    }
}

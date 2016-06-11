using WProject.UiLibrary.Classes;
using WProject.WebApiClasses.Classes;

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
            this.flAttachments = new WProject.UiLibrary.Controls.SpecificControls.WpFileLoader();
            this.pnlTop = new WProject.UiLibrary.Controls.WpPanel();
            this.btnCopy = new WProject.UiLibrary.Controls.WpButton();
            this.btnFullScreen = new WProject.UiLibrary.Controls.WpButton();
            this.txtLeft = new WProject.UiLibrary.Controls.WpTextBox();
            this.nudPriority = new System.Windows.Forms.NumericUpDown();
            this.lblLeft = new WProject.UiLibrary.Controls.WpLabel();
            this.lblPriority = new WProject.UiLibrary.Controls.WpLabel();
            this.ddUser = new WProject.UiLibrary.Controls.WpDropDown<User>();
            this.ddState = new WProject.UiLibrary.Controls.WpDropDown<DictItem>();
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
            this.wpButtonCopy = new WProject.UiLibrary.Controls.WpButton();
            this.btnCopyDiscutionLink = new WProject.UiLibrary.Controls.WpButton();
            this.btnCopyBasicViewLink = new WProject.UiLibrary.Controls.WpButton();
            this.btnCopyEditLink = new WProject.UiLibrary.Controls.WpButton();
            this.btnCopyViewLink = new WProject.UiLibrary.Controls.WpButton();
            this.btnDiscutionGenerate = new WProject.UiLibrary.Controls.WpButton();
            this.btnBasicViewGenerate = new WProject.UiLibrary.Controls.WpButton();
            this.btnEditGenerate = new WProject.UiLibrary.Controls.WpButton();
            this.btnViewGenerate = new WProject.UiLibrary.Controls.WpButton();
            this.txtDiscutionLink = new WProject.UiLibrary.Controls.WpTextBox();
            this.txtBasicViewLink = new WProject.UiLibrary.Controls.WpTextBox();
            this.txtEditLink = new WProject.UiLibrary.Controls.WpTextBox();
            this.chkDiscution = new WProject.UiLibrary.Controls.WpCheckBox();
            this.chkBasicView = new WProject.UiLibrary.Controls.WpCheckBox();
            this.chkEdit = new WProject.UiLibrary.Controls.WpCheckBox();
            this.chkView = new WProject.UiLibrary.Controls.WpCheckBox();
            this.txtViewLink = new WProject.UiLibrary.Controls.WpTextBox();
            this.lvConditions = new System.Windows.Forms.ListView();
            this.chEnable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chConditionItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCondition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            tpAttachements = new System.Windows.Forms.TabPage();
            tpAttachements.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriority)).BeginInit();
            this.pnlBotom.SuspendLayout();
            this.flwActions.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.pnlComents.SuspendLayout();
            this.tpDiscusion.SuspendLayout();
            this.tpHistory.SuspendLayout();
            this.tpLinks.SuspendLayout();
            this.tpConstraints.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpAttachements
            // 
            tpAttachements.Controls.Add(this.flAttachments);
            tpAttachements.Location = new System.Drawing.Point(4, 30);
            tpAttachements.Name = "tpAttachements";
            tpAttachements.Size = new System.Drawing.Size(791, 288);
            tpAttachements.TabIndex = 4;
            tpAttachements.Text = "Attachements";
            tpAttachements.UseVisualStyleBackColor = true;
            // 
            // flAttachments
            // 
            this.flAttachments.BackColor = System.Drawing.Color.Transparent;
            this.flAttachments.Cursor = System.Windows.Forms.Cursors.Default;
            this.flAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flAttachments.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.flAttachments.ForeColor = System.Drawing.Color.Black;
            this.flAttachments.Location = new System.Drawing.Point(0, 0);
            this.flAttachments.Name = "flAttachments";
            this.flAttachments.OwnStyle = false;
            this.flAttachments.ShowCheckAll = false;
            this.flAttachments.ShowDeleteSelected = false;
            this.flAttachments.ShowNumberOfFiles = false;
            this.flAttachments.ShowSaveSelected = false;
            this.flAttachments.ShowUpload = false;
            this.flAttachments.Size = new System.Drawing.Size(791, 288);
            this.flAttachments.TabIndex = 0;
            this.flAttachments.OnFileUploaded += new WProject.UiLibrary.Classes.FileItemEventHandler(this.flAttachments_OnFileUploaded);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.Controls.Add(this.btnCopy);
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
            // btnCopy
            // 
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Image = global::WProject.Properties.Resources.clipboard_s;
            this.btnCopy.Location = new System.Drawing.Point(667, 4);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Selected = false;
            this.btnCopy.Size = new System.Drawing.Size(47, 34);
            this.btnCopy.TabIndex = 11;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.wpButtonCopy_Click);
            // 
            // btnFullScreen
            // 
            this.btnFullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFullScreen.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.btnFullScreen.Click += new System.EventHandler(this.btnFullScreen_Click);
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
            this.ddUser.ItemStyle = null;
            this.ddUser.Location = new System.Drawing.Point(182, 48);
            this.ddUser.Name = "ddUser";
            this.ddUser.SelectedIndex = 0;
            this.ddUser.ShowImage = true;
            this.ddUser.Size = new System.Drawing.Size(176, 22);
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
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.pnlLeftDock.Visible = false;
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
            this.flwActions.Dock = System.Windows.Forms.DockStyle.Left;
            this.flwActions.Location = new System.Drawing.Point(0, 0);
            this.flwActions.Name = "flwActions";
            this.flwActions.Size = new System.Drawing.Size(365, 38);
            this.flwActions.TabIndex = 2;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::WProject.Properties.Resources.print_s;
            this.btnPrint.Location = new System.Drawing.Point(3, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Selected = false;
            this.btnPrint.Size = new System.Drawing.Size(35, 30);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnFollow
            // 
            this.btnFollow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnFollow.FlatAppearance.BorderSize = 0;
            this.btnFollow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFollow.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFollow.Image = global::WProject.Properties.Resources.heart_empty_s;
            this.btnFollow.Location = new System.Drawing.Point(44, 3);
            this.btnFollow.Name = "btnFollow";
            this.btnFollow.Selected = false;
            this.btnFollow.Size = new System.Drawing.Size(35, 30);
            this.btnFollow.TabIndex = 4;
            this.btnFollow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFollow.UseVisualStyleBackColor = false;
            this.btnFollow.Click += new System.EventHandler(this.btnFollow_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::WProject.Properties.Resources.refresh_s;
            this.btnRefresh.Location = new System.Drawing.Point(85, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Selected = false;
            this.btnRefresh.Size = new System.Drawing.Size(35, 30);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnUndo.FlatAppearance.BorderSize = 0;
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.Image = global::WProject.Properties.Resources.undo_s;
            this.btnUndo.Location = new System.Drawing.Point(126, 3);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Selected = false;
            this.btnUndo.Size = new System.Drawing.Size(35, 30);
            this.btnUndo.TabIndex = 2;
            this.btnUndo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnSaveAndClose.FlatAppearance.BorderSize = 0;
            this.btnSaveAndClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAndClose.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndClose.Image = global::WProject.Properties.Resources.save_s;
            this.btnSaveAndClose.Location = new System.Drawing.Point(167, 3);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Selected = false;
            this.btnSaveAndClose.Size = new System.Drawing.Size(35, 30);
            this.btnSaveAndClose.TabIndex = 0;
            this.btnSaveAndClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveAndClose.UseVisualStyleBackColor = false;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::WProject.Properties.Resources.save_outline_s;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(208, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Selected = false;
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.ttComents.OnSend += new WProject.UiLibrary.Classes.SendMessageEventHandler(this.ttComents_OnSend);
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
            this.tpHistory.AutoScroll = true;
            this.tpHistory.Location = new System.Drawing.Point(4, 30);
            this.tpHistory.Name = "tpHistory";
            this.tpHistory.Size = new System.Drawing.Size(791, 288);
            this.tpHistory.TabIndex = 3;
            this.tpHistory.Text = "History";
            this.tpHistory.UseVisualStyleBackColor = true;
            // 
            // tpLinks
            // 
            this.tpLinks.Controls.Add(this.btnCopyDiscutionLink);
            this.tpLinks.Controls.Add(this.btnCopyBasicViewLink);
            this.tpLinks.Controls.Add(this.btnCopyEditLink);
            this.tpLinks.Controls.Add(this.btnCopyViewLink);
            this.tpLinks.Controls.Add(this.btnDiscutionGenerate);
            this.tpLinks.Controls.Add(this.btnBasicViewGenerate);
            this.tpLinks.Controls.Add(this.btnEditGenerate);
            this.tpLinks.Controls.Add(this.btnViewGenerate);
            this.tpLinks.Controls.Add(this.txtDiscutionLink);
            this.tpLinks.Controls.Add(this.txtBasicViewLink);
            this.tpLinks.Controls.Add(this.txtEditLink);
            this.tpLinks.Controls.Add(this.chkDiscution);
            this.tpLinks.Controls.Add(this.chkBasicView);
            this.tpLinks.Controls.Add(this.chkEdit);
            this.tpLinks.Controls.Add(this.chkView);
            this.tpLinks.Controls.Add(this.txtViewLink);
            this.tpLinks.Location = new System.Drawing.Point(4, 30);
            this.tpLinks.Name = "tpLinks";
            this.tpLinks.Size = new System.Drawing.Size(791, 288);
            this.tpLinks.TabIndex = 5;
            this.tpLinks.Text = "Links";
            this.tpLinks.UseVisualStyleBackColor = true;
            // 
            // tpConstraints
            // 
            this.tpConstraints.Controls.Add(this.lvConditions);
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
            // wpButtonCopy
            // 
            this.wpButtonCopy.Cursor = System.Windows.Forms.Cursors.Default;
            this.wpButtonCopy.FlatAppearance.BorderSize = 0;
            this.wpButtonCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wpButtonCopy.Image = global::WProject.Properties.Resources.clipboard_s;
            this.wpButtonCopy.Location = new System.Drawing.Point(525, -1);
            this.wpButtonCopy.Name = "wpButtonCopy";
            this.wpButtonCopy.Selected = false;
            this.wpButtonCopy.Size = new System.Drawing.Size(34, 34);
            this.wpButtonCopy.TabIndex = 0;
            this.wpButtonCopy.UseVisualStyleBackColor = true;
            this.wpButtonCopy.Click += new System.EventHandler(this.wpButtonCopy_Click);
            // 
            // btnCopyDiscutionLink
            // 
            this.btnCopyDiscutionLink.FlatAppearance.BorderSize = 0;
            this.btnCopyDiscutionLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyDiscutionLink.Image = global::WProject.Properties.Resources.clipboard_s;
            this.btnCopyDiscutionLink.Location = new System.Drawing.Point(628, 97);
            this.btnCopyDiscutionLink.Name = "btnCopyDiscutionLink";
            this.btnCopyDiscutionLink.Selected = false;
            this.btnCopyDiscutionLink.Size = new System.Drawing.Size(47, 34);
            this.btnCopyDiscutionLink.TabIndex = 35;
            this.btnCopyDiscutionLink.UseVisualStyleBackColor = true;
            this.btnCopyDiscutionLink.Click += new System.EventHandler(this.btnCopyDiscutionLink_Click);
            // 
            // btnCopyBasicViewLink
            // 
            this.btnCopyBasicViewLink.FlatAppearance.BorderSize = 0;
            this.btnCopyBasicViewLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyBasicViewLink.Image = global::WProject.Properties.Resources.clipboard_s;
            this.btnCopyBasicViewLink.Location = new System.Drawing.Point(628, 65);
            this.btnCopyBasicViewLink.Name = "btnCopyBasicViewLink";
            this.btnCopyBasicViewLink.Selected = false;
            this.btnCopyBasicViewLink.Size = new System.Drawing.Size(47, 34);
            this.btnCopyBasicViewLink.TabIndex = 34;
            this.btnCopyBasicViewLink.UseVisualStyleBackColor = true;
            this.btnCopyBasicViewLink.Click += new System.EventHandler(this.btnCopyBasicViewLink_Click);
            // 
            // btnCopyEditLink
            // 
            this.btnCopyEditLink.FlatAppearance.BorderSize = 0;
            this.btnCopyEditLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyEditLink.Image = global::WProject.Properties.Resources.clipboard_s;
            this.btnCopyEditLink.Location = new System.Drawing.Point(628, 34);
            this.btnCopyEditLink.Name = "btnCopyEditLink";
            this.btnCopyEditLink.Selected = false;
            this.btnCopyEditLink.Size = new System.Drawing.Size(47, 34);
            this.btnCopyEditLink.TabIndex = 33;
            this.btnCopyEditLink.UseVisualStyleBackColor = true;
            this.btnCopyEditLink.Click += new System.EventHandler(this.btnCopyEditLink_Click);
            // 
            // btnCopyViewLink
            // 
            this.btnCopyViewLink.FlatAppearance.BorderSize = 0;
            this.btnCopyViewLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyViewLink.Image = global::WProject.Properties.Resources.clipboard_s;
            this.btnCopyViewLink.Location = new System.Drawing.Point(628, 4);
            this.btnCopyViewLink.Name = "btnCopyViewLink";
            this.btnCopyViewLink.Selected = false;
            this.btnCopyViewLink.Size = new System.Drawing.Size(47, 34);
            this.btnCopyViewLink.TabIndex = 32;
            this.btnCopyViewLink.UseVisualStyleBackColor = true;
            this.btnCopyViewLink.Click += new System.EventHandler(this.btnCopyViewLink_Click);
            // 
            // btnDiscutionGenerate
            // 
            this.btnDiscutionGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnDiscutionGenerate.FlatAppearance.BorderSize = 0;
            this.btnDiscutionGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscutionGenerate.Location = new System.Drawing.Point(681, 100);
            this.btnDiscutionGenerate.Name = "btnDiscutionGenerate";
            this.btnDiscutionGenerate.Selected = false;
            this.btnDiscutionGenerate.Size = new System.Drawing.Size(104, 29);
            this.btnDiscutionGenerate.TabIndex = 31;
            this.btnDiscutionGenerate.Text = "Generate";
            this.btnDiscutionGenerate.UseVisualStyleBackColor = false;
            this.btnDiscutionGenerate.Click += new System.EventHandler(this.btnDiscutionGenerate_Click);
            // 
            // btnBasicViewGenerate
            // 
            this.btnBasicViewGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnBasicViewGenerate.FlatAppearance.BorderSize = 0;
            this.btnBasicViewGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBasicViewGenerate.Location = new System.Drawing.Point(681, 69);
            this.btnBasicViewGenerate.Name = "btnBasicViewGenerate";
            this.btnBasicViewGenerate.Selected = false;
            this.btnBasicViewGenerate.Size = new System.Drawing.Size(104, 29);
            this.btnBasicViewGenerate.TabIndex = 30;
            this.btnBasicViewGenerate.Text = "Generate";
            this.btnBasicViewGenerate.UseVisualStyleBackColor = false;
            this.btnBasicViewGenerate.Click += new System.EventHandler(this.btnBasicViewGenerate_Click);
            // 
            // btnEditGenerate
            // 
            this.btnEditGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnEditGenerate.FlatAppearance.BorderSize = 0;
            this.btnEditGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditGenerate.Location = new System.Drawing.Point(681, 38);
            this.btnEditGenerate.Name = "btnEditGenerate";
            this.btnEditGenerate.Selected = false;
            this.btnEditGenerate.Size = new System.Drawing.Size(104, 29);
            this.btnEditGenerate.TabIndex = 29;
            this.btnEditGenerate.Text = "Generate";
            this.btnEditGenerate.UseVisualStyleBackColor = false;
            this.btnEditGenerate.Click += new System.EventHandler(this.btnEditGenerate_Click);
            // 
            // btnViewGenerate
            // 
            this.btnViewGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnViewGenerate.FlatAppearance.BorderSize = 0;
            this.btnViewGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewGenerate.Location = new System.Drawing.Point(681, 7);
            this.btnViewGenerate.Name = "btnViewGenerate";
            this.btnViewGenerate.Selected = false;
            this.btnViewGenerate.Size = new System.Drawing.Size(104, 29);
            this.btnViewGenerate.TabIndex = 28;
            this.btnViewGenerate.Text = "Generate";
            this.btnViewGenerate.UseVisualStyleBackColor = false;
            this.btnViewGenerate.Click += new System.EventHandler(this.btnViewGenerate_Click);
            // 
            // txtDiscutionLink
            // 
            this.txtDiscutionLink.LeftButton = null;
            this.txtDiscutionLink.Location = new System.Drawing.Point(136, 100);
            this.txtDiscutionLink.Name = "txtDiscutionLink";
            this.txtDiscutionLink.ReadOnly = true;
            this.txtDiscutionLink.ShowClear = false;
            this.txtDiscutionLink.Size = new System.Drawing.Size(539, 29);
            this.txtDiscutionLink.TabIndex = 27;
            // 
            // txtBasicViewLink
            // 
            this.txtBasicViewLink.LeftButton = null;
            this.txtBasicViewLink.Location = new System.Drawing.Point(136, 69);
            this.txtBasicViewLink.Name = "txtBasicViewLink";
            this.txtBasicViewLink.ReadOnly = true;
            this.txtBasicViewLink.ShowClear = false;
            this.txtBasicViewLink.Size = new System.Drawing.Size(539, 29);
            this.txtBasicViewLink.TabIndex = 26;
            // 
            // txtEditLink
            // 
            this.txtEditLink.LeftButton = null;
            this.txtEditLink.Location = new System.Drawing.Point(136, 38);
            this.txtEditLink.Name = "txtEditLink";
            this.txtEditLink.ReadOnly = true;
            this.txtEditLink.ShowClear = false;
            this.txtEditLink.Size = new System.Drawing.Size(539, 29);
            this.txtEditLink.TabIndex = 25;
            // 
            // chkDiscution
            // 
            this.chkDiscution.AutoSize = true;
            this.chkDiscution.Location = new System.Drawing.Point(8, 103);
            this.chkDiscution.Name = "chkDiscution";
            this.chkDiscution.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.chkDiscution.Selected = false;
            this.chkDiscution.Size = new System.Drawing.Size(100, 21);
            this.chkDiscution.Style = null;
            this.chkDiscution.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.chkDiscution.TabIndex = 24;
            this.chkDiscution.Text = "Discution";
            this.chkDiscution.OnCheckChanged += new System.EventHandler(this.chkDiscution_OnCheckChanged);
            // 
            // chkBasicView
            // 
            this.chkBasicView.AutoSize = true;
            this.chkBasicView.Location = new System.Drawing.Point(8, 72);
            this.chkBasicView.Name = "chkBasicView";
            this.chkBasicView.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.chkBasicView.Selected = false;
            this.chkBasicView.Size = new System.Drawing.Size(108, 21);
            this.chkBasicView.Style = null;
            this.chkBasicView.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.chkBasicView.TabIndex = 23;
            this.chkBasicView.Text = "Basic View";
            this.chkBasicView.OnCheckChanged += new System.EventHandler(this.chkBasicView_OnCheckChanged);
            // 
            // chkEdit
            // 
            this.chkEdit.AutoSize = true;
            this.chkEdit.Location = new System.Drawing.Point(8, 41);
            this.chkEdit.Name = "chkEdit";
            this.chkEdit.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.chkEdit.Selected = false;
            this.chkEdit.Size = new System.Drawing.Size(61, 21);
            this.chkEdit.Style = null;
            this.chkEdit.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.chkEdit.TabIndex = 22;
            this.chkEdit.Text = "Edit";
            this.chkEdit.OnCheckChanged += new System.EventHandler(this.chkEdit_OnCheckChanged);
            // 
            // chkView
            // 
            this.chkView.AutoSize = true;
            this.chkView.Location = new System.Drawing.Point(8, 10);
            this.chkView.Name = "chkView";
            this.chkView.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.chkView.Selected = false;
            this.chkView.Size = new System.Drawing.Size(69, 21);
            this.chkView.Style = null;
            this.chkView.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.chkView.TabIndex = 21;
            this.chkView.Text = "View";
            this.chkView.OnCheckChanged += new System.EventHandler(this.chkView_OnCheckChanged);
            // 
            // txtViewLink
            // 
            this.txtViewLink.LeftButton = null;
            this.txtViewLink.Location = new System.Drawing.Point(136, 7);
            this.txtViewLink.Name = "txtViewLink";
            this.txtViewLink.ReadOnly = true;
            this.txtViewLink.ShowClear = false;
            this.txtViewLink.Size = new System.Drawing.Size(539, 29);
            this.txtViewLink.TabIndex = 20;
            // 
            // lvConditions
            // 
            this.lvConditions.AutoArrange = false;
            this.lvConditions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chEnable,
            this.chConditionItem,
            this.chCondition,
            this.chData});
            this.lvConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvConditions.FullRowSelect = true;
            this.lvConditions.GridLines = true;
            this.lvConditions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvConditions.Location = new System.Drawing.Point(0, 0);
            this.lvConditions.MultiSelect = false;
            this.lvConditions.Name = "lvConditions";
            this.lvConditions.Size = new System.Drawing.Size(791, 288);
            this.lvConditions.TabIndex = 0;
            this.lvConditions.UseCompatibleStateImageBehavior = false;
            this.lvConditions.View = System.Windows.Forms.View.Details;
            // 
            // chEnable
            // 
            this.chEnable.Text = "Enable";
            this.chEnable.Width = 97;
            // 
            // chConditionItem
            // 
            this.chConditionItem.Text = "Item";
            this.chConditionItem.Width = 146;
            // 
            // chCondition
            // 
            this.chCondition.Text = "Condition";
            this.chCondition.Width = 304;
            // 
            // chData
            // 
            this.chData.Text = "Data";
            this.chData.Width = 229;
            // 
            // ctrlTaskEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.pnlBotom);
            this.Controls.Add(this.pnlTop);
            this.Name = "ctrlTaskEditor";
            this.Size = new System.Drawing.Size(799, 447);
            tpAttachements.ResumeLayout(false);
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
            this.tpHistory.ResumeLayout(false);
            this.tpLinks.ResumeLayout(false);
            this.tpLinks.PerformLayout();
            this.tpConstraints.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UiLibrary.Controls.WpPanel pnlTop;
        private UiLibrary.Controls.WpPanel pnlLeftDock;
        private UiLibrary.Controls.WpLabel lblTask;
        private UiLibrary.Controls.WpTextBox txtName;
        private UiLibrary.Controls.WpButton btnClose;
        private UiLibrary.Controls.WpDropDown<DictItem> ddState;
        private UiLibrary.Controls.WpDropDown<User> ddUser;
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
        private UiLibrary.Controls.SpecificControls.WpFileLoader flAttachments;
        private UiLibrary.Controls.WpButton wpButtonCopy;
        private UiLibrary.Controls.WpButton btnCopy;
        private UiLibrary.Controls.WpButton btnCopyDiscutionLink;
        private UiLibrary.Controls.WpButton btnCopyBasicViewLink;
        private UiLibrary.Controls.WpButton btnCopyEditLink;
        private UiLibrary.Controls.WpButton btnCopyViewLink;
        private UiLibrary.Controls.WpButton btnDiscutionGenerate;
        private UiLibrary.Controls.WpButton btnBasicViewGenerate;
        private UiLibrary.Controls.WpButton btnEditGenerate;
        private UiLibrary.Controls.WpButton btnViewGenerate;
        private UiLibrary.Controls.WpTextBox txtDiscutionLink;
        private UiLibrary.Controls.WpTextBox txtBasicViewLink;
        private UiLibrary.Controls.WpTextBox txtEditLink;
        private UiLibrary.Controls.WpCheckBox chkDiscution;
        private UiLibrary.Controls.WpCheckBox chkBasicView;
        private UiLibrary.Controls.WpCheckBox chkEdit;
        private UiLibrary.Controls.WpCheckBox chkView;
        private UiLibrary.Controls.WpTextBox txtViewLink;
        private System.Windows.Forms.ListView lvConditions;
        private System.Windows.Forms.ColumnHeader chEnable;
        private System.Windows.Forms.ColumnHeader chConditionItem;
        private System.Windows.Forms.ColumnHeader chCondition;
        private System.Windows.Forms.ColumnHeader chData;
    }
}

namespace WProject.Controls.MainPageControls.DashboardControls
{
    sealed partial class ctrlDashBoardBacklogItem
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
            this.flwDone = new System.Windows.Forms.FlowLayoutPanel();
            this.flwInProgress = new System.Windows.Forms.FlowLayoutPanel();
            this.flwToDo = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddTask = new WProject.UiLibrary.Controls.WpButton();
            this.pbColapse = new WProject.UiLibrary.Controls.WpPictureBox();
            this.SuspendLayout();
            // 
            // flwDone
            // 
            this.flwDone.AllowDrop = true;
            this.flwDone.BackColor = System.Drawing.Color.Transparent;
            this.flwDone.Dock = System.Windows.Forms.DockStyle.Right;
            this.flwDone.Location = new System.Drawing.Point(824, 0);
            this.flwDone.Name = "flwDone";
            this.flwDone.Size = new System.Drawing.Size(200, 60);
            this.flwDone.TabIndex = 2;
            this.flwDone.Tag = "2";
            this.flwDone.Visible = false;
            this.flwDone.DragDrop += new System.Windows.Forms.DragEventHandler(this.flwDragEfect_Drop);
            this.flwDone.DragEnter += new System.Windows.Forms.DragEventHandler(this.flwDragEfect_Enter);
            this.flwDone.DragLeave += new System.EventHandler(this.flwDragEfect_Leave);
            // 
            // flwInProgress
            // 
            this.flwInProgress.AllowDrop = true;
            this.flwInProgress.BackColor = System.Drawing.Color.Transparent;
            this.flwInProgress.Dock = System.Windows.Forms.DockStyle.Right;
            this.flwInProgress.Location = new System.Drawing.Point(624, 0);
            this.flwInProgress.Name = "flwInProgress";
            this.flwInProgress.Size = new System.Drawing.Size(200, 60);
            this.flwInProgress.TabIndex = 1;
            this.flwInProgress.Tag = "1";
            this.flwInProgress.Visible = false;
            this.flwInProgress.DragDrop += new System.Windows.Forms.DragEventHandler(this.flwDragEfect_Drop);
            this.flwInProgress.DragEnter += new System.Windows.Forms.DragEventHandler(this.flwDragEfect_Enter);
            this.flwInProgress.DragLeave += new System.EventHandler(this.flwDragEfect_Leave);
            // 
            // flwToDo
            // 
            this.flwToDo.AllowDrop = true;
            this.flwToDo.BackColor = System.Drawing.Color.Transparent;
            this.flwToDo.Dock = System.Windows.Forms.DockStyle.Right;
            this.flwToDo.Location = new System.Drawing.Point(424, 0);
            this.flwToDo.Name = "flwToDo";
            this.flwToDo.Size = new System.Drawing.Size(200, 60);
            this.flwToDo.TabIndex = 0;
            this.flwToDo.Tag = "0";
            this.flwToDo.Visible = false;
            this.flwToDo.DragDrop += new System.Windows.Forms.DragEventHandler(this.flwDragEfect_Drop);
            this.flwToDo.DragEnter += new System.Windows.Forms.DragEventHandler(this.flwDragEfect_Enter);
            this.flwToDo.DragLeave += new System.EventHandler(this.flwDragEfect_Leave);
            // 
            // btnAddTask
            // 
            this.btnAddTask.FlatAppearance.BorderSize = 0;
            this.btnAddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTask.Image = global::WProject.Properties.Resources.add_w_s;
            this.btnAddTask.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddTask.Location = new System.Drawing.Point(25, 21);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Selected = false;
            this.btnAddTask.Size = new System.Drawing.Size(98, 38);
            this.btnAddTask.TabIndex = 3;
            this.btnAddTask.Text = "ADD";
            this.btnAddTask.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Visible = false;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // pbColapse
            // 
            this.pbColapse.BackColor = System.Drawing.Color.White;
            this.pbColapse.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbColapse.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pbColapse.ForeColor = System.Drawing.Color.Black;
            this.pbColapse.Image = global::WProject.Properties.Resources.expand_m;
            this.pbColapse.Location = new System.Drawing.Point(0, 6);
            this.pbColapse.Name = "pbColapse";
            this.pbColapse.OwnStyle = true;
            this.pbColapse.Size = new System.Drawing.Size(24, 24);
            this.pbColapse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbColapse.TabIndex = 0;
            this.pbColapse.Click += new System.EventHandler(this.pbColapse_Click);
            // 
            // ctrlDashBoardBacklogItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.flwToDo);
            this.Controls.Add(this.flwInProgress);
            this.Controls.Add(this.pbColapse);
            this.Controls.Add(this.flwDone);
            this.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.Name = "ctrlDashBoardBacklogItem";
            this.Size = new System.Drawing.Size(1024, 60);
            this.Load += new System.EventHandler(this.ctrlDashBoardBacklogItem_Load);
            this.SizeChanged += new System.EventHandler(this.ctrlDashBoardBacklogItem_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private UiLibrary.Controls.WpPictureBox pbColapse;
        private System.Windows.Forms.FlowLayoutPanel flwToDo;
        private System.Windows.Forms.FlowLayoutPanel flwDone;
        private System.Windows.Forms.FlowLayoutPanel flwInProgress;
        private UiLibrary.Controls.WpButton btnAddTask;
    }
}

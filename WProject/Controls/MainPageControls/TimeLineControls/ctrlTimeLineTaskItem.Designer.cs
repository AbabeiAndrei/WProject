﻿namespace WProject.Controls.MainPageControls.TimeLineControls
{
    partial class ctrlTimeLineTaskItem
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
            this.SuspendLayout();
            // 
            // ctrlTimeLineTaskItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Direction = WProject.UiLibrary.Controls.ResizeDirection.East;
            this.MoveDirection = WProject.UiLibrary.Controls.MoveDirection.Horizontal;
            this.Name = "ctrlTimeLineTaskItem";
            this.Size = new System.Drawing.Size(150, 26);
            this.AfterResize += new WProject.UiLibrary.Controls.ResizableControl.ControlResizeHandler(this.ctrlTimeLineTaskItem_AfterResize);
            this.AfterMove += new WProject.UiLibrary.Controls.ResizableControl.ControlMovedHandler(this.ctrlTimeLineTaskItem_AfterMove);
            this.BeginResize += new System.EventHandler(this.ctrlTimeLineTaskItem_BeginResize);
            this.BeginMove += new System.EventHandler(this.ctrlTimeLineTaskItem_BeginMove);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

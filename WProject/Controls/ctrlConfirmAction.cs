using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WProject.Controls
{
    public partial class ctrlConfirmAction : UserControl
    {
        #region Properties

        public string TextConfirm
        {
            get
            {
                return lblConfirm.Text;
            }
            set
            {
                lblConfirm.Text = value;
            }
        }

        public string ConfirmKey { get; set; }

        public Action ConfirmAction { get; set; }

        #endregion

        #region Overrides of UserControl

        public override string Text
        {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                lblTitle.Text = value;
            }
        }

        #endregion

        #region Constructors

        public ctrlConfirmAction()
        {
            InitializeComponent();
        }

        #endregion

        #region Event handlers

        private void txtConfirm_TextChanged(object sender, EventArgs e)
        {
            btnConfirm.Visible = txtConfirm.Text == ConfirmKey;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ParentForm?.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtConfirm.Text == ConfirmKey)
                ConfirmAction?.Invoke();

            ParentForm?.Close();
        }

        #endregion

    }
}

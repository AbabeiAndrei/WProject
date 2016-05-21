using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WProject.DesktopUtils
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ofd.ShowDialog(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            var mf = File.ReadAllBytes(txtPath.Text);

            txtData.Text = BitConverter.ToUInt64(mf, 0).ToString("X");/*


            using (MemoryStream ms = new MemoryStream(mf, 0, mf.Length))
            {
                ms.Write(mf, 0, mf.Length);
                ms.Flush();
                txtData.Text = ms.Read(mf, 0, mf.Length).ToString("x*
            }*/
        }

        private void ofd_FileOk(object sender, CancelEventArgs e)
        {
            var mo = sender as OpenFileDialog;

            if(mo == null)
                return;

            if(!File.Exists(mo.FileName))
                return;

            txtPath.Text = mo.FileName;

            try
            {
                pbImage.Image = Image.FromFile(txtPath.Text);
            }
            catch 
            {
                pbImage.Image = null;
            }
        }
    }
}

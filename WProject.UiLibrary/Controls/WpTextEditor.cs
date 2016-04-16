using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using MarkupConverter;
using WProject.GenericLibrary.Helpers.Drawing;
using WProject.UiLibrary.Helpers.GUI;

namespace WProject.UiLibrary.Controls
{
    public partial class WpTextEditor : WpUserControl
    {
        #region Fields

        public static readonly string[] _validImages =
        {
            ".jpeg",
            ".jpg",
            ".png",
            ".ico",
            ".gif",
            ".bmp",
            ".emp",
            ".wmf",
            ".tiff"
        };

        #endregion
        
        #region Properties

        public bool AllowImageBiggerThanClient { get; set; }

        #endregion
        
        #region Constructors

        public WpTextEditor()
        {
            InitializeComponent();
        }

        public WpTextEditor(string text)
            : this()
        {
            Text = text;
        }

        #endregion
        
        #region Overrides of Control

        public override string Text
        {
            get
            {
                return GetText();
            }
            set
            {
                SetText(value);
            }
        }

        public override Font Font
        {
            get
            {
                return rtbText.Font;
            }
            set
            {
                if (rtbText != null)
                    rtbText.Font = value;
            }
        }

        #endregion

        #region Events

        private void WpTextEditor_Load(object sender, EventArgs e)
        {
            rtbText.AutoWordSelection = true;
            rtbText.AutoWordSelection = false;
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            SetFontStyle(FontStyle.Bold);
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            SetFontStyle(FontStyle.Italic);
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            SetFontStyle(FontStyle.Underline);
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            rtbText.SelectionBullet = !rtbText.SelectionBullet;
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
                imageFileDialog.ShowDialog(ParentForm);
            else
                imageFileDialog.ShowDialog();
        }

        private void imageFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (CheckIfImage(imageFileDialog.FileName.ToLower()))
            {
                try
                {
                    var mimg = Image.FromFile(imageFileDialog.FileName);
                    if (!AllowImageBiggerThanClient && mimg.Width > rtbText.Width)
                        mimg = ImageHelper.ResizeImage(mimg, new Size(rtbText.Width, mimg.Height), true);

                    rtbText.InsertImage(mimg);
                }
                catch (Exception mex)
                {
                    if (ParentForm != null)
                        MessageBox.Show(ParentForm, mex.Message);
                    else
                        MessageBox.Show(mex.Message);
                    e.Cancel = true;
                }
            }
            else
            {
                if (ParentForm != null)
                    MessageBox.Show(ParentForm, "Invalid Image File Selected");
                else
                    MessageBox.Show("Invalid Image File Selected");
                e.Cancel = true;
            }
        }

        #endregion

        #region Private methods

        private static bool CheckIfImage(string filename)
        {
            return _validImages.Contains(Path.GetExtension(filename));
        }

        private void SetFontStyle(FontStyle bold)
        {
            FontStyle ms = rtbText.SelectionFont.Style;
            if (rtbText.SelectionFont.Style.HasFlag(bold))
                ms &= ~bold;
            else
                ms |= bold;
            rtbText.SelectionFont = new Font(rtbText.Font, ms);
        }

        private string GetText()
        {
            return RtfToHtmlConverter.ConvertRtfToHtml(rtbText.Rtf);
        }

        private void SetText(string htmlText)
        {
            rtbText.Rtf = HtmlToRtfConverter.ConvertHtmlToRtf(htmlText);
        }

        #endregion

    }
}

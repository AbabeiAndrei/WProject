using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.GenericLibrary.WinApi;
using WProject.Properties;
using WProject.UiLibrary.Controls;
using WProject.UiLibrary.Helpers.GUI;
using WProject.WebApiClasses.Classes;

namespace WProject.Controls.MainPageControls.Task_Editor_Controls
{
    public partial class ctrlTaskHistoryItem : WpUserControl
    {
        #region Fields

        private bool _expanded;

        #endregion

        #region Properties

        public bool Expanded
        {
            get
            {
                return _expanded;
            }
            set
            {
                SetExpand(value);
            }
        }

        #endregion

        #region Constructors

        public ctrlTaskHistoryItem()
        {
            InitializeComponent();

            lblTitle.Text = string.Empty;
        }

        public ctrlTaskHistoryItem(IEnumerable<TaskHistory> changes) 
            : this()
        {
            SetItems(changes);
        }

        #endregion

        #region Events

        private void ctrlTaskHistoryItem_Load(object sender, EventArgs e)
        {
            pbExpandColapse.Image = Resources.expand_m;
            pbExpandColapse.Cursor = Cursors.Hand;
            UXTheme.SetWindowTheme(lvChanges.Handle);
        }

        private void pbExpandColapse_Click(object sender, EventArgs e)
        {
            SetExpand(!_expanded);
        }

        #endregion

        #region Private methods

        private void SetExpand(bool expand)
        {
            _expanded = expand;

            if (expand)
            {
                pbExpandColapse.Image = Resources.tree_m;
                Height = 200;
            }
            else
            {
                pbExpandColapse.Image = Resources.expand_m;
                Height = 32;
            }

            lvChanges.Visible = expand;
        }

        private void SetItems(IEnumerable<TaskHistory> changes)
        {
            if (changes == null)
                return;

            var mchanges = changes as IList<TaskHistory> ?? changes.ToList();

            var mfirst = mchanges.FirstOrDefault();

            if (mfirst == null)
                return;

            lblTitle.Text = mfirst.UpdatedBy?.Name + " made field changes at " + mfirst.UpdatedAt.ToString("G");

            try
            {
                lvChanges.BeginUpdate();

                lvChanges.Items.Clear();

                lvChanges.Items.AddRange(mchanges.Select(CreateListItem).ToArray());

                lvChanges.SetColumnWidth();
            }
            finally
            {
                lvChanges.EndUpdate();
            }
        }

        private ListViewItem CreateListItem(TaskHistory change)
        {
            return new ListViewItem(change.FieldName)
            {
                SubItems =
                {
                    change.NewValue,
                    change.OldValue
                }
            };
        }

        #endregion

    }
}

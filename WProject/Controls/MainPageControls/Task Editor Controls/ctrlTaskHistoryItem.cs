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
using WProject.UiLibrary.Helpers.GUI;
using WProject.WebApiClasses.Classes;

namespace WProject.Controls.MainPageControls.Task_Editor_Controls
{
    public partial class ctrlTaskHistoryItem : UserControl
    {
        private bool _expanded;

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

        public ctrlTaskHistoryItem()
        {
            InitializeComponent();

            lblTitle.Text = string.Empty;
        }

        public ctrlTaskHistoryItem(IEnumerable<TaskHistory> changes)
        {
            SetItems(changes);
        }

        private void ctrlTaskHistoryItem_Load(object sender, EventArgs e)
        {
            pbExpandColapse.Image = Resources.expand_m;
            UXTheme.SetWindowTheme(lvChanges.Handle);
        }

        private void pbExpandColapse_Click(object sender, EventArgs e)
        {
            SetExpand(!_expanded);
        }

        private void SetExpand(bool expand)
        {
            _expanded = expand;

            if(expand)
            {
                pbExpandColapse.Image = Resources.expand_m;
                Height = 32;
            }
            else
            {
                pbExpandColapse.Image = Resources.collapse_m;
                Height = 315;
            }

            lvChanges.Visible = expand;
        }
        
        private void SetItems(IEnumerable<TaskHistory> changes)
        {
            if(changes == null)
                return; 

            var mchanges = changes as IList<TaskHistory> ?? changes.ToList();

            var mfirst = mchanges.FirstOrDefault();

            if(mfirst == null)
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
    }
}

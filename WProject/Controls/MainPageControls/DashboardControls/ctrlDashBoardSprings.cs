using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.Classes;
using WProject.Connection;
using WProject.GenericLibrary.Helpers.Drawing;
using WProject.GenericLibrary.Helpers.Log;
using WProject.GenericLibrary.WinApi;
using WProject.Helpers;
using WProject.Properties;
using WProject.UiLibrary;
using WProject.UiLibrary.Theme;
using WProject.WebApiClasses.Classes;

namespace WProject.Controls.MainPageControls.DashboardControls
{
    public partial class ctrlDashBoardSprings : WpUserControl
    {
        #region Fields

        private static Image _expandImage;

        #endregion

        #region Events

        public event Action<bool> RetractionChanged;

        public event Action<Spring, Category> SelectedSpringOrCategoryChaged;

        #endregion
        
        #region Constructors

        public ctrlDashBoardSprings()
        {
            InitializeComponent();

            pbColapseIcon.Image = Resources.collapse_s;
        }

        static ctrlDashBoardSprings()
        {
            _expandImage = ImageHelper.InvertColors(Resources.expand_s);
        }

        #endregion

        #region Overrides of WpStyledControl

        public override void ApplyStyle()
        {
            base.ApplyStyle();

            if(pbColapseIcon == null)
                return;

            pbColapseIcon.Cursor = Cursors.Hand;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if(tvSprings.Visible)
                    return;

                e.Graphics.DrawString(tvSprings.SelectedNode?.Text ?? string.Empty,
                                      tvSprings.Font,
                                      Brushes.White,
                                      new Point(pbColapseIcon.Left,
                                                pbColapseIcon.Bottom + 4),
                                      WpThemeFonts.VerticalTextAlign);
            }
            finally
            {
                base.OnPaint(e);
            }
        }

        #endregion

        #region Overrides of WpUserControl

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                if(Environment.OSVersion.Version.Major >= 6 )
                    UXTheme.SetWindowTheme(tvSprings.Handle);
            }
            finally
            {
                base.OnLoad(e);
            }
        }

        #endregion
        
        #region Events

        private void pbColapseIcon_Click(object sender, EventArgs e)
        {
            tvSprings.Visible = !tvSprings.Visible;
            if (tvSprings.Visible)
            {
                pbColapseIcon.Image = Resources.collapse_s;
                Width = 250;
                BackColor = Style?.NormalStyle?.BackColor ?? Color.Transparent;
            }
            else
            {
                pbColapseIcon.Image = _expandImage;
                Width = 25;
                BackColor = WpThemeColors.Blue;
            }
            RetractionChanged?.Invoke(tvSprings.Visible);
        }

        private void tvSprings_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var mn = e.Node.Tag;

            if (mn is Spring)
                SelectedSpringOrCategoryChaged?.Invoke(mn as Spring, null);
            else if (mn is Category)
                SelectedSpringOrCategoryChaged?.Invoke(GetTopNode(e.Node).Tag as Spring, mn as Category);
        }

        #endregion

        #region Private methods

        private static TreeNode GetTopNode(TreeNode node) => node.Parent == null ? node : GetTopNode(node.Parent);

        private TreeNode CreateTreeNodeItem(Category category)
        {
            var mn = new TreeNode(category.Name)
            {
                Tag = category
            };

            if (category.SubCategories != null && category.SubCategories.Any())
                foreach (Category mcategory in category.SubCategories
                                                       .Where(mcategory => mcategory.SubCategories != null &&
                                                                           mcategory.SubCategories.Any()))
                    mn.Nodes.AddRange(mcategory.SubCategories
                                               .Select(CreateTreeNodeItem)
                                               .ToArray());

            return mn;
        }

        #endregion

        #region Public methods

        public async System.Threading.Tasks.Task SetProject(Project project)
        {
            if (WPSuite.ConnectedUser == null)
            {
                Logger.Log("SetProject (ctrlDashBoardSprings) - User is null!!");
                await UIHelper.PerformLogout();
                return;
            }

            try
            {
                tvSprings.BeginUpdate();

                tvSprings.AfterSelect -= tvSprings_AfterSelect;

                tvSprings.Nodes.Clear();

                Logger.Log("Get springs for " + project.Name);

                var mres = await WebCallFactory.GetSprings(project.Id, WPSuite.ConnectedUser.Id);

                if (mres.Error)
                    throw mres.Exception;

                foreach (Spring mspring in mres.Springs)
                {
                    var mn = new TreeNode(mspring.Name)
                    {
                        Tag = mspring
                    };
                    if(mspring.Categories != null)
                        mn.Nodes.AddRange(mspring.Categories
                                                 .Select(CreateTreeNodeItem)
                                                 .ToArray());

                    tvSprings.Nodes.Add(mn);
                }

                var msn = tvSprings.Nodes
                                   .Cast<TreeNode>()
                                   .FirstOrDefault(tn => (tn.Tag as Spring)?.Id == Settings.Default.LastSelectedSpringId);


                var mcn = FlattenTree(tvSprings.Nodes
                                               .Cast<TreeNode>())
                                               .FirstOrDefault(tn => (tn.Tag as Category)?.Id == Settings.Default.LastSelectedCategoryId);

                tvSprings.AfterSelect += tvSprings_AfterSelect;

                var mmn = mcn ?? msn ?? tvSprings.Nodes.Cast<TreeNode>().FirstOrDefault();

                if (mmn != null)
                {
                    mmn.EnsureVisible();

                    tvSprings.SelectedNode = mmn;
                }

                UIHelper.HideLoader();
            }
            catch (Exception mex)
            {
                UIHelper.HideLoader();
                UIHelper.ShowError(mex);
            }
            finally
            {
                tvSprings.EndUpdate();
            }
        }

        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        private static IEnumerable<TreeNode> FlattenTree(IEnumerable<TreeNode> nodes)
        {
            return nodes.SelectMany(c => FlattenTree(c.Nodes.Cast<TreeNode>())).Concat(nodes);
        }

        #endregion

    }
}

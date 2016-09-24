using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WProject.Classes;
using WProject.Connection;
using WProject.GenericLibrary.Helpers.Log;
using WProject.Helpers;
using WProject.WebApiClasses.Classes;
using WProject.WebApiClasses.MessanginCenter;
using Task = System.Threading.Tasks.Task;

namespace WProject.Controls.MainPageControls
{
    public partial class ctrlAdmin : MainPageControl
    {
        #region Fields

        private GetAdminDataResponse _data;

        #endregion

        #region Constructors

        public ctrlAdmin()
        {
            InitializeComponent();

            StatusBarVisibility = new StatusBarVisbility
            {
                ShowChatsIcon = false
            };
        }

        #endregion

        #region Implementation of IMainPageControl

        public override Pages Page => Pages.Admin;

        #endregion

        #region Overrides of MainPageControl

        public override StatusBarVisbility StatusBarVisibility { get; }

        public override void SetProject(Project project)
        {

        }

        public async override void OnPageSelected()
        {
            try
            {
                await LoadData();
            }
            finally 
            {
                base.OnPageSelected();
            }
        }

        #endregion

        #region Event handlers

        private void lvProjects_Click(object sender, EventArgs e)
        {
            var mproj = GetSelectedProject();

            if(mproj == null)
                return;

            LoadSprings(_data.Springs.Where(s => s.ProjectId == mproj.Id));
        }

        private void btnUserAdd_Click(object sender, EventArgs e)
        {
            UIHelper.ShowUserEdit(null, async u => await LoadData());
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            UIHelper.ShowGroupEdit(null, async u => await LoadData());
        }

        private void btnAddSpring_Click(object sender, EventArgs e)
        {
            var msel = GetSelectedSpringOrCategory();
            var mproj = GetSelectedProject();

            if(msel == null || mproj == null)
                return;

            UIHelper.ShowSpringEdit(null, 
                                    new Tuple<Project, Spring, Category>(mproj, msel.Item1, msel.Item2), 
                                    async u => await LoadData());
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            UIHelper.ShowProjectEdit(null, async u => await LoadData());
        }

        private void lvUsers_DoubleClick(object sender, EventArgs e)
        {
            var musr = GetSelectedUser();
            if (musr != null)
                UIHelper.ShowUserEdit(musr, async u => await LoadData());
        }

        private void lvGroups_DoubleClick(object sender, EventArgs e)
        {
            var mg = GetSelectedGroup();
            if (mg != null)
                UIHelper.ShowGroupEdit(mg, async u => await LoadData());
        }

        private void lvProjects_DoubleClick(object sender, EventArgs e)
        {
            var mproj = GetSelectedProject();
            if (mproj != null)
                UIHelper.ShowProjectEdit(mproj, async u => await LoadData());
        }

        private void tvSprings_DoubleClick(object sender, EventArgs e)
        {
            var msel = GetSelectedSpringOrCategory();
            if (msel != null)
                UIHelper.ShowSpringEdit(msel,
                                        null,
                                        async u => await LoadData());

        }

        #endregion

        #region Private methods

        private async Task LoadData()
        {
            try
            {
                var mres = await WebCallFactory.GetAdminData();

                if (mres.Error)
                    throw mres.Exception;

                SetData(mres);
            }
            catch (Exception mex)
            {
                Logger.Log(mex);
                UIHelper.ShowError(mex);
            }
        }

        private void SetData(GetAdminDataResponse data)
        {
            _data = data;

            LoadUsers(data.Users);
            LoadGroups(data.Groups);
            LoadProjects(data.Projects);
            //LoadSprings(data.Springs); //la click pe element
        }

        private void LoadUsers(IEnumerable<User> users)
        {
            try
            {
                lvUsers.BeginUpdate();

                lvUsers.Items.Clear();

                lvUsers.Items.AddRange(users.Select(CreateUserRow).ToArray());
            }
            finally
            {
                lvUsers.EndUpdate();
            }
        }

        private ListViewItem CreateUserRow(User user)
        {
            return new ListViewItem(user.Name)
            {
                Tag = user.Id,
                SubItems =
                {
                    string.Join(", ", _data.UserInGroups
                                           .Where(uig => uig.UserId == user.Id)
                                           .Join(_data.Groups, uid => uid.GroupId, g => g.Id, (uid, g) => g)
                                           .GroupBy(g => g.Id)
                                           .Select(g => g.First().Name)
                                           .Take(10))
                }
            };
        }

        private void LoadGroups(IEnumerable<Group> groups)
        {
            try
            {
                lvGroups.BeginUpdate();

                lvGroups.Items.Clear();

                lvGroups.Items.AddRange(groups.Select(CreateGroupRow).ToArray());
            }
            finally
            {
                lvGroups.EndUpdate();
            }
        }

        private ListViewItem CreateGroupRow(Group group)
        {
            return new ListViewItem(group.Name)
            {
                Tag = group.Id,
                SubItems =
                {
                    string.Join(", ", _data.UserInGroups
                                           .Where(uig => uig.UserId == group.Id)
                                           .Join(_data.Users, uid => uid.UserId, u => u.Id, (uid, g) => g)
                                           .GroupBy(g => g.Id)
                                           .Select(g => g.First().Name)
                                           .Take(10))
                }
            };
        }

        private void LoadProjects(IEnumerable<Project> projects)
        {
            try
            {
                lvProjects.BeginUpdate();

                lvProjects.Items.Clear();

                lvProjects.Items.AddRange(projects.Select(CreateProjectRow).ToArray());
            }
            finally
            {
                lvProjects.EndUpdate();
            }
        }

        private ListViewItem CreateProjectRow(Project project)
        {
            return new ListViewItem(project.Name)
            {
                Tag = project.Id
            };
        }

        private void LoadSprings(IEnumerable<Spring> springs)
        {
            try
            {
                tvSprings.BeginUpdate();

                tvSprings.Nodes.Clear();

                foreach (Spring mspring in springs)
                {
                    var mn = new TreeNode(mspring.Name)
                    {
                        Tag = mspring
                    };
                    if (mspring.Categories != null)
                        mn.Nodes.AddRange(mspring.Categories
                                                 .Select(CreateTreeNodeItem)
                                                 .ToArray());

                    tvSprings.Nodes.Add(mn);
                }
            }
            finally
            {
                tvSprings.EndUpdate();
            }
        }

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

        private User GetSelectedUser()
        {
            try
            {
                if (lvUsers.SelectedItems.Count <= 0)
                {
                    UIHelper.ShowError("No user selected");
                    return null;
                }

                var msel = (int)lvUsers.SelectedItems[0].Tag;

                return _data.Users.FirstOrDefault(p => p.Id == msel);

            }
            catch
            {
                return null;
            }
        }

        private Group GetSelectedGroup()
        {
            try
            {
                if (lvGroups.SelectedItems.Count <= 0)
                {
                    UIHelper.ShowError("No group selected");
                    return null;
                }

                var msel = (int)lvGroups.SelectedItems[0].Tag;

                return _data.Groups.FirstOrDefault(p => p.Id == msel);

            }
            catch
            {
                return null;
            }
        }

        private Project GetSelectedProject()
        {
            try
            {
                if (lvProjects.SelectedItems.Count <= 0)
                {
                    UIHelper.ShowError("No project selected");
                    return null;
                }

                var msel = (int)lvProjects.SelectedItems[0].Tag;

                return _data.Projects.FirstOrDefault(p => p.Id == msel);

            }
            catch
            {
                return null;
            }
        }

        private Tuple<Spring, Category> GetSelectedSpringOrCategory()
        {

            try
            {
                if (tvSprings.SelectedNode == null)
                {
                    UIHelper.ShowError("No spring selected");
                    return null;
                }

                var msel = (int)tvSprings.SelectedNode.Tag;

                Spring ms = null;
                Category mc = null;

                if (tvSprings.SelectedNode.Level <= 0)
                    ms = _data.Springs.FirstOrDefault(s => s.Id == msel);
                else
                    mc = _data.Springs.SelectMany(s => s.Categories).FirstOrDefault(c => c.Id == msel);

                return new Tuple<Spring, Category>(ms, mc);

            }
            catch
            {
                return null;
            }
        }


        #endregion
    }
}

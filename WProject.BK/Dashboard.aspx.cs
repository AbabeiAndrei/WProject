using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WProject.DataAccess;
using WProject.GenericLibrary;
using WProject.GenericLibrary.Constants;
using WProject.GenericLibrary.Exceptions;
using WProject.GenericLibrary.Helpers.Extensions;
using WProject.Library.Helpers;
using WProject.Library.Helpers.Utils.Db;
using WProject.UiLibrary.Helpers.GUI;

namespace WProject
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (wpContext mctx = DatabaseFactory.NewDbWpContext)
            {
                if(Suite.SessionUser == null)
                    return;

                tvSprings.Nodes.Clear();

                var mlsprngs = mctx.CreateDetachedCopy(mctx.Springs.ToList());
                var mlsids = mlsprngs.Select(s => s.Id);

                var mlcats = mctx.CreateDetachedCopy(mctx.Categories.Where(c => mlsids.Contains(c.SpringId)).ToList());

                foreach (Spring mspring in mlsprngs)
                {
                    TreeNode mn = new TreeNode(mspring.Name, mspring.Id.ToString());

                    tvSprings.Nodes.Add(mn);

                    TreeViewEx.AddChildsInTreeNode(mn, 
                                                   mlcats.Where(c => c.SpringId == mspring.Id),
                                                   c => c.Id,
                                                   c => c.ParentId,
                                                   null,
                                                   "Name",
                                                   "Id");
                }

                if (tvSprings.Nodes.Count > 0)
                {
                    tvSprings.Nodes[0].Selected = true;
                }
                tvSprings.ExpandAll();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                Cache.Remove(CacheConstants.USER_CACHE);
            }
            catch (Exception mex)
            {
                
            }
            finally
            {
                Server.Transfer("Login.aspx");
            }
        }

        protected void tvSprings_SelectedNodeChanged(object sender, EventArgs e)
        {
            if(tvSprings.SelectedNode == null)
                return;

            int mcp;
            if(!int.TryParse(tvSprings.SelectedValue, out mcp))
                return;

            LoadTaskPage(mcp, tvSprings.SelectedNode.Depth == 0);
        }

        private void LoadTaskPage(int id, bool spring)
        {
            throw new NotImplementedException();
        }
    }
}
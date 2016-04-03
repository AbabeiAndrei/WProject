using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WProject.GenericLibrary.Helpers.Extensions;

namespace WProject.UiLibrary.Helpers.GUI
{
    public static class TreeViewEx
    {
        public static void BindTreeFromList<T, TJ>(TreeView treeView,
                                                   IEnumerable<T> items,
                                                   string displayProperty,
                                                   string valueProperty,
                                                   Func<T, TJ> id,
                                                   Func<T, TJ> parentId,
                                                   TJ defaultParent = default(TJ),
                                                   Action<TreeNode> metaAction = null)
        {
            IList<T> mitems = items as IList<T> ?? items.ToList();

            foreach (T mitem in mitems.Where(i => id(i).Equals(defaultParent)))
            {

                TreeNode mnode = new TreeNode(mitem.GetProperty<string>(displayProperty))
                {
                    Tag = mitem.GetProperty<object>(valueProperty).ToString()
                };

                treeView.Nodes.Add(mnode);

                AddChildsInTreeNode(mnode, mitems, id, parentId, parentId(mitem), displayProperty, valueProperty);
            }
        }

        public static void AddChildsInTreeNode<T, TJ>(TreeNode tn,
                                                       IEnumerable<T> items,
                                                       Func<T, TJ> id,
                                                       Func<T, TJ> parentId,
                                                       TJ parent,
                                                       string displayProperty,
                                                       string valueProperty, 
                                                       Action<TreeNode> metaAction = null)
        {
            IList<T> mitems = items as IList<T> ?? items.ToList();
            foreach (T mitem in mitems.Where(t => parentId(t).Equals(parent)))
            {
                TreeNode mnode = new TreeNode(mitem.GetProperty<string>(displayProperty))
                {
                    Tag = mitem.GetProperty<object>(valueProperty).ToString()
                };

                tn.Nodes.Add(mnode);

                metaAction?.Invoke(mnode);

                AddChildsInTreeNode(mnode, mitems, id, parentId, id(mitem), displayProperty, valueProperty);
            }
        }
    }
}

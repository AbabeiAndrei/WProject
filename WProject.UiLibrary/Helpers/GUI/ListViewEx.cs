using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WProject.UiLibrary.Helpers.GUI
{
    public static class ListViewEx
    {
        public static void SetColumnWidth(this ListView lv)
        {
            foreach (ColumnHeader mcolumn in lv.Columns)
                mcolumn.Width = -2;
        }
    }
}

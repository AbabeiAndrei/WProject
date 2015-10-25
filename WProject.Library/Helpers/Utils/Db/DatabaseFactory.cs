using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.BusinessLibrary;

namespace WProject.Library.Helpers.Utils.Db
{
    public static class DatabaseFactory
    {
        public static WPModel NewDbWpContext => new WPModel();
    }
}

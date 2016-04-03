using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.UiLibrary.Classes
{
    public class OnStartMoveArgs
    {
        public bool Cancel { get; set; }
    }

    public class OnMoveArgs
    {
        public Point OldLocation { get; set; }
        public Point NewLocation { get; set; }
    }

    public class OnEndMoveArgs
    {
        public Point OldLocation { get; set; }
        public Point NewLocation { get; set; }
    }

    public class SelectedItemChangeHandlerArgs
    {
        public int OldSelectedIndex { get; set; }
        public int NewSelectedIndex { get; set; }
    }
}

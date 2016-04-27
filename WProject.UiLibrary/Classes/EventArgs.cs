using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.UiLibrary.Controls.SpecificControls.InnerControls;

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

    public class WpFileItemEventArgs
    {
        public WpFileItem FileItem { get; set; }

        public static implicit operator WpFileItemEventArgs(WpFileItem fileItem)
        {
            return new WpFileItemEventArgs
            {
                FileItem = fileItem
            };
        }
    }

    public class FileItemEventArgs
    {
        public FileItem FileItem { get; set; }

        public static implicit operator FileItemEventArgs(FileItem fileItem)
        {
            return new FileItemEventArgs
            {
                FileItem = fileItem
            };
        }

        public static implicit operator FileItemEventArgs(WpFileItem fileItem)
        {
            return new FileItemEventArgs
            {
                FileItem = fileItem?.File
            };
        }
    }

    public class FullScreenEventArgs
    {
        public bool Handled { get; set; }
    }

    public class SendMessageEventArgs
    {
        public SendMessageEventArgs(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
    }
    
    public delegate void SendMessageEventHandler(object sender, SendMessageEventArgs args);
    public delegate void WpFileItemEventHandler(object sender, WpFileItemEventArgs args);
    public delegate void FileItemEventHandler(object sender, FileItemEventArgs args);
}

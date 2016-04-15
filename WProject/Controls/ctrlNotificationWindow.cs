using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.UiLibrary;
using WProject.UiLibrary.Controls;
using WProject.WebApiClasses.Classes;

namespace WProject.Controls
{
    public partial class ctrlNotificationWindow : WpUserControl
    {
        private List<Notification> _notifications;

        public ReadOnlyCollection<Notification> Notification => _notifications.AsReadOnly();

        public ctrlNotificationWindow()
        {
            InitializeComponent();

            _notifications = new List<Notification>();
        }
    }
}

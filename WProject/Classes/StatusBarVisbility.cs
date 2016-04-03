using System;

namespace WProject.Classes
{
    public class StatusBarVisbility
    {
        public bool Visible { get; set; }
        public bool ShowChatsIcon { get; set; }
        public bool ShowSoundIcon { get; set; }
        public Action OnChatsClick { get; set; }
        public Action OnSoundClick { get; set; }

        public StatusBarVisbility()
        {
            Visible = true;
            ShowChatsIcon = true;
            ShowSoundIcon = true;
        }
    }
}

using System;

namespace WProject.UiLibrary
{
    public interface ISelectableControl
    {
        event SelectedChangedHandler SelectedChanged;
        bool Selected { get; set; }
    }

    public delegate void SelectedChangedHandler(object sender, SelectedChangedHandlerArgs args);

    public class SelectedChangedHandlerArgs
    {
        public bool Selected { get; set; }

        public SelectedChangedHandlerArgs(bool selected)
        {
            Selected = selected;
        }
    }
}

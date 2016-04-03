using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.Controls;
using WProject.Helpers;

namespace WProject.Interfaces
{
    public interface IMainPageControl
    {
        Pages Page { get; }
        bool CanChangeProject { get; }
    }
}

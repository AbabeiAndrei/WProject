using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.Classes;

namespace WProject.Interfaces
{
    public interface IUserPositions
    {
        IEnumerable<UserPosition> Positions { get; }
    }
}

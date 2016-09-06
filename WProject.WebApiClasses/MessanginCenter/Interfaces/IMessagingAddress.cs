using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.WebApiClasses.MessanginCenter
{
    public interface IMessagingAddress
    {
        string ConnectionId { get; }
        string Ip { get; }
    }
}

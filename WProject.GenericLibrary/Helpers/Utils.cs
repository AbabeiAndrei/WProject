using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.GenericLibrary.Helpers
{
    public static class Utils
    {
        public static bool EqualsToAny<T>(T m, params T[] members) where T : IEquatable<T>
        {
            return members.Any(t => t.Equals(m));
        }
    }
}

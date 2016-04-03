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

        public static string MinutesToTime(int minutes)
        {
            var mtime = TimeSpan.FromMinutes(minutes);

            IList<string> mstime = new List<string>();

            if (mtime.Days > 0)
                mstime.Add(mtime.Days + "d");

            if(mtime.Hours > 0)
                mstime.Add(mtime.Hours + "h");

            if (mtime.Minutes > 0)
                mstime.Add(mtime.Minutes+ "m");

            return string.Join(" ", mstime);
        }
    }
}

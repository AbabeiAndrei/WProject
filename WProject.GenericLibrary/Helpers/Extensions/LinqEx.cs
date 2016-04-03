using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.GenericLibrary.Helpers.Extensions
{
    public static class LinqEx
    {
        public static IEnumerable<T> UnionAtStart<T>(this IEnumerable<T> source, IEnumerable<T> items)
        {
            return items.Union(source);
        }
    }
}

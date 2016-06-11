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

        public static IEnumerable<T> InsertAt<T>(this IEnumerable<T> source, T item, int index = 0)
        {
            if(index == 0)
                return source.UnionAtStart(new [] {item});

            var ml = source.ToList();
            ml.Insert(index, item);
            return ml;
        }
    }
}

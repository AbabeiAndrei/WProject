using System;
using System.Collections.Generic;
using System.Linq;

namespace WProject.GenericLibrary.Helpers.Extensions
{
    public class GenericNode<T, TI>
    {
        public TI Id { get; set; }
        public TI ParentId { get; set; }
        public T Parent { get; set; }
        public IEnumerable<T> Childs { get; set; } 
    }
    
    public static class IEnumerableEx
    {
        public static IEnumerable<TJ> GenerateTree<T, TK, TJ>(this IEnumerable<T> items,
                                                              Func<T, TK> idSelector,
                                                              Func<T, TK> parentSelector,
                                                              Func<T, IEnumerable<T>, TJ> outSelector)
        {
            IList<T> mlist = items.ToList();

            ILookup<TK, T> mcl = mlist.ToLookup(parentSelector);

            return mlist.Select(cat => outSelector(cat, mcl[idSelector(cat)]));
        }

        public static IEnumerable<TJ> ToNodeList<T, TJ>(this IEnumerable<T> items,
                                                        Func<T, TJ> outSelector)
        {
            return items.Select(outSelector);
        }
    }
}

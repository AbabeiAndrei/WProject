using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.GenericLibrary.Helpers.Extensions
{
    public static class GeneralExtensions
    {
        public static T If<T>(this bool boolean, T onTrue, T onFalse)
        {
            return boolean ? onTrue : onFalse;
        }

        public static T If<T>(this T obj, Predicate<T> predicate, T onTrue, T onFalse)
        {
            return predicate(obj) ? onTrue : onFalse;
        }

        public static G If<T, G>(this T obj, Predicate<T> predicate, Func<T, G> onTrue, Func<T, G> onFalse)
        {
            return predicate(obj) ? onTrue(obj) : onFalse(obj);
        }

        public static T IsZero<T>(this T obj, T onTrue) where T : struct, IEquatable<T>
        {
            return obj.Equals(default(T)) ? onTrue : obj;
        }
    }
}

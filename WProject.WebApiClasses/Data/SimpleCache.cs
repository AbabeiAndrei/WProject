using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.WebApiClasses.Classes;
using WProject.WebApiClasses.Interfaces;

namespace WProject.WebApiClasses.Data
{
    public static class SimpleCache
    {
        private static readonly IDictionary<string, List<object>> _items;

        static SimpleCache()
        {
            _items = new Dictionary<string, List<object>>();
        }

        public static IList<T> GetAll<T>() where T : TableNameble
        {
            try
            {
                var mlist = GetAll(GetTableName<T>());
                return mlist.Cast<T>() as IList<T> ?? mlist.Cast<T>().ToList();
            }
            catch
            {
                return new List<T>();
            }
        }

        public static IList GetAll(string tableName)
        {
            if (string.IsNullOrEmpty(tableName))
                return new List<TableNameble>();

            if (!_items.ContainsKey(tableName))
                return new List<TableNameble>();

            return _items[tableName] ?? new List<object>();
        }

        public static void SetData<T>(IList<T> data) where T : TableNameble
        {
            SetData(GetTableName<T>(), data as IList);
        }

        public static void SetData(string tableName, IList data)
        {
            if(string.IsNullOrEmpty(tableName))
                return;

            if (_items.ContainsKey(tableName))
                _items[tableName] = data as List<object> ?? data.Cast<object>().ToList();
            else
                _items.Add(tableName, data as List<object> ?? data.Cast<object>().ToList());
        }

        public static void ClearAll(bool dispose = false)
        {
            foreach (var list in _items.Values)
            {
                if(dispose)
                    foreach (IDisposable disposableObject in list.OfType<IDisposable>())
                        disposableObject.Dispose();

                list.Clear();
            }
            
            _items.Clear();
        }

        //todo : fara reflexie
        private static string GetTableName<T>() where T : TableNameble
        {
            return typeof (T).GetProperty("TableName").GetValue(null)?.ToString() ?? string.Empty;
        }

        public static class Util
        {
            public static User GetUserById(int userId)
            {
                return userId != 0 
                        ? GetAll<User>().FirstOrDefault(u => u.Id == userId) 
                        : null;
            }
        }
    }
}

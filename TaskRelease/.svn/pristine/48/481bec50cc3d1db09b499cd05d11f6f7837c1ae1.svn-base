using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SingleTableCRUD
{
    public static class DataTableHelper
    {
        /// <summary>
        /// 将Datatable 转换成IList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static IList<T> ToList<T>(DataTable dt) where T : class ,new()
        {
            var type = typeof(T);
            var pis = type.GetProperties();
            var properties = pis.Where(pi => dt.Columns.IndexOf(pi.Name) > -1);
            var objList = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                var obj = new T();
                properties.ToList().ForEach(p =>
                    {
                        if (row[p.Name] != DBNull.Value)
                        {
                            p.SetValue(obj, row[p.Name], null);
                        }
                    });
                objList.Add(obj);
            }
            return objList;
        }

        /// <summary>
        /// 将dt转换成对应实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static T ToEntity<T>(DataTable dt) where T : class ,new()
        {
            var type = typeof(T);
            var pis = type.GetProperties();
            var propertites = pis.Where(pi => dt.Columns.IndexOf(pi.Name) > -1);
            DataRow row = dt.Rows[0];
            var obj = new T();
            propertites.ToList().ForEach(p =>
            {
                {
                    if (row[p.Name] != DBNull.Value)
                    {
                        p.SetValue(obj, row[p.Name], null);
                    }
                }
            });
            return obj;
        }

    }
}

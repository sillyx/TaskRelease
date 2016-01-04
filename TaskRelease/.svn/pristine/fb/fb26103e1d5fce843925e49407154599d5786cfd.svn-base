using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Linq;
using System.Web.Caching;

namespace TaskRelease.Utility
{
    public static class XmlHelper
    {
        private static string xmlPath = HttpContext.Current.Server.MapPath("/Content/areaCode.xml");


        //添加显示品牌
        public static bool AddCode(string codes)
        {
            XElement xElement = XElement.Load(xmlPath);
            if (string.IsNullOrEmpty(codes))
                return false;
            try
            {
                //添加新数据
                foreach (var item in codes.Split(','))
                    xElement.Add(new XElement("area", new XElement("code", item)));
                xElement.Save(xmlPath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteNode(string codes)
        {
            if (string.IsNullOrEmpty(codes))
                return false;
            XElement xElement = XElement.Load(xmlPath);
            try
            {
                //删除原有数据
                var originalData = from x in xElement.Elements("area")
                                   where codes.Equals(x.Element("code").Value)
                                   select x;
                originalData.Remove();
                xElement.Save(xmlPath);
                return true;
            }
            catch
            {

                return false;
            }
        }

        //缓存依赖
        public static List<string> FindCodes()
        {
            var list = new List<string>();
            var query = HttpRuntime.Cache["areaCode"] as List<string>;
            if (query == null || query.Count == 0)
            {
                XElement xElement = XElement.Load(xmlPath);
                var query_ = from elements in xElement.Elements("area")
                             select new
                             {
                                 id = elements.Element("code").Value
                             };
                if (query_.Count() > 0)
                {
                    foreach (var v in query_)
                    {
                        list.Add(v.id);
                    }
                    HttpRuntime.Cache.Insert("areaCode", list.Distinct(), new CacheDependency(xmlPath));
                }
                return list;
            }
            return query;
        }
    }
}

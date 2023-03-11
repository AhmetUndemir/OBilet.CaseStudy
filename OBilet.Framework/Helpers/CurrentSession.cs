using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OBilet.Framework
{
	public class CurrentSession
	{
        public static string SessionInfo
        {
            get
            {
                return Get("sessionId");
            }
        }
        public static void Set(string key, string value)
        {
            HttpContext.Current.Session[key] = value;
        }

        public static string Get(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                return (string)HttpContext.Current.Session[key];
            }
            return default(string);
        }

        public static void Remove(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                HttpContext.Current.Session.Remove(key);
            }
        }

        public static void Clear()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}

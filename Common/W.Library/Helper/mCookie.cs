using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

namespace W.Library.Helper
{
    public static class mCookie
    {
        private static object o = new object();
        private static string _Domain = null;
        private static Regex _ipRegex = new Regex(@"\d+\.\d+\.\d+\.\d+");
        private static Regex _domainRegex = new Regex(@"[^\.]+(\.com\.cn|\.net\.cn|\.org\.cn|\.gov\.cn|\.com|\.net|\.cn|\.org|\.cc|\.me|\.tel|\.mobi|\.asia|\.biz|\.info|\.name|\.tv|\.hk|\.公司|\.中国|\.网络)", RegexOptions.IgnoreCase);

        /// <summary>
        /// 从URL中获得的Domain，用于Cookie，去除二级子域
        /// </summary>
        public static string Domain
        {
            get
            {
                if (string.IsNullOrEmpty(_Domain))
                {
                    lock (o)
                    {
                        if (string.IsNullOrEmpty(_Domain))
                        {
                            string host = HttpContext.Current.Request.Url.Host;
                            if (string.IsNullOrEmpty(host))
                            {
                                _Domain = null;
                            }
                            else
                            {
                                if (HttpContext.Current.Request.Url.IsLoopback)
                                {
                                    _Domain = null;// +":" + HttpContext.Current.Request.Url.Port;
                                }
                                else
                                {
                                    Match m = _domainRegex.Match(host);
                                    if (m.Success)
                                        _Domain = m.Value;
                                    else
                                        _Domain = null;
                                    //if (HttpContext.Current.Request.Url.Port != 80)
                                    //    _Domain += ":" + HttpContext.Current.Request.Url.Port;
                                }
                            }
                        }
                    }
                }
                return _Domain;
            }
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            if (Domain != null)
                cookie.Domain = Domain;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <param name="expires">过期时间或日期</param>
        public static void WriteCookie(string strName, string strValue, DateTime expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            if (Domain != null)
                cookie.Domain = Domain;
            cookie.Value = strValue;
            cookie.Expires = expires;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
            {
                return HttpContext.Current.Request.Cookies[strName].Value.ToString();
            }

            return string.Empty;
        }

        /// <summary>
        /// 获取cookie对象
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static HttpCookie GetCookieObj(string strName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
            {
                return HttpContext.Current.Request.Cookies[strName];
            }

            return null;
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetCookie(string name, string key)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie == null)
            {
                return null;
            }
            return cookie[key];
        }

        /// <summary>
        /// 读cookie值的域
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetCookieDomain(string name)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie == null)
            {
                return null;
            }
            return cookie.Domain;
        }

        /// <summary>
        /// 读cookie值的超时时间
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static DateTime GetCookieExpires(string name)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie == null)
            {
                return DateTime.MinValue;
            }
            return cookie.Expires;
        }

        /// <summary>
        /// 移除cookie
        /// </summary>
        /// <param name="name">cookie名称</param>
        public static void RemoveCookie(string name)
        {
            RemoveCookie(name, null);
        }

        /// <summary>
        /// 移除cookie
        /// </summary>
        /// <param name="name">cookie名称</param>
        /// <param name="domain">域名</param>
        public static void RemoveCookie(string name, string domain)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie != null)
            {
                cookie.Values.Clear();
                cookie.Expires = DateTime.MinValue;
                if (domain != null)
                {
                    cookie.Domain = domain;
                }
                else
                {
                    if (Domain != null)
                        cookie.Domain = Domain;
                }
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        /// <summary>
        /// 移除cookie的值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="key"></param>
        public static void RemoveCookieValues(string name, string key)
        {
            RemoveCookieValues(name, key, null, new DateTime());
        }

        /// <summary>
        /// 移除cookie的值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="key"></param>
        public static void RemoveCookieValues(string name, string key, DateTime expires)
        {
            RemoveCookieValues(name, key, null, expires);
        }

        /// <summary>
        /// 移除cookie的值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="key"></param>
        public static void RemoveCookieValues(string name, string[] keys, DateTime expires)
        {
            RemoveCookieValues(name, keys, null, expires);
        }

        public static void RemoveCookieValues(string name, string[] keys, string domain)
        {
            RemoveCookieValues(name, keys, domain, new DateTime());
        }

        public static void RemoveCookieValues(string name, string key, string domain)
        {
            RemoveCookieValues(name, key, domain, new DateTime());
        }

        public static void RemoveCookieValues(string name, string[] keys, string domain, DateTime expires)
        {
            if ((name != null) && (keys != null))
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
                if (cookie != null)
                {
                    for (int i = 0; i < keys.Length; i++)
                    {
                        string str = keys[i];
                        if ((str != null) && (str != string.Empty))
                        {
                            cookie.Values.Remove(str);
                        }
                    }
                    if (domain != null)
                    {
                        cookie.Domain = domain;
                    }
                    else
                    {
                        if (Domain != null)
                            cookie.Domain = Domain;
                    }
                    if (expires != new DateTime())
                    {
                        cookie.Expires = expires;
                    }
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
            }
        }

        public static void RemoveCookieValues(string name, string key, string domain, DateTime expires)
        {
            if ((name != null) && (key != null))
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
                if (cookie != null)
                {
                    cookie.Values.Remove(key);
                    if (domain != null)
                    {
                        cookie.Domain = domain;
                    }
                    else
                    {
                        if (Domain != null)
                            cookie.Domain = Domain;
                    }
                    if (expires != new DateTime())
                    {
                        cookie.Expires = expires;
                    }
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
            }
        }

        public static void SetCookie(string name, object value)
        {
            SetCookieValues(name, null, value);
        }

        public static void SetCookie(string name, object value, DateTime expires)
        {
            SetCookieValues(name, (string)null, value, expires);
        }

        public static void SetCookie(string name, object value, string domain)
        {
            SetCookieValues(name, (string)null, value, domain);
        }

        public static void SetCookie(string name, object value, string domain, DateTime expires)
        {
            SetCookieValues(name, null, value, domain, expires);
        }

        public static void SetCookieValues(string name, string[] keys, object[] values)
        {
            SetCookieValues(name, keys, values, null, new DateTime());
        }

        public static void SetCookieValues(string name, string key, object value)
        {
            SetCookieValues(name, key, value, null, new DateTime());
        }

        public static void SetCookieValues(string name, string[] keys, object[] values, DateTime expires)
        {
            SetCookieValues(name, keys, values, null, expires);
        }

        public static void SetCookieValues(string name, string[] keys, object[] values, string domain)
        {
            SetCookieValues(name, keys, values, domain, new DateTime());
        }

        public static void SetCookieValues(string name, string key, object value, DateTime expires)
        {
            SetCookieValues(name, key, value, null, expires);
        }

        public static void SetCookieValues(string name, string key, object value, string domain)
        {
            SetCookieValues(name, key, value, domain, new DateTime());
        }

        public static void SetCookieValues(string name, string key, object value, string domain, DateTime expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(name);
            if (cookie == null)
            {
                cookie = new HttpCookie(name);
            }
            if (value == null)
            {
                value = string.Empty;
            }
            if ((key != null) && (key.Length > 0))
            {
                cookie.Values.Set(key, value.ToString());
            }
            else
            {
                cookie.Value = value.ToString();
            }
            if ((domain != null) && (domain.Length > 0))
            {
                cookie.Domain = domain;
            }
            else
            {
                if (Domain != null)
                    cookie.Domain = Domain;
            }
            if (expires != new DateTime())
            {
                cookie.Expires = expires;
            }
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void SetCookieValues(string name, string[] keys, object[] values, string domain, DateTime expires)
        {
            if (((name != null) && (keys != null)) && (values != null))
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(name);
                if (cookie == null)
                {
                    cookie = new HttpCookie(name);
                }
                int length = keys.Length;
                if (length > values.Length)
                {
                    length = values.Length;
                }
                for (int i = 0; i < length; i++)
                {
                    string str = keys[i];
                    object obj2 = values[i];
                    if ((str != null) && (str != string.Empty))
                    {
                        if (obj2 == null)
                        {
                            obj2 = string.Empty;
                        }
                        cookie.Values.Set(str, obj2.ToString());
                    }
                }
                if ((domain != null) && (domain.Length > 0))
                {
                    cookie.Domain = domain;
                }
                else
                {
                    if (Domain != null)
                        cookie.Domain = Domain;
                }
                if (expires != new DateTime())
                {
                    cookie.Expires = expires;
                }
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

    }
}

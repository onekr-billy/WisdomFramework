using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace W.Library.Helper
{
    public class mUrl
    {
        /// 返回 URL 字符串的编码结果
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>编码结果</returns>
        public static string Encode(string urlToEncode)
        {
            if (string.IsNullOrEmpty(urlToEncode))
            {
                return string.Empty;
            }

            return HttpUtility.UrlEncode(urlToEncode).Replace("'", "%27");
        }

        /// <summary>
        /// 返回 URL 字符串的编码结果
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>解码结果</returns>
        public static string Decode(string urlToDecode)
        {
            if (string.IsNullOrEmpty(urlToDecode))
            {
                return string.Empty;
            }

            return HttpUtility.UrlDecode(urlToDecode).Replace("%2b", "+");
        }

        /// <summary>
        /// Url地址合并
        /// </summary>
        /// <param name="baseUrl">主路径</param>
        /// <param name="relativePath">相对路径</param>
        /// <returns></returns>
        public static string Combine(string baseUrl, string relativePath)
        {
            string combinedUrl = string.Empty;

            if (!string.IsNullOrEmpty(baseUrl) && !string.IsNullOrEmpty(relativePath))
            {
                baseUrl = baseUrl.Replace("\\", "/");
                relativePath = relativePath.Replace("\\", "/");

                if (relativePath.StartsWith("/"))
                {
                    combinedUrl = VirtualPathUtility.RemoveTrailingSlash(baseUrl) + relativePath;
                }
                else
                {
                    combinedUrl = VirtualPathUtility.AppendTrailingSlash(baseUrl) + relativePath;
                }
            }
            else if (!string.IsNullOrEmpty(baseUrl))
            {
                combinedUrl = baseUrl.Replace("\\", "/");
            }

            return combinedUrl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bstr"></param>
        /// <returns></returns>
        public static string UrlEncodeToCapital(string bstr)
        {
            string str = null;
            string[] strArray = null;
            string str2 = null;
            bstr = HttpContext.Current.Server.UrlEncode(bstr);
            strArray = bstr.Split(new char[] { '%' });
            str = strArray[0];
            strArray[0] = null;
            foreach (string str3 in strArray)
            {
                if ((str3 != null) && (str3 != ""))
                {
                    str2 = str3.Substring(0, 2).ToUpper();
                    str = str + "%" + str2 + str3.Substring(2);
                }
            }
            return str;
        }
    }
}

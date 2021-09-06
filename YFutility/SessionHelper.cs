using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace YFUtility
{
    /// <summary>
    /// Session 通用操作类
    /// 1、GetSession(string strSessionName)，读取某个Session对象值，转换为字符串
    /// 2、GetsSession(string strSessionName)，读取某个Session对象值数组，转换为字符串数组
    /// 3、GetSession<T>(string key)，获取Session的T对象
    /// 4、ClearAllSession()，清除所有Session对象
    /// 5、RemoveSession(string strSessionName)，删除一个指定的Session对象
    /// 6、RemoveAllSession()，删除所有Session对象
    /// 7、DeleteSession(string strSessionName)，删除某个Session对象，值设置为null
    /// 8、SetSession(string strSessionName, object val)，从新设置Session对象值
    /// 9、AddSession(string strSessionName, string strValue)，设置Session值，调动有效期为20分钟
    /// 10、AddsSession(string strSessionName, string[] strValues)，设置Session值组，调动有效期为20分钟
    /// 11、AddSession(string strSessionName, string strValue, int iExpires),设置Session值，调动有效期为iExpires分钟
    /// 12、AddsSession(string strSessionName, string[] strValues, int iExpires)，设置Session值组，调动有效期为iExpires分钟
    /// </summary>
    public class SessionHelper
    {
        #region 获取Session信息
        /// <summary>
        /// 读取某个Session对象值，转换为字符串
        /// </summary>
        /// <param name="strSessionName">Session对象名</param>
        /// <returns>Session对象值</returns>
        public static object GetSession(string strSessionName)
        {
            if (HttpContext.Current.Session[strSessionName] == null)
            {
                return null;
            }
            else
            {
                return HttpContext.Current.Session[strSessionName];
            }
        }
        /// <summary>
        /// 读取某个Session对象值数组，转换为字符串数组
        /// </summary>
        /// <param name="strSessionName">Session对象名</param>
        /// <returns>Session对象值数组</returns>
        public static string[] GetsSession(string strSessionName)
        {
            if (HttpContext.Current.Session[strSessionName] == null)
            {
                return null;
            }
            else
            {
                return (string[])HttpContext.Current.Session[strSessionName];
            }
        }
        /// <summary>
        /// 获取Session的T对象
        /// </summary>
        /// <typeparam name="T">T对象</typeparam>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public static T GetSession<T>(string key)
        {
            object obj = GetSession(key);
            return obj == null ? default(T) : (T)obj;
        }
        #endregion
        #region 清除Session信息
        /// <summary>
        /// 清空所有的Session对象
        /// </summary>
        /// <returns></returns>
        public static void ClearAllSession()
        {
            HttpContext.Current.Session.Clear();
        }
        /// <summary>
        /// 删除一个指定的Session对象
        /// </summary>
        /// <param name="name">Session对象名</param>
        /// <returns></returns>
        public static void RemoveSession(string strSessionName)
        {
            HttpContext.Current.Session.Remove(strSessionName);
        }
        /// <summary>
        /// 删除所有的Session对象
        /// </summary>
        /// <returns></returns>
        public static void RemoveAllSession()
        {
            HttpContext.Current.Session.RemoveAll();
        }
        /// <summary>
        /// 删除某个Session对象，值设置为null
        /// </summary>
        /// <param name="strSessionName">Session对象名</param>
        public static void DeleteSession(string strSessionName)
        {
            HttpContext.Current.Session[strSessionName] = null;
        }
        #endregion
        #region 设置Session值信息
        /// <summary>
        /// 从新设置Session对象值
        /// </summary>
        /// <param name="strSessionName">Session对象名</param>
        /// <param name="SessionVal">Session值</param>
        public static void SetSession(string strSessionName, object SessionVal)
        {
            HttpContext.Current.Session.Remove(strSessionName);
            HttpContext.Current.Session.Add(strSessionName, SessionVal);
        }
        /// <summary>
        /// 设置Session值，调动有效期为20分钟
        /// </summary>
        /// <param name="strSessionName">Session对象名</param>
        /// <param name="strValue">Session值</param>
        public static void AddSession(string strSessionName, string strValue)
        {
            HttpContext.Current.Session[strSessionName] = strValue;
            HttpContext.Current.Session.Timeout = 20;
        }
        /// <summary>
        /// 设置Session值组，调动有效期为20分钟
        /// </summary>
        /// <param name="strSessionName">Session对象名</param>
        /// <param name="strValues">Session值数组</param>
        public static void AddsSession(string strSessionName, string[] strValues)
        {
            HttpContext.Current.Session[strSessionName] = strValues;
            HttpContext.Current.Session.Timeout = 20;
        }
        /// <summary>
        /// 设置Session值，调动有效期为iExpires分钟
        /// </summary>
        /// <param name="strSessionName">Session对象名</param>
        /// <param name="strValue">Session值</param>
        /// <param name="iExpires">调动有效期（分钟）</param>
        public static void AddSession(string strSessionName, string strValue, int iExpires)
        {
            HttpContext.Current.Session[strSessionName] = strValue;
            HttpContext.Current.Session.Timeout = iExpires;
        }
        /// <summary>
        /// 设置Session值组，调动有效期为iExpires分钟
        /// </summary>
        /// <param name="strSessionName">Session对象名</param>
        /// <param name="strValues">Session值数组</param>
        /// <param name="iExpires">调动有效期（分钟）</param>
        public static void AddsSession(string strSessionName, string[] strValues, int iExpires)
        {
            HttpContext.Current.Session[strSessionName] = strValues;
            HttpContext.Current.Session.Timeout = iExpires;
        }
        #endregion
    }
}

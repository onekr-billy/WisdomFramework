using Weed;
using W.DataBase;
using System.Collections.Generic;

namespace W.DataBase
{
    /// <summary>
    /// 服务接口
    /// </summary>
    public static class WeedService
    {
        public static bool _EnabledCache = true;
        public static bool _RefurbishCache = true;
        public static ICacheService _UsingCache = null;

        /// <summary>
        /// 获取全局唯一接口
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GET<T>()
        {
            return Addin.Get<T>();
        }

        /// <summary>
        /// 获取一个新的实例接口
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T New<T>()
        {
            return Addin.New<T>();
        }

        public static DList<T> List<T>(List<T> list, int total)
        {
            return new DList<T>(list, total);
        }

        /// <summary>
        /// 缓存总开关
        /// </summary>
        public static bool EnabledCache
        {
            get { return _EnabledCache; }
            set { _EnabledCache = value; }
        }

        /// <summary>
        /// 如果关闭缓存,是否以新数据刷新历史缓存
        /// </summary>
        public static bool RefurbishCache
        {
            get { return _RefurbishCache; }
            set { _RefurbishCache = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static ICacheService UsingCache
        {
            set { _UsingCache = value; }
            get { return _UsingCache; }
        }
    }
}

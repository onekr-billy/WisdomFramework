using System;
using System.Collections.Generic;
using System.Text;

using Weed;
using Weed.Caching;
using W.Service;

namespace SNS.Live
{
    internal class CacheService
    {
        /// <summary>
        /// 默认的缓存配置
        /// </summary>
        static CacheConfig DefaultCache;
        static CacheService()
        {
            if (_G.EnabledCache == false && _G.RefurbishCache == false)
                return;

            DefaultCache = new CacheConfig();

            DefaultCache.Enabled = true;
            DefaultCache.Address = "ch5Live";
            DefaultCache.Port = "11211";
            DefaultCache.MinPoolSize = 10;
            DefaultCache.MaxPoolSize = 100;
            DefaultCache.ConnectionTimeout = 1000;

            COMMONT = Get("Live", "Commont2", 60 * 30, false);           
            
            CHECK_INFO = Get("Live", "Check_INFO2", 60 * 30, false);

            UserExt = Get("Live", "UserExt2", 60 * 30, false);

            Message = Get("Live", "Message2", 60 * 10, false);

            Topic = Get("Live", "Topic2", 60 * 10, false);

            Mall = Get("Mall", "m", 60 * 5, false);

            Snapup = Get("Snapup", "s", 60 * 5, false);

        }

        #region Get(...)
        private static ICacheService Get(string provideName, string keyHead, int defSeconds,bool defAsAspNet)
        {
            if (_G.UsingCache != null)
                return _G.UsingCache;

            CacheConfig cN = CacheAdapter.Get(provideName);

            if (cN == null) //如果不有配置,则默认处理;
            {
                if (defAsAspNet) //如果默认返回AspNet Cache
                    return new AspCache(keyHead, defSeconds, null);
                else
                {

                    CacheConfig cCfg = DefaultCache.Copy();
                    cCfg.Name = provideName;

                    SNS.Live.Service.MemCache temp = new SNS.Live.Service.MemCache(keyHead, defSeconds, cCfg);

                    //如果MemCache实例化成功
                    //
                    if (temp.IsOK)
                        return temp;
                    else //否则直接返回AspNet Cache
                        return new AspCache(keyHead, defSeconds, null);

                }
            }
            else //如要有配置,则按照配置返回缓存
                return cN.CreateService(keyHead, defSeconds);
        }
        #endregion

        /// <summary>
        /// [COMMONT]获取对象及列表信息的缓存
        /// </summary>
        public readonly static ICacheService COMMONT;


        /// <summary>
        /// [FILTER]获取对象及列表信息的缓存
        /// </summary>
        public readonly static ICacheService CHECK_INFO;

        public readonly static ICacheService UserExt;

        public readonly static ICacheService Message;

        public readonly static ICacheService Topic;

        public readonly static ICacheService Mall;

        public readonly static ICacheService Snapup;
    }
}

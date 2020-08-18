using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace ML.Common
{
    public class DataCache
    {

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="CacheKey">缓存的键</param>
        /// <returns></returns>
        public static object GetCache(string CacheKey)
        {
            return HttpRuntime.Cache[CacheKey];
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="CacheKey">缓存的键</param>
        /// <param name="obj">缓存对象</param>
        public static void SetCache(string CacheKey, object obj)
        {
            HttpRuntime.Cache.Insert(CacheKey, obj);
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="CacheKey">缓存的键</param>
        /// <param name="obj">缓存对象</param>
        /// <param name="absoluteExpiration">所插入对象将到期并被从缓存中移除的时间</param>
        /// <param name="slidingExpiration">最后一次访问所插入对象时与该对象到期时之间的时间间隔。如果该值等效于 20 分钟，则对象在最后一次被访问 20 分钟之后将到期并被从缓存中移除</param>
        public static void SetCache(string CacheKey, object obj, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            HttpRuntime.Cache.Insert(CacheKey, obj, null, absoluteExpiration, slidingExpiration);
        }
    }
}

namespace Shove._Web
{
    using System;
    using System.Data;
    using System.Web;
    using System.Web.Caching;

    public class Cache
    {
        public static void ClearCache(string Key)
        {
            ClearCache(HttpContext.Current, Key);
        }

        public static void ClearCache(HttpContext context, string Key)
        {
            Key = "" + Key;
            context.Cache.Remove(Key);
        }

        public static object GetCache(string Key)
        {
            return GetCache(HttpContext.Current, Key);
        }

        public static object GetCache(HttpContext context, string Key)
        {
            Key = "" + Key;
            if (WebConfig.GetAppSettingsInt("CacheSeconds", 0) <= 0)
            {
                context.Cache.Remove(Key);
                return null;
            }
            return context.Cache[Key];
        }

        public static bool GetCacheAsBoolean(string Key, bool Default)
        {
            return GetCacheAsBoolean(HttpContext.Current, Key, Default);
        }

        public static bool GetCacheAsBoolean(HttpContext context, string Key, bool Default)
        {
            object cache = GetCache(context, Key);
            try
            {
                return Convert.ToBoolean(cache);
            }
            catch
            {
                return Default;
            }
        }

        public static DataSet GetCacheAsDataSet(string Key)
        {
            return GetCacheAsDataSet(HttpContext.Current, Key);
        }

        public static DataSet GetCacheAsDataSet(HttpContext context, string Key)
        {
            object cache = GetCache(context, Key);
            try
            {
                return (DataSet) cache;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetCacheAsDataTable(string Key)
        {
            return GetCacheAsDataTable(HttpContext.Current, Key);
        }

        public static DataTable GetCacheAsDataTable(HttpContext context, string Key)
        {
            object cache = GetCache(context, Key);
            try
            {
                return (DataTable) cache;
            }
            catch
            {
                return null;
            }
        }

        public static int GetCacheAsInt(string Key, int Default)
        {
            return GetCacheAsInt(HttpContext.Current, Key, Default);
        }

        public static int GetCacheAsInt(HttpContext context, string Key, int Default)
        {
            object cache = GetCache(context, Key);
            try
            {
                return Convert.ToInt32(cache);
            }
            catch
            {
                return Default;
            }
        }

        public static long GetCacheAsLong(string Key, long Default)
        {
            return GetCacheAsLong(HttpContext.Current, Key, Default);
        }

        public static long GetCacheAsLong(HttpContext context, string Key, long Default)
        {
            object cache = GetCache(context, Key);
            try
            {
                return Convert.ToInt64(cache);
            }
            catch
            {
                return Default;
            }
        }

        public static string GetCacheAsString(string Key, string Default)
        {
            return GetCacheAsString(HttpContext.Current, Key, Default);
        }

        public static string GetCacheAsString(HttpContext context, string Key, string Default)
        {
            object cache = GetCache(context, Key);
            try
            {
                return cache.ToString();
            }
            catch
            {
                return Default;
            }
        }

        public static void SetCache(string Key, object Value)
        {
            SetCache(HttpContext.Current, Key, Value);
        }

        public static void SetCache(string Key, object Value, int CacheSeconds)
        {
            SetCache(HttpContext.Current, Key, Value, CacheSeconds);
        }

        public static void SetCache(HttpContext context, string Key, object Value)
        {
            int appSettingsInt = WebConfig.GetAppSettingsInt("CacheSeconds", 0);
            SetCache(context, Key, Value, appSettingsInt);
        }

        public static void SetCache(HttpContext context, string Key, object Value, int CacheSeconds)
        {
            Key = "" + Key;
            context.Cache.Remove(Key);
            if (CacheSeconds > 0)
            {
                context.Cache.Insert(Key, Value, null, DateTime.Now.AddSeconds((double) CacheSeconds), System.Web.Caching.Cache.NoSlidingExpiration);
            }
        }
    }
}


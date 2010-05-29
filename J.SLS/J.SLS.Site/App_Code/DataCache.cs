using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shove._Web;
using J.SLS.Facade;

public static class DataCache
{
    public static Dictionary<int, int> LotteryEndAheadMinute
    {
        get
        {
            Dictionary<int, int> list = Cache.GetCache("DateCache_LotteryEndAheadMinute") as Dictionary<int, int>;
            if (list == null)
            {
                list = new Dictionary<int, int>();
                LotteryFacade facade = new LotteryFacade();
                foreach (EndAheadMinuteInfo info in facade.GetEndAheadMinuteList())
                {
                    list[info.LotteryId] = info.SystemEndAheadMinute;
                }
                Cache.SetCache("DateCache_LotteryEndAheadMinute", list);
            }
            return list;
        }
    }
}

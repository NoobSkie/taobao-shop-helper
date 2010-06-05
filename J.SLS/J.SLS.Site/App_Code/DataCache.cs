using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shove._Web;
using J.SLS.Facade;

public static class DataCache
{
    public static Dictionary<string, int> LotteryEndAheadMinute
    {
        get
        {
            Dictionary<string, int> list = Cache.GetCache("DateCache_LotteryEndAheadMinute") as Dictionary<string, int>;
            if (list == null)
            {
                list = new Dictionary<string, int>();
                LotteryFacade facade = new LotteryFacade();
                foreach (EndAheadMinuteInfo info in facade.GetEndAheadMinuteList())
                {
                    list[info.GameName] = info.SystemEndAheadMinute;
                }
                Cache.SetCache("DateCache_LotteryEndAheadMinute", list);
            }
            return list;
        }
    }
}

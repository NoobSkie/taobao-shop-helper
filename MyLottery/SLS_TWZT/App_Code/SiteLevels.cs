using System;

public class SiteLevels
{
    public const short MasterSite = 1;
    public const short ShopSite = 4;
    public const short SurrogateAdvSite = 2;
    public const short SurrogateSite = 3;

    public static string GetSiteLevelName(short Level)
    {
        if (Level == 1)
        {
            return "总站";
        }
        if (Level == 2)
        {
            return "总代理";
        }
        if (Level != 3)
        {
            return "网店";
        }
        return "代理";
    }

    public class LevelName
    {
        public const string MasterSite = "总站";
        public const string ShopSite = "网店";
        public const string SurrogateAdvSite = "总代理";
        public const string SurrogateSite = "代理";
    }
}


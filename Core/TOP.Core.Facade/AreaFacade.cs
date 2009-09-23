using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Core.Domain;

namespace TOP.Core.Facade
{
    public class AreaFacade
    {
        private readonly AnalyseData analyser;
        private string currentAppKey, currentAppSecret, currentVersion;

        public AreaFacade(string appKey, string appSecret) : this(appKey, appSecret, "1.0") { }

        public AreaFacade(string appKey, string appSecret, string version)
        {
            currentAppKey = appKey;
            currentAppSecret = appSecret;
            currentVersion = version;

            analyser = new AnalyseData(appKey, appSecret, version);
        }

        #region 地区信息

        /// <summary>
        /// 获取所有地区信息。
        /// </summary>
        public TOPDataList<Area> GetAllAreas()
        {
            string method = "taobao.areas.get";
            Dictionary<string, string> req_params = new Dictionary<string, string>();

            return analyser.RequestTOPDataList<Area>(method, req_params);
        }

        #endregion
    }
}

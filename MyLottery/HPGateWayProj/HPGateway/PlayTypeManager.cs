using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPIssueQueryGateway
{
    /// <summary>
    /// 投注集合
    /// </summary>
    public class PlayTypeManager
    {
        public List<PlayType> PlayTypes = new List<PlayType>();

        public PlayTypeManager()
        {
            this.PlayTypes.Clear();
            this.CreatePlayTypes();
        }

        private void CreatePlayTypes()
        {
            this.PlayTypes.Clear();

            PlayType pType = new PlayType(501, "单式");
            this.PlayTypes.Add(pType);

            pType = new PlayType(502, "复式");
            this.PlayTypes.Add(pType);

            pType = new PlayType(503, "胆拖");
            this.PlayTypes.Add(pType);
        }

        /// <summary>
        /// 根据玩法类型Id得到玩法类型对象
        /// </summary>
        /// <param name="id">玩法类型Id</param>
        /// <returns>类型对象</returns>
        public PlayType GetPlayTypeById(int id)
        {
            foreach (PlayType pt in this.PlayTypes)
                if (pt.ID == id)
                    return pt;
            return null;
        }
    }
}

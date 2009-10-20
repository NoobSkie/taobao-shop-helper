using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TOP.Applications.TaobaoShopHelper.WebControls.Common;

namespace TOP.Applications.TaobaoShopHelper._Common
{
    public interface IInformationPage
    {
        void SetInformationIco(InformationIcoType icoType);

        void SetInformation(List<InformationObject> infoList);

        void SetInformationBoxVisible(bool visible);
    }
}

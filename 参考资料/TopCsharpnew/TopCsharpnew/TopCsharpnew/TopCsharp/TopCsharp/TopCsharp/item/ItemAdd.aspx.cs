using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;


using System.Security.Cryptography;

using System.Collections.Generic;

using System.Net;
using System.IO;
using System.Text;
using Taobao.Top.Api.Util;



namespace TopCsharp.item
{
    public partial class ItemAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btAdd_Click(object sender, EventArgs e)
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;
            HttpPostedFile postedFile = files[0];
            string sessionkey = tbSessionKey.Text;

            if (sessionkey != null)
            {
                Dictionary<string, string> req_params =
                new Dictionary<string, string>();

                //api_key,测试环境中的公共app key
                req_params.Add("api_key", "---------------------APPKEY-----------------------");

                //Secret,测试环境中的公共密钥
                string secret = "--------------------------secret-------------------------";


                //session_key,您的应用无法直接获得用户的session_key，必须由用户主动在您的应用中输入授权码，您的应用通过这个授权码访问淘宝开放平台进而间接获得用户的sessionkey 。
                //获取方法请参考Form2类的getSessionKey方法
                req_params.Add("session", sessionkey);


                //format,输出格式xml或json
                req_params.Add("format", "xml");

                //method,调用的API名称
                req_params.Add("method", "taobao.item.add");

                //timestamp,时间戳
                req_params.Add("timestamp", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));

                //version,请求版本号,请勿更改
                req_params.Add("v", "1.0");

                //API应用级输入参数
                req_params.Add("approve_status", status.Text);

                //API应用级输入参数
                req_params.Add("cid", cid.Text);
                req_params.Add("props", props.Text);
                req_params.Add("num", num.Text);
                req_params.Add("price", price.Text);
                req_params.Add("type", type.Text);
                req_params.Add("stuff_status", stuff.Text);
                req_params.Add("title", title.Text);
                req_params.Add("desc", desc.Text);
                req_params.Add("location.state", state.Text);
                req_params.Add("location.city", city.Text);

                //sign,签名
                string sign = SysUtils.SignTopRequest(req_params, secret);


                req_params.Add("sign", sign);

                //提交：
                //string result=  invokePostAPI(req_params, postedFile);

                string result;
                if (postedFile != null && postedFile.ContentLength > 0)
                {
                    IDictionary<string, FileInfo> fileParams = new Dictionary<string, FileInfo>();
                    FileInfo fileInfo = new FileInfo(postedFile.FileName);
                    fileParams.Add("image", fileInfo);
                    result = WebUtils.DoPost("http://gw.api.taobao.com/router/rest", req_params, fileParams);//测试环境http://gw.sandbox.taobao.com/router/rest
                }
                else
                {
                    result = WebUtils.DoPost("http://gw.api.taobao.com/router/rest", req_params);
                }

                //将返回结果转换
                //DataSet ds = GetResult_DataSet(result);
                textbox.Text = HttpUtility.HtmlEncode(result);
            }
            else
            {
                return;
            }
        }





    }
}

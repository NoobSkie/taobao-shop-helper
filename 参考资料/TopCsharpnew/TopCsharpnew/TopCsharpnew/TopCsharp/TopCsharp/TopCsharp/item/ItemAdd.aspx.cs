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

                //api_key,���Ի����еĹ���app key
                req_params.Add("api_key", "---------------------APPKEY-----------------------");

                //Secret,���Ի����еĹ�����Կ
                string secret = "--------------------------secret-------------------------";


                //session_key,����Ӧ���޷�ֱ�ӻ���û���session_key���������û�����������Ӧ����������Ȩ�룬����Ӧ��ͨ�������Ȩ������Ա�����ƽ̨������ӻ���û���sessionkey ��
                //��ȡ������ο�Form2���getSessionKey����
                req_params.Add("session", sessionkey);


                //format,�����ʽxml��json
                req_params.Add("format", "xml");

                //method,���õ�API����
                req_params.Add("method", "taobao.item.add");

                //timestamp,ʱ���
                req_params.Add("timestamp", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));

                //version,����汾��,�������
                req_params.Add("v", "1.0");

                //APIӦ�ü��������
                req_params.Add("approve_status", status.Text);

                //APIӦ�ü��������
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

                //sign,ǩ��
                string sign = SysUtils.SignTopRequest(req_params, secret);


                req_params.Add("sign", sign);

                //�ύ��
                //string result=  invokePostAPI(req_params, postedFile);

                string result;
                if (postedFile != null && postedFile.ContentLength > 0)
                {
                    IDictionary<string, FileInfo> fileParams = new Dictionary<string, FileInfo>();
                    FileInfo fileInfo = new FileInfo(postedFile.FileName);
                    fileParams.Add("image", fileInfo);
                    result = WebUtils.DoPost("http://gw.api.taobao.com/router/rest", req_params, fileParams);//���Ի���http://gw.sandbox.taobao.com/router/rest
                }
                else
                {
                    result = WebUtils.DoPost("http://gw.api.taobao.com/router/rest", req_params);
                }

                //�����ؽ��ת��
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

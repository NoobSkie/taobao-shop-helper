using System;
using System.Net;
using System.IO;
using System.Text;
using System.Web;

namespace com.yeepay.bank
{
	/// <summary>
	/// ͨѶ����
	/// </summary>
	public abstract class HttpUtils
	{
		public HttpUtils()
		{

		}

		#region ͨѶ����
		/// <summary>
		/// ͨѶ����
		/// </summary>
		/// <param name="url">����Url</param>
		/// <param name="para">�������</param>
		/// <param name="method">����ʽGET/POST</param>
		/// <returns></returns>
		public static string SendRequest(string url, string para, string method)
		{
			string strResult = "";

			if (url == null || url == "")
				return null;

			if (method == null || method == "")
				method = "GET";

			// GET��ʽ
			if (method.ToUpper() == "GET")
			{
				try
				{
					System.Net.WebRequest wrq = System.Net.WebRequest.Create(url + para);
					wrq.Method = "GET";

					System.Net.WebResponse wrp = wrq.GetResponse();
					System.IO.StreamReader sr = new System.IO.StreamReader(wrp.GetResponseStream(), System.Text.Encoding.GetEncoding("gb2312"));

					strResult = sr.ReadToEnd();
				}
				catch (Exception ex)
				{
					return ex.Message;
				}
			}

			// POST��ʽ
			if (method.ToUpper() == "POST")
			{
				if(para.Length > 0 && para.IndexOf('?') == 0)
				{
					para = para.Substring(1);
				}

				WebRequest req = WebRequest.Create(url);
				req.Method = "POST";
				req.ContentType = "application/x-www-form-urlencoded";
				StringBuilder UrlEncoded = new StringBuilder();
				Char[] reserved = { '?', '=', '&' };
				byte[] SomeBytes = null;
				if (para != null)
				{
					int i = 0, j;
					while (i < para.Length)
					{
						j = para.IndexOfAny(reserved, i);
						if (j == -1)
						{
							UrlEncoded.Append(HttpUtility.UrlEncode(para.Substring(i, para.Length - i), System.Text.Encoding.GetEncoding("gb2312")));
							break;
						}
						UrlEncoded.Append(HttpUtility.UrlEncode(para.Substring(i, j - i), System.Text.Encoding.GetEncoding("gb2312")));
						UrlEncoded.Append(para.Substring(j, 1));
						i = j + 1;
					}
					SomeBytes = Encoding.Default.GetBytes(UrlEncoded.ToString());
					req.ContentLength = SomeBytes.Length;
					Stream newStream = req.GetRequestStream();
					newStream.Write(SomeBytes, 0, SomeBytes.Length);
					newStream.Close();
				}
				else
				{
					req.ContentLength = 0;
				}
				try
				{
					WebResponse result = req.GetResponse();
					Stream ReceiveStream = result.GetResponseStream();

					Byte[] read = new Byte[512];
					int bytes = ReceiveStream.Read(read, 0, 512);

					while (bytes > 0)
					{

						// ע�⣺
						// ����ٶ���Ӧʹ�� UTF-8 ��Ϊ���뷽ʽ��
						// ��������� ANSI ����ҳ��ʽ�����磬932�����ͣ���ʹ�������������䣺
						//  Encoding encode = System.Text.Encoding.GetEncoding("shift-jis");
						Encoding encode = System.Text.Encoding.GetEncoding("gb2312");
						strResult += encode.GetString(read, 0, bytes);
						bytes = ReceiveStream.Read(read, 0, 512);
					}

					return strResult;
				}
				catch (Exception ex)
				{
					return ex.Message;
				}
			}
			return strResult;
		}
		#endregion

		#region ��ͨѶ����
		/// <summary>
		/// GET��ʽͨѶ
		/// </summary>
		/// <param name="url"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		public static string SendRequest(string url, string para)
		{
			return SendRequest(url, para, "GET");
		}
		#endregion
	}
}
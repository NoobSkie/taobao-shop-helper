namespace Shove._Web
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    [Serializable]
    public class WebServiceCallResult
    {
        public object[] Additional;
        public string Description;
        public long Result;

        public WebServiceCallResult()
        {
            this.Result = -1L;
            this.Description = "尚未初始化 WebServiceCallResult 的实例";
            this.Additional = null;
        }

        public WebServiceCallResult(long result)
        {
            this.Result = result;
            this.Description = "";
        }

        public WebServiceCallResult(long result, string description)
        {
            this.Result = result;
            this.Description = description;
        }

        public WebServiceCallResult(long result, string description, params object[] additional)
        {
            this.Result = result;
            this.Description = description;
            this.Additional = additional;
        }

        public WebServiceCallResult Deserialize(byte[] Buffer)
        {
            if (Buffer == null)
            {
                return null;
            }
            MemoryStream serializationStream = new MemoryStream(Buffer);
            BinaryFormatter formatter = new BinaryFormatter();
            return (WebServiceCallResult) formatter.Deserialize(serializationStream);
        }

        public byte[] Serialize()
        {
            MemoryStream serializationStream = new MemoryStream();
            new BinaryFormatter().Serialize(serializationStream, this);
            return serializationStream.GetBuffer();
        }
    }
}


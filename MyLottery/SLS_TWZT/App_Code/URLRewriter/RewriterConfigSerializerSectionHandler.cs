namespace URLRewriter
{
    using System;
    using System.Configuration;
    using System.Xml;
    using System.Xml.Serialization;

    public class RewriterConfigSerializerSectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(RewriterConfiguration));
            return serializer.Deserialize(new XmlNodeReader(section));
        }
    }
}


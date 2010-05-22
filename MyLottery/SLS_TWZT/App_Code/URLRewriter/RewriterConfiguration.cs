namespace URLRewriter
{
    using System;
    using System.Configuration;
    using System.Web;
    using System.Xml.Serialization;

    [Serializable, XmlRoot("RewriterConfig")]
    public class RewriterConfiguration
    {
        private RewriterRuleCollection rules;

        public static RewriterConfiguration GetConfig()
        {
            if (HttpContext.Current.Cache["RewriterConfig"] == null)
            {
                HttpContext.Current.Cache.Insert("RewriterConfig", ConfigurationManager.AppSettings["RewriterConfig"]);
            }
            return (RewriterConfiguration) HttpContext.Current.Cache["RewriterConfig"];
        }

        public RewriterRuleCollection Rules
        {
            get
            {
                return this.rules;
            }
            set
            {
                this.rules = value;
            }
        }
    }
}


namespace Shove.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.Configuration;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings settings = ((Settings) SettingsBase.Synchronized(new Settings()));

        public static Settings Default
        {
            get
            {
                return settings;
            }
        }

        [DefaultSettingValue("http://newton.shovesoft.com/Service.asmx"), ApplicationScopedSetting, DebuggerNonUserCode, SpecialSetting(SpecialSetting.WebServiceUrl)]
        public string Shove_NewtonServices_Service
        {
            get
            {
                return (string) this["Shove_NewtonServices_Service"];
            }
        }

        [ApplicationScopedSetting, DebuggerNonUserCode, DefaultSettingValue("http://service.shovesoft.com/Service/Service.asmx"), SpecialSetting(SpecialSetting.WebServiceUrl)]
        public string Shove_ShovesoftService_Service
        {
            get
            {
                return (string) this["Shove_ShovesoftService_Service"];
            }
        }

        [DebuggerNonUserCode, DefaultSettingValue("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<xsl:stylesheet version=\"1.0\" xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\" xmlns:fo=\"http://www.w3.org/1999/XSL/Format\" xmlns:ebl=\"urn:ebay:apis:eBLBaseComponents\" exclude-result-prefixes=\"ebl\">\r\n    <!--==================================================================================== \r\n    Original version by : Holten Norris ( holtennorris at yahoo.com ) \r\n    Current version maintained  by: Alan Lewis (alanlewis at gmail.com) \r\n    Thanks to Venu Reddy from eBay XSLT team for help with the array detection code \r\n    Protected by CDDL open source license.  \r\n    Transforms XML into JavaScript objects, using a JSON format. \r\n    ===================================================================================== -->\r\n    <xsl:output method=\"text\" encoding=\"UTF-8\"/>\r\n    <xsl:template match=\"*\">\r\n        <xsl:param name=\"recursionCnt\">0</xsl:param>\r\n        <xsl:param name=\"isLast\">1</xsl:param>\r\n        <xsl:param name=\"inArray\">0</xsl:param>\r\n        <xsl:if test=\"$recursionCnt=0\">\r\n            <xsl:text></xsl:text>\r\n        </xsl:if>\r\n        <!-- test what type of data to output  -->\r\n        <xsl:variable name=\"elementDataType\">\r\n            <xsl:value-of select=\"number(text())\"/>\r\n        </xsl:variable>\r\n        <xsl:variable name=\"elementData\">\r\n            <!-- TEXT ( use quotes ) -->\r\n            <xsl:if test=\"string($elementDataType) ='NaN'\">\r\n                <xsl:if test=\"boolean(text())\">\r\n                    <xsl:if test=\"not(*)\">\r\n                        \"<xsl:value-of select=\"text()\"/>\"\r\n                    </xsl:if>\r\n                </xsl:if>\r\n            </xsl:if>\r\n            <!-- NUMBER (no quotes ) -->\r\n            <xsl:if test=\"string($elementDataType) !='NaN'\">\r\n                <xsl:value-of select=\"text()\"/>\r\n            </xsl:if>\r\n            <!-- NULL -->\r\n            <xsl:if test=\"not(*)\">\r\n                <xsl:if test=\"not(text())\">\r\n                    null\r\n                </xsl:if>\r\n            </xsl:if>\r\n        </xsl:variable>\r\n        <xsl:variable name=\"hasRepeatElements\">\r\n            <xsl:for-each select=\"*\">\r\n                <xsl:if test=\"name() = name(preceding-sibling::*) or name() = name(following-sibling::*)\">\r\n                    true\r\n                </xsl:if>\r\n            </xsl:for-each>\r\n        </xsl:variable>\r\n        <xsl:if test=\"not(count(@*) &gt; 0)\">\r\n            \"<xsl:value-of select=\"local-name()\"/>\": <xsl:value-of select=\"$elementData\"/>\r\n        </xsl:if>\r\n        <xsl:if test=\"count(@*) &gt; 0\">\r\n            \"<xsl:value-of select=\"local-name()\"/>\": {\r\n            \"content\": <xsl:value-of select=\"$elementData\"/>\r\n            <xsl:for-each select=\"@*\">\r\n                <xsl:if test=\"position()=1\">,</xsl:if>\r\n                <!-- test what type of data to output  -->\r\n                <xsl:variable name=\"dataType\">\r\n                    <xsl:value-of select=\"number(.)\"/>\r\n                </xsl:variable>\r\n                <xsl:variable name=\"data\">\r\n                    <!-- TEXT ( use quotes ) -->\r\n                    <xsl:if test=\"string($dataType) ='NaN'\">\r\n                        \"<xsl:value-of select=\"current()\"/>\"\r\n                    </xsl:if>\r\n                    <!-- NUMBER (no quotes ) -->\r\n                    <xsl:if test=\"string($dataType) !='NaN'\">\r\n                        <xsl:value-of select=\"current()\"/>\r\n                    </xsl:if>\r\n                </xsl:variable>\r\n                <xsl:value-of select=\"local-name()\"/>:<xsl:value-of select=\"$data\"/>\r\n                <xsl:if test=\"position() !=last()\">, </xsl:if>\r\n            </xsl:for-each>\r\n            }\r\n        </xsl:if>\r\n        <xsl:if test=\"not($hasRepeatElements = '')\">\r\n            [{\r\n        </xsl:if>\r\n        <xsl:for-each select=\"*\">\r\n            <xsl:if test=\"position()=1\">\r\n                <xsl:if test=\"$hasRepeatElements = ''\">\r\n                    <xsl:text> { </xsl:text>\r\n                </xsl:if>\r\n            </xsl:if>\r\n            <xsl:apply-templates select=\"current()\">\r\n                <xsl:with-param name=\"recursionCnt\" select=\"$recursionCnt+1\"/>\r\n                <xsl:with-param name=\"isLast\" select=\"position()=last()\"/>\r\n                <xsl:with-param name=\"inArray\" select=\"not($hasRepeatElements = '')\"/>\r\n            </xsl:apply-templates>\r\n            <xsl:if test=\"position()=last()\">\r\n                <xsl:if test=\"$hasRepeatElements = ''\">\r\n                    <xsl:text> } </xsl:text>\r\n                </xsl:if>\r\n            </xsl:if>\r\n        </xsl:for-each>\r\n        <xsl:if test=\"not($hasRepeatElements = '')\">\r\n            }]\r\n        </xsl:if>\r\n        <xsl:if test=\"not( $isLast )\">\r\n            <xsl:if test=\"$inArray = 'true'\">\r\n                <xsl:text> } </xsl:text>\r\n            </xsl:if>\r\n            ,\r\n            <xsl:if test=\"$inArray = 'true'\">\r\n                <xsl:text> { </xsl:text>\r\n            </xsl:if>\r\n        </xsl:if>\r\n        <xsl:if test=\"$recursionCnt=0\"></xsl:if>\r\n    </xsl:template>\r\n</xsl:stylesheet>\r\n"), ApplicationScopedSetting]
        public string Xml2JsonXslt
        {
            get
            {
                return (string) this["Xml2JsonXslt"];
            }
        }
    }
}


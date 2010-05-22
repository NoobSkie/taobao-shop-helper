namespace Shove.HTML.SgmlReader
{
    using System;
    using System.Collections.Generic;

    public class AttDef
    {
        public string Default;
        public string[] EnumValues;
        public string Name;
        public AttributePresence Presence;
        public AttributeType Type;

        public AttDef(string name)
        {
            this.Name = name;
        }

        public bool SetPresence(string token)
        {
            bool flag = true;
            if (token == "FIXED")
            {
                this.Presence = AttributePresence.FIXED;
                return flag;
            }
            if (token == "REQUIRED")
            {
                this.Presence = AttributePresence.REQUIRED;
                return false;
            }
            if (token != "IMPLIED")
            {
                throw new Exception(string.Format("Attribute value '{0}' not supported", token));
            }
            this.Presence = AttributePresence.IMPLIED;
            return false;
        }

        public void SetType(string type)
        {
            switch (type)
            {
                case "CDATA":
                    Type = AttributeType.CDATA;
                    break;
                case "ENTITY":
                    Type = AttributeType.ENTITY;
                    break;
                case "ENTITIES":
                    Type = AttributeType.ENTITIES;
                    break;
                case "ID":
                    Type = AttributeType.ID;
                    break;
                case "IDREF":
                    Type = AttributeType.IDREF;
                    break;
                case "IDREFS":
                    Type = AttributeType.IDREFS;
                    break;
                case "NAME":
                    Type = AttributeType.NAME;
                    break;
                case "NAMES":
                    Type = AttributeType.NAMES;
                    break;
                case "NMTOKEN":
                    Type = AttributeType.NMTOKEN;
                    break;
                case "NMTOKENS":
                    Type = AttributeType.NMTOKENS;
                    break;
                case "NUMBER":
                    Type = AttributeType.NUMBER;
                    break;
                case "NUMBERS":
                    Type = AttributeType.NUMBERS;
                    break;
                case "NUTOKEN":
                    Type = AttributeType.NUTOKEN;
                    break;
                case "NUTOKENS":
                    Type = AttributeType.NUTOKENS;
                    break;
                default:
                    throw new Exception("Attribute type '" + type + "' is not supported");
            }
        }
    }
}


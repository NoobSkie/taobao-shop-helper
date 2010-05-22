namespace Shove.HTML.HtmlParse
{
    using System;

    public class Attribute : ICloneable
    {
        private char _delim;
        private string _name;
        private string _value;

        public Attribute() : this("", "", '\0')
        {
        }

        public Attribute(string name, string value) : this(name, value, '\0')
        {
        }

        public Attribute(string name, string value, char delim)
        {
            this._name = name;
            this._value = value;
            this._delim = delim;
        }

        public virtual object Clone()
        {
            return new Shove.HTML.HtmlParse.Attribute(this._name, this._value, this._delim);
        }

        public char Delim
        {
            get
            {
                return this._delim;
            }
            set
            {
                this._delim = value;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public string Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
    }
}


namespace Shove.HTML.HtmlParse
{
    using System;

    public class Parse : AttributeList
    {
        private string _parseName;
        public string m_tag;
        private char _parseDelim;
        private string _source;
        private string _parseValue;
        private int _count;

        public void AddAttribute()
        {
            Shove.HTML.HtmlParse.Attribute a = new Shove.HTML.HtmlParse.Attribute(this._parseName, this._parseValue, this._parseDelim);
            base.Add(a);
        }

        public void Advance()
        {
            this._count++;
        }

        public char AdvanceCurrentChar()
        {
            return this._source[this._count++];
        }

        public void EatWhiteSpace()
        {
            while (!this.Eof())
            {
                if (!IsWhiteSpace(this.GetCurrentChar()))
                {
                    return;
                }
                this._count++;
            }
        }

        public bool Eof()
        {
            return (this._count >= this._source.Length);
        }

        public char GetCurrentChar()
        {
            return this.GetCurrentChar(0);
        }

        public char GetCurrentChar(int peek)
        {
            if ((this._count + peek) < this._source.Length)
            {
                return this._source[this._count + peek];
            }
            return '\0';
        }

        public static bool IsWhiteSpace(char ch)
        {
            return ("\t\n\r ".IndexOf(ch) != -1);
        }

        public void ParseAttributeName()
        {
            this.EatWhiteSpace();
            while (!this.Eof())
            {
                if ((IsWhiteSpace(this.GetCurrentChar()) || (this.GetCurrentChar() == '=')) || (this.GetCurrentChar() == '>'))
                {
                    break;
                }
                this._parseName = this._parseName + this.GetCurrentChar();
                this._count++;
            }
            this.EatWhiteSpace();
        }

        public void ParseAttributeValue()
        {
            if ((this._parseDelim == '\0') && (this.GetCurrentChar() == '='))
            {
                this._count++;
                this.EatWhiteSpace();
                if ((this.GetCurrentChar() != '\'') && (this.GetCurrentChar() != '"'))
                {
                    while ((!this.Eof() && !IsWhiteSpace(this.GetCurrentChar())) && (this.GetCurrentChar() != '>'))
                    {
                        this._parseValue = this._parseValue + this.GetCurrentChar();
                        this._count++;
                    }
                }
                else
                {
                    this._parseDelim = this.GetCurrentChar();
                    this._count++;
                    while (this.GetCurrentChar() != this._parseDelim)
                    {
                        this._parseValue = this._parseValue + this.GetCurrentChar();
                        this._count++;
                    }
                    this._count++;
                }
                this.EatWhiteSpace();
            }
        }

        public char ParseDelim
        {
            get
            {
                return this._parseDelim;
            }
            set
            {
                this._parseDelim = value;
            }
        }

        public string ParseName
        {
            get
            {
                return this._parseName;
            }
            set
            {
                this._parseName = value;
            }
        }

        public string ParseValue
        {
            get
            {
                return this._parseValue;
            }
            set
            {
                this._parseValue = value;
            }
        }

        public string Source
        {
            get
            {
                return this._source;
            }
            set
            {
                this._source = value;
            }
        }
    }
}


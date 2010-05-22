namespace Shove.HTML.SgmlReader
{
    using System;
    using System.IO;
    using System.Collections;
    using System.Text;
    using System.Net;
    using System.Xml;
    using System.Globalization;

    public class Entity
    {
        public const Char EOF = (char)65535;
        public string Proxy;
        public string Name;
        public bool Internal;
        public string PublicId;
        public string Uri;
        public string Literal;
        public LiteralType LiteralType;
        public Entity Parent;
        public bool Html;
        public int Line;
        public char Lastchar;
        public bool IsWhitespace;

        Encoding encoding;
        Uri resolvedUri;
        TextReader stm;
        bool weOwnTheStream;
        int lineStart;
        int absolutePos;

        public Entity(string name, string pubid, string uri, string proxy)
        {
            Name = name;
            PublicId = pubid;
            Uri = uri;
            Proxy = proxy;
            Html = (name != null && StringUtilities.EqualsIgnoreCase(name, "html"));
        }

        public Entity(string name, string literal)
        {
            Name = name;
            Literal = literal;
            Internal = true;
        }

        public Entity(string name, Uri baseUri, TextReader stm, string proxy)
        {
            Name = name;
            Internal = true;
            this.stm = stm;
            this.resolvedUri = baseUri;
            Proxy = proxy;
            Html = (string.Compare(name, "html", true, CultureInfo.InvariantCulture) == 0);
        }

        public Uri ResolvedUri
        {
            get
            {
                if (this.resolvedUri != null) return this.resolvedUri;
                else if (Parent != null) return Parent.ResolvedUri;
                return null;
            }
        }

        public int LinePosition
        {
            get { return this.absolutePos - this.lineStart + 1; }
        }

        public char ReadChar()
        {
            char ch = (char)this.stm.Read();
            if (ch == 0)
            {
                ch = ' ';
            }
            this.absolutePos++;
            if (ch == 0xa)
            {
                IsWhitespace = true;
                this.lineStart = this.absolutePos + 1;
                Line++;
            }
            else if (ch == ' ' || ch == '\t')
            {
                IsWhitespace = true;
                if (Lastchar == 0xd)
                {
                    this.lineStart = this.absolutePos;
                    Line++;
                }
            }
            else if (ch == 0xd)
            {
                IsWhitespace = true;
            }
            else
            {
                IsWhitespace = false;
                if (Lastchar == 0xd)
                {
                    Line++;
                    this.lineStart = this.absolutePos;
                }
            }
            Lastchar = ch;
            return ch;
        }

        public void Open(Entity parent, Uri baseUri)
        {
            Parent = parent;
            if (parent != null) this.Html = parent.Html;
            this.Line = 1;
            if (Internal)
            {
                if (this.Literal != null)
                    this.stm = new StringReader(this.Literal);
            }
            else if (this.Uri == null)
            {
                this.Error("Unresolvable entity '{0}'", this.Name);
            }
            else
            {
                if (baseUri != null)
                {
                    this.resolvedUri = new Uri(baseUri, this.Uri);
                }
                else
                {
                    this.resolvedUri = new Uri(this.Uri);
                }

                Stream stream = null;
                Encoding e = Encoding.Default;
                switch (this.resolvedUri.Scheme)
                {
                    case "file":
                        {
                            string path = this.resolvedUri.LocalPath;
                            stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                        }
                        break;
                    default:
                        HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(ResolvedUri);
                        wr.UserAgent = "Mozilla/4.0 (compatible;);";
                        wr.Timeout = 10000; 
                        if (Proxy != null) wr.Proxy = new WebProxy(Proxy);
                        wr.PreAuthenticate = false;

                        wr.Credentials = CredentialCache.DefaultCredentials;

                        WebResponse resp = wr.GetResponse();
                        Uri actual = resp.ResponseUri;
                        if (actual.AbsoluteUri != this.resolvedUri.AbsoluteUri)
                        {
                            this.resolvedUri = actual;
                        }
                        string contentType = resp.ContentType.ToLower();
                        string mimeType = contentType;
                        int i = contentType.IndexOf(';');
                        if (i >= 0)
                        {
                            mimeType = contentType.Substring(0, i);
                        }
                        if (StringUtilities.EqualsIgnoreCase(mimeType, "text/html"))
                        {
                            this.Html = true;
                        }

                        i = contentType.IndexOf("charset");
                        e = Encoding.Default;
                        if (i >= 0)
                        {
                            int j = contentType.IndexOf("=", i);
                            int k = contentType.IndexOf(";", j);
                            if (k < 0) k = contentType.Length;
                            if (j > 0)
                            {
                                j++;
                                string charset = contentType.Substring(j, k - j).Trim();
                                try
                                {
                                    e = Encoding.GetEncoding(charset);
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                        stream = resp.GetResponseStream();
                        break;

                }
                this.weOwnTheStream = true;
                HtmlStream html = new HtmlStream(stream, e);
                this.encoding = html.Encoding;
                this.stm = html;
            }
        }

        public Encoding GetEncoding()
        {
            return this.encoding;
        }

        public void Close()
        {
            if (this.weOwnTheStream)
                this.stm.Close();
        }

        public char SkipWhitespace()
        {
            char ch = Lastchar;
            while (ch != Entity.EOF && (ch == ' ' || ch == '\r' || ch == '\n' || ch == '\t'))
            {
                ch = ReadChar();
            }
            return ch;
        }

        public string ScanToken(StringBuilder sb, string term, bool nmtoken)
        {
            sb.Length = 0;
            char ch = Lastchar;
            if (nmtoken && ch != '_' && !Char.IsLetter(ch))
            {
                throw new Exception(
                    String.Format("Invalid name start character '{0}'", ch));
            }
            while (ch != Entity.EOF && term.IndexOf(ch) < 0)
            {
                if (!nmtoken || ch == '_' || ch == '.' || ch == '-' || ch == ':' || Char.IsLetterOrDigit(ch))
                {
                    sb.Append(ch);
                }
                else
                {
                    throw new Exception(
                        String.Format("Invalid name character '{0}'", ch));
                }
                ch = ReadChar();
            }
            return sb.ToString();
        }

        public string ScanLiteral(StringBuilder sb, char quote)
        {
            sb.Length = 0;
            char ch = ReadChar();
            while (ch != Entity.EOF && ch != quote)
            {
                if (ch == '&')
                {
                    ch = ReadChar();
                    if (ch == '#')
                    {
                        string charent = ExpandCharEntity();
                        sb.Append(charent);
                        ch = this.Lastchar;
                    }
                    else
                    {
                        sb.Append('&');
                        sb.Append(ch);
                        ch = ReadChar();
                    }
                }
                else
                {
                    sb.Append(ch);
                    ch = ReadChar();
                }
            }
            ReadChar();         
            return sb.ToString();
        }

        public string ScanToEnd(StringBuilder sb, string type, string terminators)
        {
            if (sb != null) sb.Length = 0;
            int start = Line;

            char ch = ReadChar();
            int state = 0;
            char next = terminators[state];
            while (ch != Entity.EOF)
            {
                if (ch == next)
                {
                    state++;
                    if (state >= terminators.Length)
                    {
                        break;
                    }
                    next = terminators[state];
                }
                else if (state > 0)
                {
                    int i = state - 1;
                    int newstate = 0;
                    while (i >= 0 && newstate == 0)
                    {
                        if (terminators[i] == ch)
                        {
                            int j = 1;
                            while (i - j >= 0)
                            {
                                if (terminators[i - j] != terminators[state - j])
                                    break;
                                j++;
                            }
                            if (j > i)
                            {
                                newstate = i + 1;
                            }
                        }
                        else
                        {
                            i--;
                        }
                    }
                    if (sb != null)
                    {
                        i = (i < 0) ? 1 : 0;
                        for (int k = 0; k <= state - newstate - i; k++)
                        {
                            sb.Append(terminators[k]);
                        }
                        if (i > 0) 
                            sb.Append(ch); 
                    }
                    state = newstate;
                    next = terminators[newstate];
                }
                else
                {
                    if (sb != null) sb.Append(ch);
                }
                ch = ReadChar();
            }
            if (ch == 0) Error(type + " starting on line {0} was never closed", start);
            ReadChar();
            if (sb != null) return sb.ToString();
            return "";
        }

        public string ExpandCharEntity()
        {
            char ch = ReadChar();
            int v = 0;
            if (ch == 'x')
            {
                ch = ReadChar();
                for (; ch != Entity.EOF && ch != ';'; ch = ReadChar())
                {
                    int p = 0;
                    if (ch >= '0' && ch <= '9')
                    {
                        p = (int)(ch - '0');
                    }
                    else if (ch >= 'a' && ch <= 'f')
                    {
                        p = (int)(ch - 'a') + 10;
                    }
                    else if (ch >= 'A' && ch <= 'F')
                    {
                        p = (int)(ch - 'A') + 10;
                    }
                    else
                    {
                        break;
                    }
                    v = (v * 16) + p;
                }
            }
            else
            {
                for (; ch != Entity.EOF && ch != ';'; ch = ReadChar())
                {
                    if (ch >= '0' && ch <= '9')
                    {
                        v = (v * 10) + (int)(ch - '0');
                    }
                    else
                    {
                        break; 
                    }
                }
            }
            if (ch == 0)
            {
                Error("Premature {0} parsing entity reference", ch);
            }
            else if (ch == ';')
            {
                ReadChar();
            }
         
            if (this.Html && v >= 0x80 & v <= 0x9F)
            {
                int size = CtrlMap.Length;
                int i = v - 0x80;
                int unicode = CtrlMap[i];
                return Convert.ToChar(unicode).ToString();
            }
            return Convert.ToChar(v).ToString();
        }

        static int[] CtrlMap = new int[] {
                                            
                                             8364, 129, 8218, 402, 8222, 8230, 8224, 8225, 710, 8240, 352, 8249, 338, 141,
                                             381, 143, 144, 8216, 8217, 8220, 8221, 8226, 8211, 8212, 732, 8482, 353, 8250, 
                                             339, 157, 382, 376
                                         };

        public void Error(string msg)
        {
            throw new Exception(msg);
        }

        public void Error(string msg, char ch)
        {
            string str = (ch == Entity.EOF) ? "EOF" : Char.ToString(ch);
            throw new Exception(String.Format(msg, str));
        }

        public void Error(string msg, int x)
        {
            throw new Exception(String.Format(msg, x));
        }

        public void Error(string msg, string arg)
        {
            throw new Exception(String.Format(msg, arg));
        }

        public string Context()
        {
            Entity p = this;
            StringBuilder sb = new StringBuilder();
            while (p != null)
            {
                string msg;
                if (p.Internal)
                {
                    msg = String.Format("\nReferenced on line {0}, position {1} of internal entity '{2}'", p.Line, p.LinePosition, p.Name);
                }
                else
                {
                    msg = String.Format("\nReferenced on line {0}, position {1} of '{2}' entity at [{3}]", p.Line, p.LinePosition, p.Name, p.ResolvedUri.AbsolutePath);
                }
                sb.Append(msg);
                p = p.Parent;
            }
            return sb.ToString();
        }

        public static bool IsLiteralType(string token)
        {
            return (token == "CDATA" || token == "SDATA" || token == "PI");
        }

        public void SetLiteralType(string token)
        {
            switch (token)
            {
                case "CDATA":
                    LiteralType = LiteralType.CDATA;
                    break;
                case "SDATA":
                    LiteralType = LiteralType.SDATA;
                    break;
                case "PI":
                    LiteralType = LiteralType.PI;
                    break;
            }
        }
    }
}


namespace Shove.HTML.SgmlReader
{
    using System;
    using System.Xml;
    using System.IO;
    using System.Collections;
    using System.Text;
    using System.Reflection;

    public class SgmlReader : XmlReader
    {
        SgmlDtd dtd;
        Entity current;
        State state;
        XmlNameTable nametable;
        char partial;
        object endTag;
        HWStack stack;
        Node node; 
        Attribute a;
        int apos; 
        Uri baseUri;
        StringBuilder sb;
        StringBuilder name;
        TextWriter log;
        bool foundRoot;


        Node newnode;
        int poptodepth;
        int rootCount;
        bool isHtml;
        string rootElementName;

        string href;
        string errorLogFile;
        Entity lastError;
        string proxy;
        TextReader inputStream;
        string syslit;
        string pubid;
        string subset;
        string docType;
        WhitespaceHandling whitespaceHandling;
        CaseFolding folding = CaseFolding.None;
        bool stripDocType = true;
        string startTag;

        public SgmlReader()
        {
            Init();
            this.nametable = new NameTable();
        }

      
        public SgmlDtd Dtd
        {
            get
            {
                LazyLoadDtd(this.baseUri);
                return this.dtd;
            }
            set { this.dtd = value; }
        }

        private void LazyLoadDtd(Uri baseUri)
        {
            if (this.dtd == null)
            {
                if (this.syslit == null || this.syslit == "")
                {
                    if (this.docType != null && StringUtilities.EqualsIgnoreCase(this.docType, "html"))
                    {
                        Assembly a = typeof(SgmlReader).Assembly;
                        string name = a.FullName.Split(',')[0] + ".Html.dtd";
                        Stream stm = a.GetManifestResourceStream(name);
                        if (stm != null)
                        {
                            StreamReader sr = new StreamReader(stm);
                            this.dtd = SgmlDtd.Parse(baseUri, "HTML", null, sr, null, this.proxy, this.nametable);
                        }
                    }
                }
                else
                {
                    if (baseUri != null)
                    {
                        baseUri = new Uri(baseUri, this.syslit);
                    }
                    else if (this.baseUri != null)
                    {
                        baseUri = new Uri(this.baseUri, this.syslit);
                    }
                    else
                    {
                        baseUri = new Uri(new Uri(Directory.GetCurrentDirectory() + "\\"), this.syslit);
                    }
                    this.dtd = SgmlDtd.Parse(baseUri, this.docType, this.pubid, baseUri.AbsoluteUri, this.subset, this.proxy, this.nametable);
                }

                if (this.dtd != null && this.dtd.Name != null)
                {
                    switch (this.CaseFolding)
                    {
                        case CaseFolding.ToUpper:
                            this.rootElementName = this.dtd.Name.ToUpper();
                            break;
                        case CaseFolding.ToLower:
                            this.rootElementName = this.dtd.Name.ToLower();
                            break;
                        default:
                            this.rootElementName = this.dtd.Name;
                            break;
                    }
                    this.isHtml = StringUtilities.EqualsIgnoreCase(this.dtd.Name, "html");
                }

            }
        }

     
        public string DocType
        {
            get { return this.docType; }
            set { this.docType = value; }
        }

     
        public string PublicIdentifier
        {
            get { return this.pubid; }
            set { this.pubid = value; }
        }

     
        public string SystemLiteral
        {
            get { return this.syslit; }
            set { this.syslit = value; }
        }

    
        public string InternalSubset
        {
            get { return this.subset; }
            set { this.subset = value; }
        }

    
        public TextReader InputStream
        {
            get { return this.inputStream; }
            set { this.inputStream = value; Init(); }
        }

      
        public string WebProxy
        {
            get { return this.proxy; }
            set { this.proxy = value; }
        }

      
        public void SetBaseUri(string uri)
        {
            this.baseUri = new Uri(uri);
        }


        public string Href
        {
            get { return this.href; }
            set
            {
                this.href = value;
                Init();
                if (this.baseUri == null)
                {
                    if (this.href.IndexOf("://") > 0)
                    {
                        this.baseUri = new Uri(this.href);
                    }
                    else
                    {
                        this.baseUri = new Uri("file:///" + Directory.GetCurrentDirectory() + "//");
                    }
                }
            }
        }

        public bool StripDocType
        {
            get { return this.stripDocType; }
            set { this.stripDocType = value; }
        }

        public CaseFolding CaseFolding
        {
            get { return this.folding; }
            set { this.folding = value; }
        }

        public TextWriter ErrorLog
        {
            get { return this.log; }
            set { this.log = value; }
        }

        public string ErrorLogFile
        {
            get { return this.errorLogFile; }
            set
            {
                this.errorLogFile = value;
                this.ErrorLog = new StreamWriter(value);
            }
        }

        void Log(string msg, params string[] args)
        {
            if (ErrorLog != null)
            {
                string err = String.Format(msg, args);
                if (this.lastError != this.current)
                {
                    err = err + "    " + this.current.Context();
                    this.lastError = this.current;
                    ErrorLog.WriteLine("### Error:" + err);
                }
                else
                {
                    string path = "";
                    if (this.current.ResolvedUri != null)
                    {
                        path = this.current.ResolvedUri.AbsolutePath;
                    }
                    ErrorLog.WriteLine("### Error in " +
                        path + "#" +
                        this.current.Name +
                        ", line " + this.current.Line + ", position " + this.current.LinePosition + ": " +
                        err);
                }
            }
        }
        void Log(string msg, char ch)
        {
            Log(msg, ch.ToString());
        }


        void Init()
        {
            this.state = State.Initial;
            this.stack = new HWStack(10);
            this.node = Push(null, XmlNodeType.Document, null);
            this.node.IsEmpty = false;
            this.sb = new StringBuilder();
            this.name = new StringBuilder();
            this.poptodepth = 0;
            this.current = null;
            this.partial = '\0';
            this.endTag = null;
            this.a = null;
            this.apos = 0;
            this.newnode = null;
            this.rootCount = 0;
            this.foundRoot = false;
        }

        Node Push(string name, XmlNodeType nt, string value)
        {
            Node result = (Node)this.stack.Push();
            if (result == null)
            {
                result = new Node();
                this.stack[this.stack.Count - 1] = result;
            }
            result.Reset(name, nt, value);
            this.node = result;
            return result;
        }

        void SwapTopNodes()
        {
            int top = this.stack.Count - 1;
            if (top > 0)
            {
                Node n = (Node)this.stack[top - 1];
                this.stack[top - 1] = this.stack[top];
                this.stack[top] = n;
            }
        }

        Node Push(Node n)
        {
            Node n2 = Push(n.Name, n.NodeType, n.Value);
            n2.DtdType = n.DtdType;
            n2.IsEmpty = n.IsEmpty;
            n2.Space = n.Space;
            n2.XmlLang = n.XmlLang;
            n2.CurrentState = n.CurrentState;
            n2.CopyAttributes(n);
            this.node = n2;
            return n2;
        }

        void Pop()
        {
            if (this.stack.Count > 1)
            {
                this.node = (Node)this.stack.Pop();
            }
        }

        Node Top()
        {
            int top = this.stack.Count - 1;
            if (top > 0)
            {
                return (Node)this.stack[top];
            }
            return null;
        }

        public override XmlNodeType NodeType
        {
            get
            {
                if (this.state == State.Attr)
                {
                    return XmlNodeType.Attribute;
                }
                else if (this.state == State.AttrValue)
                {
                    return XmlNodeType.Text;
                }
                else if (this.state == State.EndTag || this.state == State.AutoClose)
                {
                    return XmlNodeType.EndElement;
                }
                return this.node.NodeType;
            }
        }

        public override string Name
        {
            get
            {
                return this.LocalName;
            }
        }

        public override string LocalName
        {
            get
            {
                string result = null;
                if (this.state == State.Attr)
                {
                    result = this.a.Name;
                }
                else if (this.state == State.AttrValue)
                {
                    result = null;
                }
                else
                {
                    result = this.node.Name;
                }

                return result;
            }
        }

        public override string NamespaceURI
        {
            get
            {
                if (this.state == State.Attr && StringUtilities.EqualsIgnoreCase(this.a.Name, "xmlns"))
                {
                    return "http://www.w3.org/2000/xmlns/";
                }
                return String.Empty;
            }
        }

        public override string Prefix
        {
            get
            {
                return String.Empty;
            }
        }

        public override bool HasValue
        {
            get
            {
                if (this.state == State.Attr || this.state == State.AttrValue)
                {
                    return true;
                }
                return (this.node.Value != null);
            }
        }

        public override string Value
        {
            get
            {
                if (this.state == State.Attr || this.state == State.AttrValue)
                {
                    return this.a.Value;
                }
                return this.node.Value;
            }
        }

        public override int Depth
        {
            get
            {
                if (this.state == State.Attr)
                {
                    return this.stack.Count;
                }
                else if (this.state == State.AttrValue)
                {
                    return this.stack.Count + 1;
                }
                return this.stack.Count - 1;
            }
        }

        public override string BaseURI
        {
            get
            {
                return this.baseUri == null ? "" : this.baseUri.AbsoluteUri;
            }
        }

        public override bool IsEmptyElement
        {
            get
            {
                if (this.state == State.Markup || this.state == State.Attr || this.state == State.AttrValue)
                {
                    return this.node.IsEmpty;
                }
                return false;
            }
        }
        public override bool IsDefault
        {
            get
            {
                if (this.state == State.Attr || this.state == State.AttrValue)
                    return this.a.IsDefault;
                return false;
            }
        }
        public override char QuoteChar
        {
            get
            {
                if (this.a != null) return this.a.QuoteChar;
                return '\0';
            }
        }

        public override XmlSpace XmlSpace
        {
            get
            {
                for (int i = this.stack.Count - 1; i > 1; i--)
                {
                    Node n = (Node)this.stack[i];
                    XmlSpace xs = n.Space;
                    if (xs != XmlSpace.None) return xs;
                }
                return XmlSpace.None;
            }
        }

        public override string XmlLang
        {
            get
            {
                for (int i = this.stack.Count - 1; i > 1; i--)
                {
                    Node n = (Node)this.stack[i];
                    string xmllang = n.XmlLang;
                    if (xmllang != null) return xmllang;
                }
                return String.Empty;
            }
        }

        public WhitespaceHandling WhitespaceHandling
        {
            get
            {
                return this.whitespaceHandling;
            }
            set
            {
                this.whitespaceHandling = value;
            }
        }

        public override int AttributeCount
        {
            get
            {
                if (this.state == State.Attr || this.state == State.AttrValue)
                    return 0;
                if (this.node.NodeType == XmlNodeType.Element ||
                    this.node.NodeType == XmlNodeType.DocumentType)
                    return this.node.AttributeCount;
                return 0;
            }
        }

        public override string GetAttribute(string name)
        {
            if (this.state != State.Attr && this.state != State.AttrValue)
            {
                int i = this.node.GetAttribute(name);
                if (i >= 0) return GetAttribute(i);
            }
            return null;
        }

        public override string GetAttribute(string name, string namespaceURI)
        {
            return GetAttribute(name); 
        }

        public override string GetAttribute(int i)
        {
            if (this.state != State.Attr && this.state != State.AttrValue)
            {
                Attribute a = this.node.GetAttribute(i);
                if (a != null)
                    return a.Value;
            }
            throw new IndexOutOfRangeException();
        }

        public override string this[int i]
        {
            get
            {
                return GetAttribute(i);
            }
        }

        public override string this[string name]
        {
            get
            {
                return GetAttribute(name);
            }
        }

        public override string this[string name, string namespaceURI]
        {
            get
            {
                return GetAttribute(name, namespaceURI);
            }
        }

        public override bool MoveToAttribute(string name)
        {
            int i = this.node.GetAttribute(name);
            if (i >= 0)
            {
                MoveToAttribute(i);
                return true;
            }
            return false;
        }

        public override bool MoveToAttribute(string name, string ns)
        {
            return MoveToAttribute(name);
        }

        public override void MoveToAttribute(int i)
        {
            Attribute a = this.node.GetAttribute(i);
            if (a != null)
            {
                this.apos = i;
                this.a = a;
                if (this.state != State.Attr)
                {
                    this.node.CurrentState = this.state;
                }
                this.state = State.Attr;
                return;
            }
            throw new IndexOutOfRangeException();
        }

        public override bool MoveToFirstAttribute()
        {
            if (this.node.AttributeCount > 0)
            {
                MoveToAttribute(0);
                return true;
            }
            return false;
        }

        public override bool MoveToNextAttribute()
        {
            if (this.state != State.Attr && this.state != State.AttrValue)
            {
                return MoveToFirstAttribute();
            }
            if (this.apos < this.node.AttributeCount - 1)
            {
                MoveToAttribute(this.apos + 1);
                return true;
            }
            return false;
        }

        public override bool MoveToElement()
        {
            if (this.state == State.Attr || this.state == State.AttrValue)
            {
                this.state = this.node.CurrentState;
                this.a = null;
                return true;
            }
            return (this.node.NodeType == XmlNodeType.Element);
        }

        bool IsHtml
        {
            get
            {
                return this.isHtml;
            }
        }

        public Encoding GetEncoding()
        {
            if (this.current == null)
            {
                OpenInput();
            }
            return this.current.GetEncoding();
        }

        void OpenInput()
        {
            LazyLoadDtd(this.baseUri);

            if (this.Href != null)
            {
                this.current = new Entity("#document", null, this.href, this.proxy);
            }
            else if (this.inputStream != null)
            {
                this.current = new Entity("#document", null, this.inputStream, this.proxy);
            }
            else
            {
                throw new InvalidOperationException("You must specify input either via Href or InputStream properties");
            }
            this.current.Html = this.IsHtml;
            this.current.Open(null, this.baseUri);
            if (this.current.ResolvedUri != null)
                this.baseUri = this.current.ResolvedUri;

            if (this.current.Html && this.dtd == null)
            {
                this.docType = "HTML";
                LazyLoadDtd(this.baseUri);
            }
        }

        public override bool Read()
        {
            if (current == null)
            {
                OpenInput();
            }
            State start = this.state;
            if (node.Simulated)
            {
                node.Simulated = false;
                this.node = Top();
                this.state = this.node.CurrentState;
                return true;
            }

            bool foundnode = false;
            while (!foundnode)
            {
                switch (this.state)
                {
                    case State.Initial:
                        this.state = State.Markup;
                        this.current.ReadChar();
                        goto case State.Markup;
                    case State.Eof:
                        if (this.current.Parent != null)
                        {
                            this.current.Close();
                            this.current = this.current.Parent;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case State.EndTag:
                        if (this.endTag == (object)this.node.Name)
                        {
                            Pop(); // we're done!
                            this.state = State.Markup;
                            goto case State.Markup;
                        }
                        Pop();
                        foundnode = true;
                        break;
                    case State.Markup:
                        if (this.node.IsEmpty)
                        {
                            Pop();
                        }
                        Node n = this.node;
                        foundnode = ParseMarkup();
                        break;
                    case State.PartialTag:
                        Pop(); 
                        this.state = State.Markup;
                        foundnode = ParseTag(this.partial);
                        break;
                    case State.PseudoStartTag:
                        foundnode = ParseStartTag('<');
                        break;
                    case State.AutoClose:
                        Pop(); 
                        if (this.stack.Count <= this.poptodepth)
                        {
                            this.state = State.Markup;
                            if (this.newnode != null)
                            {
                                Push(this.newnode); 
                                this.newnode = null;
                                this.state = State.Markup;
                            }
                            else if (this.node.NodeType == XmlNodeType.Document)
                            {
                                this.state = State.Eof;
                                goto case State.Eof;
                            }
                        }
                        foundnode = true;
                        break;
                    case State.CData:
                        foundnode = ParseCData();
                        break;
                    case State.Attr:
                        goto case State.AttrValue;
                    case State.AttrValue:
                        this.state = State.Markup;
                        goto case State.Markup;
                    case State.Text:
                        Pop();
                        goto case State.Markup;
                    case State.PartialText:
                        if (ParseText(this.current.Lastchar, false))
                        {
                            this.node.NodeType = XmlNodeType.Whitespace;
                        }
                        foundnode = true;
                        break;
                }
                if (foundnode && this.node.NodeType == XmlNodeType.Whitespace && this.whitespaceHandling == WhitespaceHandling.None)
                {
                
                    foundnode = false;
                }
                if (!foundnode && this.state == State.Eof && this.stack.Count > 1)
                {
                    this.poptodepth = 1;
                    state = State.AutoClose;
                    this.node = Top();
                    return true;
                }
            }
            if (!foundRoot && (this.NodeType == XmlNodeType.Element ||
                    this.NodeType == XmlNodeType.Text ||
                    this.NodeType == XmlNodeType.CDATA))
            {
                foundRoot = true;
                if (this.IsHtml && (this.NodeType != XmlNodeType.Element ||
                    string.Compare(this.LocalName, "html", true, System.Globalization.CultureInfo.InvariantCulture) != 0))
                {

                    this.node.CurrentState = this.state;
                    Node root = Push("html", XmlNodeType.Element, null);
                    SwapTopNodes(); 
                    this.node = root;
                    root.Simulated = true;
                    root.IsEmpty = false;
                    this.state = State.Markup;
                }
                return true;
            }
            return true;
        }

        bool ParseMarkup()
        {
            char ch = this.current.Lastchar;
            if (ch == '<')
            {
                ch = this.current.ReadChar();
                return ParseTag(ch);
            }
            else if (ch != Entity.EOF)
            {
                if (this.node.DtdType != null && this.node.DtdType.ContentModel.DeclaredContent == DeclaredContent.CDATA)
                {
                    this.partial = '\0';
                    this.state = State.CData;
                    return false;
                }
                else if (ParseText(ch, true))
                {
                    this.node.NodeType = XmlNodeType.Whitespace;
                }
                return true;
            }
            this.state = State.Eof;
            return false;
        }

        static string declterm = " \t\r\n><";
        bool ParseTag(char ch)
        {
            if (ch == '%')
            {
                return ParseAspNet();
            }
            if (ch == '!')
            {
                ch = this.current.ReadChar();
                if (ch == '-')
                {
                    return ParseComment();
                }
                else if (ch == '[')
                {
                    return ParseConditionalBlock();
                }
                else if (ch != '_' && !Char.IsLetter(ch))
                {
                    string value = this.current.ScanToEnd(this.sb, "Recovering", ">"); 
                    Log("Ignoring invalid markup '<!" + value + ">");
                    return false;
                }
                else
                {
                    string name = this.current.ScanToken(this.sb, SgmlReader.declterm, false);
                    if (name == "DOCTYPE")
                    {
                        ParseDocType();
                        if (this.GetAttribute("SYSTEM") == null && this.GetAttribute("PUBLIC") != null)
                        {
                            this.node.AddAttribute("SYSTEM", "", '"', this.folding == CaseFolding.None);
                        }
                        if (stripDocType)
                        {
                            return false;
                        }
                        else
                        {
                            this.node.NodeType = XmlNodeType.DocumentType;
                            return true;
                        }
                    }
                    else
                    {
                        Log("Invalid declaration '<!{0}...'.  Expecting '<!DOCTYPE' only.", name);
                        this.current.ScanToEnd(null, "Recovering", ">");
                        return false;
                    }
                }
            }
            else if (ch == '?')
            {
                this.current.ReadChar();
                return ParsePI();
            }
            else if (ch == '/')
            {
                return ParseEndTag();
            }
            else
            {
                return ParseStartTag(ch);
            }
        }

        string ScanName(string terminators)
        {
            string name = this.current.ScanToken(this.sb, terminators, false);
            switch (this.folding)
            {
                case CaseFolding.ToUpper:
                    name = name.ToUpper();
                    break;
                case CaseFolding.ToLower:
                    name = name.ToLower();
                    break;
            }
            return this.nametable.Add(name);
        }

        static string tagterm = " \t\r\n=/><";
        static string aterm = " \t\r\n='\"/>";
        static string avterm = " \t\r\n>";
        bool ParseStartTag(char ch)
        {
            string name = null;
            if (state != State.PseudoStartTag)
            {
                if (SgmlReader.tagterm.IndexOf(ch) >= 0)
                {
                    this.sb.Length = 0;
                    this.sb.Append('<');
                    this.state = State.PartialText;
                    return false;
                }
                name = ScanName(SgmlReader.tagterm);
            }
            else
            {
                name = this.startTag;
                state = State.Markup;
            }
            Node n = Push(name, XmlNodeType.Element, null);
            n.IsEmpty = false;
            Validate(n);
            ch = this.current.SkipWhitespace();
            while (ch != Entity.EOF && ch != '>')
            {
                if (ch == '/')
                {
                    n.IsEmpty = true;
                    ch = this.current.ReadChar();
                    if (ch != '>')
                    {
                        Log("Expected empty start tag '/>' sequence instead of '{0}'", ch);
                        this.current.ScanToEnd(null, "Recovering", ">");
                        return false;
                    }
                    break;
                }
                else if (ch == '<')
                {
                    Log("Start tag '{0}' is missing '>'", name);
                    break;
                }
                string aname = ScanName(SgmlReader.aterm);
                ch = this.current.SkipWhitespace();
                if (aname == "," || aname == "=" || aname == ":" || aname == ";")
                {
                    continue;
                }
                string value = null;
                char quote = '\0';
                if (ch == '=' || ch == '"' || ch == '\'')
                {
                    if (ch == '=')
                    {
                        this.current.ReadChar();
                        ch = this.current.SkipWhitespace();
                    }
                    if (ch == '\'' || ch == '\"')
                    {
                        quote = ch;
                        value = ScanLiteral(this.sb, ch);
                    }
                    else if (ch != '>')
                    {
                        string term = SgmlReader.avterm;
                        value = this.current.ScanToken(this.sb, term, false);
                    }
                }
                if (aname.Length > 0)
                {
                    Attribute a = n.AddAttribute(aname, value, quote, this.folding == CaseFolding.None);
                    if (a == null)
                    {
                        Log("Duplicate attribute '{0}' ignored", aname);
                    }
                    else
                    {
                        ValidateAttribute(n, a);
                    }
                }
                ch = this.current.SkipWhitespace();
            }
            if (ch == Entity.EOF)
            {
                this.current.Error("Unexpected EOF parsing start tag '{0}'", name);
            }
            else if (ch == '>')
            {
                this.current.ReadChar(); 
            }
            if (this.Depth == 1)
            {
                if (this.rootCount == 1)
                {
                    this.state = State.Eof;
                    return false;
                }
                this.rootCount++;
            }
            ValidateContent(n);
            return true;
        }

        bool ParseEndTag()
        {
            this.state = State.EndTag;
            this.current.ReadChar(); 
            string name = this.ScanName(SgmlReader.tagterm);
            char ch = this.current.SkipWhitespace();
            if (ch != '>')
            {
                Log("Expected empty start tag '/>' sequence instead of '{0}'", ch);
                this.current.ScanToEnd(null, "Recovering", ">");
            }
            this.current.ReadChar(); 

            this.endTag = name;
                          
            bool caseInsensitive = (this.folding == CaseFolding.None);
            this.node = (Node)this.stack[this.stack.Count - 1];
            for (int i = this.stack.Count - 1; i > 0; i--)
            {
                Node n = (Node)this.stack[i];
                if (caseInsensitive && string.Compare(n.Name, name, true) == 0)
                {
                    this.endTag = n.Name;
                    return true;
                }
                else if ((object)n.Name == (object)name)
                {
                    return true;
                }
            }
            Log("No matching start tag for '</{0}>'", name);
            this.state = State.Markup;
            return false;
        }

        bool ParseAspNet()
        {
            string value = "<%" + this.current.ScanToEnd(this.sb, "AspNet", "%>") + "%>";
            Push(null, XmlNodeType.CDATA, value);
            return true;
        }

        bool ParseComment()
        {
            char ch = this.current.ReadChar();
            if (ch != '-')
            {
                Log("Expecting comment '<!--' but found {0}", ch);
                this.current.ScanToEnd(null, "Comment", ">");
                return false;
            }
            string value = this.current.ScanToEnd(this.sb, "Comment", "-->");

            int i = value.IndexOf("--");
            while (i >= 0)
            {
                int j = i + 2;
                while (j < value.Length && value[j] == '-')
                    j++;
                if (i > 0)
                {
                    value = value.Substring(0, i - 1) + "-" + value.Substring(j);
                }
                else
                {
                    value = "-" + value.Substring(j);
                }
                i = value.IndexOf("--");
            }
            if (value.Length > 0 && value[value.Length - 1] == '-')
            {
                value += " "; 
            }
            Push(null, XmlNodeType.Comment, value);
            return true;
        }

        static string cdataterm = "\t\r\n[<>";
        bool ParseConditionalBlock()
        {
            char ch = current.ReadChar(); 
            ch = current.SkipWhitespace();
            string name = current.ScanToken(sb, cdataterm, false);
            if (name != "CDATA")
            {
                Log("Expecting CDATA but found '{0}'", name);
                current.ScanToEnd(null, "CDATA", ">");
                return false;
            }
            ch = current.SkipWhitespace();
            if (ch != '[')
            {
                Log("Expecting '[' but found '{0}'", ch);
                current.ScanToEnd(null, "CDATA", ">");
                return false;
            }
            string value = current.ScanToEnd(sb, "CDATA", "]]>");

            Push(null, XmlNodeType.CDATA, value);
            return true;
        }

        static string dtterm = " \t\r\n>";
        void ParseDocType()
        {
            char ch = this.current.SkipWhitespace();
            string name = this.ScanName(SgmlReader.dtterm);
            Push(name, XmlNodeType.DocumentType, null);
            ch = this.current.SkipWhitespace();
            if (ch != '>')
            {
                string subset = "";
                string pubid = "";
                string syslit = "";

                if (ch != '[')
                {
                    string token = this.current.ScanToken(this.sb, SgmlReader.dtterm, false);
                    if (token == "PUBLIC")
                    {
                        ch = this.current.SkipWhitespace();
                        if (ch == '\"' || ch == '\'')
                        {
                            pubid = this.current.ScanLiteral(this.sb, ch);
                            this.node.AddAttribute(token, pubid, ch, this.folding == CaseFolding.None);
                        }
                    }
                    else if (token != "SYSTEM")
                    {
                        Log("Unexpected token in DOCTYPE '{0}'", token);
                        this.current.ScanToEnd(null, "DOCTYPE", ">");
                    }
                    ch = this.current.SkipWhitespace();
                    if (ch == '\"' || ch == '\'')
                    {
                        token = this.nametable.Add("SYSTEM");
                        syslit = this.current.ScanLiteral(this.sb, ch);
                        this.node.AddAttribute(token, syslit, ch, this.folding == CaseFolding.None);
                    }
                    ch = this.current.SkipWhitespace();
                }
                if (ch == '[')
                {
                    subset = this.current.ScanToEnd(this.sb, "Internal Subset", "]");
                    this.node.Value = subset;
                }
                ch = this.current.SkipWhitespace();
                if (ch != '>')
                {
                    Log("Expecting end of DOCTYPE tag, but found '{0}'", ch);
                    this.current.ScanToEnd(null, "DOCTYPE", ">");
                }

                if (this.dtd == null)
                {
                    this.docType = name;
                    this.pubid = pubid;
                    this.syslit = syslit;
                    this.subset = subset;
                    LazyLoadDtd(this.current.ResolvedUri);
                }
            }
            this.current.ReadChar();
        }

        static string piterm = " \t\r\n?";
        bool ParsePI()
        {
            string name = this.current.ScanToken(this.sb, SgmlReader.piterm, false);
            string value = null;
            if (this.current.Lastchar != '?')
            {
                value = this.current.ScanToEnd(this.sb, "Processing Instruction", ">");
            }
            else
            {
                value = this.current.ScanToEnd(this.sb, "Processing Instruction", ">");
            }

            if (name != "xml")
            {
                Push(nametable.Add(name), XmlNodeType.ProcessingInstruction, value);
                return true;
            }
            return false;
        }

        bool ParseText(char ch, bool newtext)
        {
            bool ws = !newtext || this.current.IsWhitespace;
            if (newtext) this.sb.Length = 0;

            this.state = State.Text;
            while (ch != Entity.EOF)
            {
                if (ch == '<')
                {
                    ch = this.current.ReadChar();
                    if (ch == '/' || ch == '!' || ch == '?' || Char.IsLetter(ch))
                    {
                        this.state = State.PartialTag;
                        this.partial = ch;
                        break;
                    }
                    else
                    {
                        this.sb.Append('<');
                        this.sb.Append(ch);
                        ws = false;
                        ch = this.current.ReadChar();
                    }
                }
                else if (ch == '&')
                {
                    ExpandEntity(this.sb, '<');
                    ws = false;
                    ch = this.current.Lastchar;
                }
                else
                {
                    if (!this.current.IsWhitespace) ws = false;
                    this.sb.Append(ch);
                    ch = this.current.ReadChar();
                }
            }
            string value = this.sb.ToString();
            Push(null, XmlNodeType.Text, value);
            return ws;
        }

        public string ScanLiteral(StringBuilder sb, char quote)
        {
            sb.Length = 0;
            char ch = this.current.ReadChar();
            while (ch != Entity.EOF && ch != quote)
            {
                if (ch == '&')
                {
                    ExpandEntity(this.sb, quote);
                    ch = this.current.Lastchar;
                }
                else
                {
                    sb.Append(ch);
                    ch = this.current.ReadChar();
                }
            }
            this.current.ReadChar();         
            return sb.ToString();
        }

        bool ParseCData()
        {
            bool ws = this.current.IsWhitespace;
            this.sb.Length = 0;
            char ch = this.current.Lastchar;
            if (this.partial != '\0')
            {
                Pop(); 
                switch (this.partial)
                {
                    case '!':
                        this.partial = ' '; 
                        return ParseComment();
                    case '?':
                        this.partial = ' '; 
                        return ParsePI();
                    case '/':
                        this.state = State.EndTag;
                        return true;   
                    case ' ':
                        break;
                }
            }
            else
            {
                ch = this.current.ReadChar();
            }

          
            while (ch != Entity.EOF)
            {
                if (ch == '<')
                {
                    ch = this.current.ReadChar();
                    if (ch == '!')
                    {
                        ch = this.current.ReadChar();
                        if (ch == '-')
                        {
                            if (ws)
                            {
                                this.partial = ' '; 
                                return ParseComment();
                            }
                            else
                            {
                                this.partial = '!';
                                break;
                            }
#if FIX
                        } else if (ch == '['){
                            if (this.ParseConditionalBlock()){
                                this.partial = ' ';
                                return true;
                            }
#endif
                        }
                        else
                        {
                            this.sb.Append('<');
                            this.sb.Append('!');
                            this.sb.Append(ch);
                            ws = false;
                        }
                    }
                    else if (ch == '?')
                    {
                        this.current.ReadChar();
                        if (ws)
                        {
                            this.partial = ' '; 
                            return ParsePI();
                        }
                        else
                        {
                            this.partial = '?';
                            break;
                        }
                    }
                    else if (ch == '/')
                    {
                        string temp = this.sb.ToString();
                        if (ParseEndTag() && this.endTag == (object)this.node.Name)
                        {
                            if (ws || temp == "")
                            {
                                return true;
                            }
                            else
                            {
                                this.partial = '/';
                                this.sb.Length = 0; 
                                this.sb.Append(temp);
                                this.state = State.CData;
                                break;
                            }
                        }
                        else
                        {
                            this.sb.Length = 0; 
                            this.sb.Append(temp);
                            this.sb.Append("</" + this.endTag + ">");
                            ws = false;
                        }
                    }
                    else
                    {
                        this.sb.Append('<');
                        this.sb.Append(ch);
                        ws = false;
                    }
                }
                else
                {
                    if (!this.current.IsWhitespace && ws) ws = false;
                    this.sb.Append(ch);
                }
                ch = this.current.ReadChar();
            }
            string value = this.sb.ToString();
            Push(null, XmlNodeType.CDATA, value);
            if (this.partial == '\0')
                this.partial = ' ';
            return true;
        }

        void ExpandEntity(StringBuilder sb, char terminator)
        {
            char ch = this.current.ReadChar();
            if (ch == '#')
            {
                string charent = this.current.ExpandCharEntity();
                sb.Append(charent);
                ch = this.current.Lastchar;
            }
            else
            {
                this.name.Length = 0;
                while (ch != Entity.EOF &&
                    (Char.IsLetter(ch) || ch == '_' || ch == '-'))
                {
                    this.name.Append(ch);
                    ch = this.current.ReadChar();
                }
                string name = this.name.ToString();
                if (this.dtd != null && name != "")
                {
                    Entity e = (Entity)this.dtd.FindEntity(name);
                    if (e != null)
                    {
                        if (e.Internal)
                        {
                            sb.Append(e.Literal);
                            if (ch != terminator)
                                ch = this.current.ReadChar();
                            return;
                        }
                        else
                        {
                            Entity ex = new Entity(name, e.PublicId, e.Uri, this.current.Proxy);
                            e.Open(this.current, new Uri(e.Uri));
                            this.current = ex;
                            this.current.ReadChar();
                            return;
                        }
                    }
                    else
                    {
                        Log("Undefined entity '{0}'", name);
                    }
                }
    
                sb.Append("&");
                sb.Append(name);
                if (ch != terminator)
                {
                    sb.Append(ch);
                    ch = this.current.ReadChar();
                }
            }
        }

        public override bool EOF
        {
            get
            {
                return this.state == State.Eof;
            }
        }

        public override void Close()
        {
            if (this.current != null)
            {
                this.current.Close();
                this.current = null;
            }
            if (this.log != null)
            {
                this.log.Close();
                this.log = null;
            }
        }

        public override ReadState ReadState
        {
            get
            {
                if (this.state == State.Initial) return ReadState.Initial;
                else if (this.state == State.Eof) return ReadState.EndOfFile;
                return ReadState.Interactive;
            }
        }

        public override string ReadString()
        {
            if (this.node.NodeType == XmlNodeType.Element)
            {
                this.sb.Length = 0;
                while (Read())
                {
                    switch (this.NodeType)
                    {
                        case XmlNodeType.CDATA:
                        case XmlNodeType.SignificantWhitespace:
                        case XmlNodeType.Whitespace:
                        case XmlNodeType.Text:
                            this.sb.Append(this.node.Value);
                            break;
                        default:
                            return this.sb.ToString();
                    }
                }
                return this.sb.ToString();
            }
            return this.node.Value;
        }


        public override string ReadInnerXml()
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xw.Formatting = Formatting.Indented;
            switch (this.NodeType)
            {
                case XmlNodeType.Element:
                    Read();
                    while (!this.EOF && this.NodeType != XmlNodeType.EndElement)
                    {
                        xw.WriteNode(this, true);
                    }
                    Read(); 
                    break;
                case XmlNodeType.Attribute:
                    sw.Write(this.Value);
                    break;
                default:
                 
                    break;
            }
            xw.Close();
            return sw.ToString();
        }

        public override string ReadOuterXml()
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xw.Formatting = Formatting.Indented;
            xw.WriteNode(this, true);
            xw.Close();
            return sw.ToString();
        }

        public override XmlNameTable NameTable
        {
            get
            {
                return this.nametable;
            }
        }

        public override string LookupNamespace(string prefix)
        {
            return null;
        }

        public override void ResolveEntity()
        {
            throw new InvalidOperationException("Not on an entity reference.");
        }

        public override bool ReadAttributeValue()
        {
            if (this.state == State.Attr)
            {
                this.state = State.AttrValue;
                return true;
            }
            else if (this.state == State.AttrValue)
            {
                return false;
            }
            throw new InvalidOperationException("Not on an attribute.");
        }

        void Validate(Node node)
        {
            if (this.dtd != null)
            {
                ElementDecl e = this.dtd.FindElement(node.Name);
                if (e != null)
                {
                    node.DtdType = e;
                    if (e.ContentModel.DeclaredContent == DeclaredContent.EMPTY)
                        node.IsEmpty = true;
                }
            }
        }

        void ValidateAttribute(Node node, Attribute a)
        {
            ElementDecl e = node.DtdType;
            if (e != null)
            {
                AttDef ad = e.FindAttribute(a.Name);
                if (ad != null)
                {
                    a.DtdType = ad;
                }
            }
        }

        void ValidateContent(Node node)
        {
            if (this.dtd != null)
            {                               
                string name = this.nametable.Add(node.Name.ToUpper()); 
                int i = 0;
                int top = this.stack.Count - 2;
                if (node.DtdType != null)
                {
                    for (i = top; i > 0; i--)
                    {
                        Node n = (Node)this.stack[i];
                        if (n.IsEmpty)
                            continue;
                        ElementDecl f = n.DtdType;
                        if (f != null)
                        {
                            if (f.Name == this.dtd.Name)
                                break;
                            if (f.CanContain(name, this.dtd))
                            {
                                break;
                            }
                            else if (!f.EndTagOptional)
                            {
                          
                                break;
                            }
                        }
                        else
                        {
                         
                            break;
                        }
                    }
                }
                if (i == 0)
                {

                }
                else if (i < top)
                {
                    Node n = (Node)this.stack[top];
                    if (i == top - 1 && name == n.Name)
                    {
                        
                    }
                    else
                    {
                        string closing = "";
                        for (int k = top; k >= i + 1; k--)
                        {
                            if (closing != "") closing += ",";
                            Node n2 = (Node)this.stack[k];
                            closing += "<" + n2.Name + ">";
                        }
                        Log("Element '{0}' not allowed inside '{1}', closing {2}.",
                            name, n.Name, closing);
                    }
                    this.state = State.AutoClose;
                    this.newnode = node;
                    Pop(); 
                    this.poptodepth = i + 1;
                }
            }
        }
    }
}


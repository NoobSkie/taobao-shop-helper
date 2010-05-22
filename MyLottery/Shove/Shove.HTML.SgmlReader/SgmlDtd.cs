namespace Shove.HTML.SgmlReader
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Text;
    using System.Xml;

    public class SgmlDtd
    {
        public string Name;

        Hashtable elements;
        Hashtable pentities;
        Hashtable entities;
        StringBuilder sb;
        Entity current;
        XmlNameTable nameTable;

        public SgmlDtd(string name, XmlNameTable nt)
        {
            this.nameTable = nt;
            this.Name = name;
            this.elements = new Hashtable();
            this.pentities = new Hashtable();
            this.entities = new Hashtable();
            this.sb = new StringBuilder();
        }

        public XmlNameTable NameTable { get { return this.nameTable; } }

        public static SgmlDtd Parse(Uri baseUri, string name, string pubid, string url, string subset, string proxy, XmlNameTable nt)
        {
            SgmlDtd dtd = new SgmlDtd(name, nt);
            if (url != null && url != "")
            {
                dtd.PushEntity(baseUri, new Entity(dtd.Name, pubid, url, proxy));
            }
            if (subset != null && subset != "")
            {
                dtd.PushEntity(baseUri, new Entity(name, subset));
            }
            try
            {
                dtd.Parse();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + dtd.current.Context());
            }
            return dtd;
        }
        public static SgmlDtd Parse(Uri baseUri, string name, string pubid, TextReader input, string subset, string proxy, XmlNameTable nt)
        {
            SgmlDtd dtd = new SgmlDtd(name, nt);
            dtd.PushEntity(baseUri, new Entity(dtd.Name, baseUri, input, proxy));
            if (subset != null && subset != "")
            {
                dtd.PushEntity(baseUri, new Entity(name, subset));
            }
            try
            {
                dtd.Parse();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + dtd.current.Context());
            }
            return dtd;
        }

        public Entity FindEntity(string name)
        {
            return (Entity)this.entities[name];
        }

        public ElementDecl FindElement(string name)
        {
            return (ElementDecl)this.elements[name.ToUpper()];
        }

        //-------------------------------- Parser -------------------------
        void PushEntity(Uri baseUri, Entity e)
        {
            e.Open(this.current, baseUri);
            this.current = e;
            this.current.ReadChar();
        }

        void PopEntity()
        {
            if (this.current != null) this.current.Close();
            if (this.current.Parent != null)
            {
                this.current = this.current.Parent;
            }
            else
            {
                this.current = null;
            }
        }

        void Parse()
        {
            char ch = this.current.Lastchar;
            while (true)
            {
                switch (ch)
                {
                    case Entity.EOF:
                        PopEntity();
                        if (this.current == null)
                            return;
                        ch = this.current.Lastchar;
                        break;
                    case ' ':
                    case '\n':
                    case '\r':
                    case '\t':
                        ch = this.current.ReadChar();
                        break;
                    case '<':
                        ParseMarkup();
                        ch = this.current.ReadChar();
                        break;
                    case '%':
                        Entity e = ParseParameterEntity(SgmlDtd.WhiteSpace);
                        try
                        {
                            PushEntity(this.current.ResolvedUri, e);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message + this.current.Context());
                        }
                        ch = this.current.Lastchar;
                        break;
                    default:
                        this.current.Error("Unexpected character '{0}'", ch);
                        break;
                }
            }
        }

        void ParseMarkup()
        {
            char ch = this.current.ReadChar();
            if (ch != '!')
            {
                this.current.Error("Found '{0}', but expecing declaration starting with '<!'");
                return;
            }
            ch = this.current.ReadChar();
            if (ch == '-')
            {
                ch = this.current.ReadChar();
                if (ch != '-') this.current.Error("Expecting comment '<!--' but found {0}", ch);
                this.current.ScanToEnd(this.sb, "Comment", "-->");
            }
            else if (ch == '[')
            {
                ParseMarkedSection();
            }
            else
            {
                string token = this.current.ScanToken(this.sb, SgmlDtd.WhiteSpace, true);
                switch (token)
                {
                    case "ENTITY":
                        ParseEntity();
                        break;
                    case "ELEMENT":
                        ParseElementDecl();
                        break;
                    case "ATTLIST":
                        ParseAttList();
                        break;
                    default:
                        this.current.Error("Invalid declaration '<!{0}'.  Expecting 'ENTITY', 'ELEMENT' or 'ATTLIST'.", token);
                        break;
                }
            }
        }

        char ParseDeclComments()
        {
            char ch = this.current.Lastchar;
            while (ch == '-')
            {
                ch = ParseDeclComment(true);
            }
            return ch;
        }

        char ParseDeclComment(bool full)
        {
            int start = this.current.Line;
            char ch = this.current.ReadChar();
            if (full && ch != '-') this.current.Error("Expecting comment delimiter '--' but found {0}", ch);
            this.current.ScanToEnd(this.sb, "Markup Comment", "--");
            return this.current.SkipWhitespace();
        }

        void ParseMarkedSection()
        {
            this.current.ReadChar(); 
            string name = ScanName("[");
            if (name == "INCLUDE")
            {
                ParseIncludeSection();
            }
            else if (name == "IGNORE")
            {
                ParseIgnoreSection();
            }
            else
            {
                this.current.Error("Unsupported marked section type '{0}'", name);
            }
        }

        void ParseIncludeSection()
        {
            throw new NotImplementedException("Include Section");
        }

        void ParseIgnoreSection()
        {
            int start = this.current.Line;
            // <!-^-...-->
            char ch = this.current.SkipWhitespace();
            if (ch != '[') this.current.Error("Expecting '[' but found {0}", ch);
            this.current.ScanToEnd(this.sb, "Conditional Section", "]]>");
        }

        string ScanName(string term)
        {
            char ch = this.current.SkipWhitespace();
            if (ch == '%')
            {
                Entity e = ParseParameterEntity(term);
                ch = this.current.Lastchar;
                if (!e.Internal) throw new NotSupportedException("External parameter entity resolution");
                return e.Literal.Trim();
            }
            else
            {
                return this.current.ScanToken(this.sb, term, true);
            }
        }

        Entity ParseParameterEntity(string term)
        {
            char ch = this.current.ReadChar();
            string name = this.current.ScanToken(this.sb, ";" + term, false);
            name = this.nameTable.Add(name);
            if (this.current.Lastchar == ';')
                this.current.ReadChar();
            Entity e = GetParameterEntity(name);
            return e;
        }

        Entity GetParameterEntity(string name)
        {
            Entity e = (Entity)this.pentities[name];
            if (e == null) this.current.Error("Reference to undefined parameter entity '{0}'", name);
            return e;
        }

        static string WhiteSpace = " \r\n\t";

        void ParseEntity()
        {
            char ch = this.current.SkipWhitespace();
            bool pe = (ch == '%');
            if (pe)
            {
                this.current.ReadChar(); 
                ch = this.current.SkipWhitespace();
            }
            string name = this.current.ScanToken(this.sb, SgmlDtd.WhiteSpace, true);
            name = this.nameTable.Add(name);
            ch = this.current.SkipWhitespace();
            Entity e = null;
            if (ch == '"' || ch == '\'')
            {
                string literal = this.current.ScanLiteral(this.sb, ch);
                e = new Entity(name, literal);
            }
            else
            {
                string pubid = null;
                string extid = null;
                string tok = this.current.ScanToken(this.sb, SgmlDtd.WhiteSpace, true);
                if (Entity.IsLiteralType(tok))
                {
                    ch = this.current.SkipWhitespace();
                    string literal = this.current.ScanLiteral(this.sb, ch);
                    e = new Entity(name, literal);
                    e.SetLiteralType(tok);
                }
                else
                {
                    extid = tok;
                    if (extid == "PUBLIC")
                    {
                        ch = this.current.SkipWhitespace();
                        if (ch == '"' || ch == '\'')
                        {
                            pubid = this.current.ScanLiteral(this.sb, ch);
                        }
                        else
                        {
                            this.current.Error("Expecting public identifier literal but found '{0}'", ch);
                        }
                    }
                    else if (extid != "SYSTEM")
                    {
                        this.current.Error("Invalid external identifier '{0}'.  Expecing 'PUBLIC' or 'SYSTEM'.", extid);
                    }
                    string uri = null;
                    ch = this.current.SkipWhitespace();
                    if (ch == '"' || ch == '\'')
                    {
                        uri = this.current.ScanLiteral(this.sb, ch);
                    }
                    else if (ch != '>')
                    {
                        this.current.Error("Expecting system identifier literal but found '{0}'", ch);
                    }
                    e = new Entity(name, pubid, uri, this.current.Proxy);
                }
            }
            ch = this.current.SkipWhitespace();
            if (ch == '-')
                ch = ParseDeclComments();
            if (ch != '>')
            {
                this.current.Error("Expecting end of entity declaration '>' but found '{0}'", ch);
            }
            if (pe) this.pentities.Add(e.Name, e);
            else this.entities.Add(e.Name, e);
        }

        void ParseElementDecl()
        {
            char ch = this.current.SkipWhitespace();
            string[] names = ParseNameGroup(ch, true);
            ch = Char.ToUpper(this.current.SkipWhitespace());
            bool sto = false;
            bool eto = false;
            if (ch == 'O' || ch == '-')
            {
                sto = (ch == 'O'); 
                this.current.ReadChar();
                ch = Char.ToUpper(this.current.SkipWhitespace());
                if (ch == 'O' || ch == '-')
                {
                    eto = (ch == 'O'); 
                    ch = this.current.ReadChar();
                }
            }
            ch = this.current.SkipWhitespace();
            ContentModel cm = ParseContentModel(ch);
            ch = this.current.SkipWhitespace();

            string[] exclusions = null;
            string[] inclusions = null;

            if (ch == '-')
            {
                ch = this.current.ReadChar();
                if (ch == '(')
                {
                    exclusions = ParseNameGroup(ch, true);
                    ch = this.current.SkipWhitespace();
                }
                else if (ch == '-')
                {
                    ch = ParseDeclComment(false);
                }
                else
                {
                    this.current.Error("Invalid syntax at '{0}'", ch);
                }
            }

            if (ch == '-')
                ch = ParseDeclComments();

            if (ch == '+')
            {
                ch = this.current.ReadChar();
                if (ch != '(')
                {
                    this.current.Error("Expecting inclusions name group", ch);
                }
                inclusions = ParseNameGroup(ch, true);
                ch = this.current.SkipWhitespace();
            }

            if (ch == '-')
                ch = ParseDeclComments();


            if (ch != '>')
            {
                this.current.Error("Expecting end of ELEMENT declaration '>' but found '{0}'", ch);
            }

            foreach (string name in names)
            {
                string atom = name.ToUpper();
                atom = this.nameTable.Add(name);
                this.elements.Add(atom, new ElementDecl(atom, sto, eto, cm, inclusions, exclusions));
            }
        }

        static string ngterm = " \r\n\t|,)";
        string[] ParseNameGroup(char ch, bool nmtokens)
        {
            ArrayList names = new ArrayList();
            if (ch == '(')
            {
                ch = this.current.ReadChar();
                ch = this.current.SkipWhitespace();
                while (ch != ')')
                {             
                    ch = this.current.SkipWhitespace();
                    if (ch == '%')
                    {
                        Entity e = ParseParameterEntity(SgmlDtd.ngterm);
                        PushEntity(this.current.ResolvedUri, e);
                        ParseNameList(names, nmtokens);
                        PopEntity();
                        ch = this.current.Lastchar;
                    }
                    else
                    {
                        string token = this.current.ScanToken(this.sb, SgmlDtd.ngterm, nmtokens);
                        token = token.ToUpper();
                        string atom = this.nameTable.Add(token);
                        names.Add(atom);
                    }
                    ch = this.current.SkipWhitespace();
                    if (ch == '|' || ch == ',') ch = this.current.ReadChar();
                }
                this.current.ReadChar(); 
            }
            else
            {
                string name = this.current.ScanToken(this.sb, SgmlDtd.WhiteSpace, nmtokens);
                name = name.ToUpper();
                name = this.nameTable.Add(name);
                names.Add(name);
            }
            return (string[])names.ToArray(typeof(String));
        }

        void ParseNameList(ArrayList names, bool nmtokens)
        {
            char ch = this.current.Lastchar;
            ch = this.current.SkipWhitespace();
            while (ch != Entity.EOF)
            {
                string name;
                if (ch == '%')
                {
                    Entity e = ParseParameterEntity(SgmlDtd.ngterm);
                    PushEntity(this.current.ResolvedUri, e);
                    ParseNameList(names, nmtokens);
                    PopEntity();
                    ch = this.current.Lastchar;
                }
                else
                {
                    name = this.current.ScanToken(this.sb, SgmlDtd.ngterm, true);
                    name = name.ToUpper();
                    name = this.nameTable.Add(name);
                    names.Add(name);
                }
                ch = this.current.SkipWhitespace();
                if (ch == '|')
                {
                    ch = this.current.ReadChar();
                    ch = this.current.SkipWhitespace();
                }
            }
        }

        static string dcterm = " \r\n\t>";
        ContentModel ParseContentModel(char ch)
        {
            ContentModel cm = new ContentModel();
            if (ch == '(')
            {
                this.current.ReadChar();
                ParseModel(')', cm);
                ch = this.current.ReadChar();
                if (ch == '?' || ch == '+' || ch == '*')
                {
                    cm.AddOccurrence(ch);
                    this.current.ReadChar();
                }
            }
            else if (ch == '%')
            {
                Entity e = ParseParameterEntity(SgmlDtd.dcterm);
                PushEntity(this.current.ResolvedUri, e);
                cm = ParseContentModel(this.current.Lastchar);
                PopEntity();
            }
            else
            {
                string dc = ScanName(SgmlDtd.dcterm);
                cm.SetDeclaredContent(dc);
            }
            return cm;
        }

        static string cmterm = " \r\n\t,&|()?+*";
        void ParseModel(char cmt, ContentModel cm)
        {
            int depth = cm.CurrentDepth;
            char ch = this.current.Lastchar;
            ch = this.current.SkipWhitespace();
            while (ch != cmt || cm.CurrentDepth > depth) 
            {
                if (ch == Entity.EOF)
                {
                    this.current.Error("Content Model was not closed");
                }
                if (ch == '%')
                {
                    Entity e = ParseParameterEntity(SgmlDtd.cmterm);
                    PushEntity(this.current.ResolvedUri, e);
                    ParseModel(Entity.EOF, cm);
                    PopEntity();
                    ch = this.current.SkipWhitespace();
                }
                else if (ch == '(')
                {
                    cm.PushGroup();
                    this.current.ReadChar();
                    ch = this.current.SkipWhitespace();
                }
                else if (ch == ')')
                {
                    ch = this.current.ReadChar();
                    if (ch == '*' || ch == '+' || ch == '?')
                    {
                        cm.AddOccurrence(ch);
                        ch = this.current.ReadChar();
                    }
                    if (cm.PopGroup() < depth)
                    {
                        this.current.Error("Parameter entity cannot close a paren outside it's own scope");
                    }
                    ch = this.current.SkipWhitespace();
                }
                else if (ch == ',' || ch == '|' || ch == '&')
                {
                    cm.AddConnector(ch);
                    this.current.ReadChar(); 
                    ch = this.current.SkipWhitespace();
                }
                else
                {
                    string token;
                    if (ch == '#')
                    {
                        ch = this.current.ReadChar();
                        token = "#" + this.current.ScanToken(this.sb, SgmlDtd.cmterm, true); 
                    }
                    else
                    {
                        token = this.current.ScanToken(this.sb, SgmlDtd.cmterm, true);
                    }
                    token = token.ToUpper();
                    token = this.nameTable.Add(token);
                    ch = this.current.Lastchar;
                    if (ch == '?' || ch == '+' || ch == '*')
                    {
                        cm.PushGroup();
                        cm.AddSymbol(token);
                        cm.AddOccurrence(ch);
                        cm.PopGroup();
                        this.current.ReadChar(); 
                        ch = this.current.SkipWhitespace();
                    }
                    else
                    {
                        cm.AddSymbol(token);
                        ch = this.current.SkipWhitespace();
                    }
                }
            }
        }

        void ParseAttList()
        {
            char ch = this.current.SkipWhitespace();
            string[] names = ParseNameGroup(ch, true);
            AttList attlist = new AttList();
            ParseAttList(attlist, '>');
            foreach (string name in names)
            {
                ElementDecl e = (ElementDecl)this.elements[name];
                if (e == null)
                {
                    this.current.Error("ATTLIST references undefined ELEMENT {0}", name);
                }
                e.AddAttDefs(attlist);
            }
        }

        static string peterm = " \t\r\n>";
        void ParseAttList(AttList list, char term)
        {
            char ch = this.current.SkipWhitespace();
            while (ch != term)
            {
                if (ch == '%')
                {
                    Entity e = ParseParameterEntity(SgmlDtd.peterm);
                    PushEntity(this.current.ResolvedUri, e);
                    ParseAttList(list, Entity.EOF);
                    PopEntity();
                    ch = this.current.SkipWhitespace();
                }
                else if (ch == '-')
                {
                    ch = ParseDeclComments();
                }
                else
                {
                    AttDef a = ParseAttDef(ch);
                    list.Add(a);
                }
                ch = this.current.SkipWhitespace();
            }
        }

        AttDef ParseAttDef(char ch)
        {
            ch = this.current.SkipWhitespace();
            string name = ScanName(SgmlDtd.WhiteSpace);
            name = name.ToUpper();
            name = this.nameTable.Add(name);
            AttDef attdef = new AttDef(name);

            ch = this.current.SkipWhitespace();
            if (ch == '-')
                ch = ParseDeclComments();

            ParseAttType(ch, attdef);

            ch = this.current.SkipWhitespace();
            if (ch == '-')
                ch = ParseDeclComments();

            ParseAttDefault(ch, attdef);

            ch = this.current.SkipWhitespace();
            if (ch == '-')
                ch = ParseDeclComments();

            return attdef;

        }

        void ParseAttType(char ch, AttDef attdef)
        {
            if (ch == '%')
            {
                Entity e = ParseParameterEntity(SgmlDtd.WhiteSpace);
                PushEntity(this.current.ResolvedUri, e);
                ParseAttType(this.current.Lastchar, attdef);
                PopEntity(); 
                ch = this.current.Lastchar;
                return;
            }

            if (ch == '(')
            {
                attdef.EnumValues = ParseNameGroup(ch, false);
                attdef.Type = AttributeType.ENUMERATION;
            }
            else
            {
                string token = ScanName(SgmlDtd.WhiteSpace);
                if (token == "NOTATION")
                {
                    ch = this.current.SkipWhitespace();
                    if (ch != '(')
                    {
                        this.current.Error("Expecting name group '(', but found '{0}'", ch);
                    }
                    attdef.Type = AttributeType.NOTATION;
                    attdef.EnumValues = ParseNameGroup(ch, true);
                }
                else
                {
                    attdef.SetType(token);
                }
            }
        }

        void ParseAttDefault(char ch, AttDef attdef)
        {
            if (ch == '%')
            {
                Entity e = ParseParameterEntity(SgmlDtd.WhiteSpace);
                PushEntity(this.current.ResolvedUri, e);
                ParseAttDefault(this.current.Lastchar, attdef);
                PopEntity(); 
                ch = this.current.Lastchar;
                return;
            }

            bool hasdef = true;
            if (ch == '#')
            {
                this.current.ReadChar();
                string token = this.current.ScanToken(this.sb, SgmlDtd.WhiteSpace, true);
                hasdef = attdef.SetPresence(token);
                ch = this.current.SkipWhitespace();
            }
            if (hasdef)
            {
                if (ch == '\'' || ch == '"')
                {
                    string lit = this.current.ScanLiteral(this.sb, ch);
                    attdef.Default = lit;
                    ch = this.current.SkipWhitespace();
                }
                else
                {
                    string name = this.current.ScanToken(this.sb, SgmlDtd.WhiteSpace, false);
                    name = name.ToUpper();
                    name = this.nameTable.Add(name);
                    attdef.Default = name; 
                    ch = this.current.SkipWhitespace();
                }
            }
        }
    }   
}


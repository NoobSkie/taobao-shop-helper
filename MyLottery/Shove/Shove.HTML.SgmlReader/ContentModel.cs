namespace Shove.HTML.SgmlReader
{
    using System;

    public class ContentModel
    {
        public int CurrentDepth;
        public Shove.HTML.SgmlReader.DeclaredContent DeclaredContent;
        public Group Model = new Group(null);

        public void AddConnector(char c)
        {
            this.Model.AddConnector(c);
        }

        public void AddOccurrence(char c)
        {
            this.Model.AddOccurrence(c);
        }

        public void AddSymbol(string sym)
        {
            this.Model.AddSymbol(sym);
        }

        public bool CanContain(string name, SgmlDtd dtd)
        {
            if (this.DeclaredContent != Shove.HTML.SgmlReader.DeclaredContent.Default)
            {
                return false;
            }
            return this.Model.CanContain(name, dtd);
        }

        public int PopGroup()
        {
            if (this.CurrentDepth == 0)
            {
                return -1;
            }
            this.CurrentDepth--;
            this.Model.Parent.AddGroup(this.Model);
            this.Model = this.Model.Parent;
            return this.CurrentDepth;
        }

        public void PushGroup()
        {
            this.Model = new Group(this.Model);
            this.CurrentDepth++;
        }

        public void SetDeclaredContent(string dc)
        {
            switch (dc)
            {
                case "EMPTY":
                    this.DeclaredContent = Shove.HTML.SgmlReader.DeclaredContent.EMPTY;
                    return;

                case "RCDATA":
                    this.DeclaredContent = Shove.HTML.SgmlReader.DeclaredContent.RCDATA;
                    return;

                case "CDATA":
                    this.DeclaredContent = Shove.HTML.SgmlReader.DeclaredContent.CDATA;
                    return;
            }
            throw new Exception(string.Format("Declared content type '{0}' is not supported", dc));
        }
    }
}


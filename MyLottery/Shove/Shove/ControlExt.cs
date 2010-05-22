namespace Shove
{
    using System;
    using System.Data;
    using System.Web.UI.WebControls;

    public class ControlExt
    {
        public static int FillDropDownList(DropDownList ddl, DataTable dt, string TextFieldName, string ValueFieldName)
        {
            ddl.Items.Clear();
            if ((dt == null) || (dt.Rows.Count < 1))
            {
                return -1;
            }
            foreach (DataRow row in dt.Rows)
            {
                ddl.Items.Add(new ListItem(row[TextFieldName].ToString(), row[ValueFieldName].ToString()));
            }
            if (ddl.Items.Count > 0)
            {
                ddl.SelectedIndex = 0;
            }
            return ddl.Items.Count;
        }

        public static int FillDropDownList(DropDownList ddl, DataTable dt, string TextFieldName, string IDFieldName, string ParentIDFieldName, long FirstLevelParentIDValue)
        {
            ddl.Items.Clear();
            if ((dt == null) || (dt.Rows.Count < 1))
            {
                return -1;
            }
            foreach (DataRow row in dt.Select(ParentIDFieldName + "=" + FirstLevelParentIDValue))
            {
                ddl.Items.Add(new ListItem(row[TextFieldName].ToString(), row[IDFieldName].ToString()));
                SetDropdownListItems(ddl, dt, TextFieldName, IDFieldName, ParentIDFieldName, row[IDFieldName].ToString(), 1);
            }
            if (ddl.Items.Count > 0)
            {
                ddl.SelectedIndex = 0;
            }
            return ddl.Items.Count;
        }

        public static int FillListBox(ListBox lb, DataTable dt, string TextField, string ValueField)
        {
            lb.Items.Clear();
            if ((dt == null) || (dt.Rows.Count < 1))
            {
                return -1;
            }
            foreach (DataRow row in dt.Rows)
            {
                lb.Items.Add(new ListItem(row[TextField].ToString(), row[ValueField].ToString()));
            }
            if (lb.Items.Count > 0)
            {
                lb.SelectedIndex = 0;
            }
            return lb.Items.Count;
        }

        public static int SetDownListBoxText(DropDownList ddl, string Text)
        {
            if (ddl.Items.Count == 0)
            {
                return -1;
            }
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Text == Text)
                {
                    ddl.SelectedIndex = i;
                    return i;
                }
            }
            return -2;
        }

        public static int SetDownListBoxTextFromValue(DropDownList ddl, string Value)
        {
            if (ddl.Items.Count == 0)
            {
                return -1;
            }
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Value == Value)
                {
                    ddl.SelectedIndex = i;
                    return i;
                }
            }
            return -2;
        }

        public static int SetListBoxText(ListBox lb, string Text)
        {
            if (lb.Items.Count == 0)
            {
                return -1;
            }
            for (int i = 0; i < lb.Items.Count; i++)
            {
                if (lb.Items[i].Text == Text)
                {
                    lb.SelectedIndex = i;
                    return i;
                }
            }
            return -2;
        }

        public static int SetListBoxTextFromValue(ListBox lb, string Value)
        {
            if (lb.Items.Count == 0)
            {
                return -1;
            }
            for (int i = 0; i < lb.Items.Count; i++)
            {
                if (lb.Items[i].Value == Value)
                {
                    lb.SelectedIndex = i;
                    return i;
                }
            }
            return -2;
        }

        public static TreeNode SetTreeViewSelected(TreeView tv, string Text)
        {
            if ((tv != null) && (tv.Nodes.Count >= 1))
            {
                foreach (TreeNode node in tv.Nodes)
                {
                    if (node.Text == Text)
                    {
                        node.Selected = true;
                        return node;
                    }
                }
            }
            return null;
        }

        public static TreeNode SetTreeViewSelectedFromValue(TreeView tv, string Value)
        {
            if ((tv != null) && (tv.Nodes.Count >= 1))
            {
                foreach (TreeNode node in tv.Nodes)
                {
                    if (node.Value == Value)
                    {
                        node.Selected = true;
                        return node;
                    }
                }
            }
            return null;
        }

        private static void SetDropdownListItems(DropDownList ddl, DataTable dt, string textFieldName, string idFieldName, string parentIDFieldName, string parentIDFieldValue, int spaceCount)
        {
            string str = "".PadLeft(spaceCount, '　');
            spaceCount++;
            foreach (DataRow row in dt.Select(parentIDFieldName + "=" + parentIDFieldValue))
            {
                ddl.Items.Add(new ListItem(str + row[textFieldName].ToString(), row[idFieldName].ToString()));
                SetDropdownListItems(ddl, dt, textFieldName, idFieldName, parentIDFieldName, row[idFieldName].ToString(), spaceCount);
            }
        }

        public class Item
        {
            public string Text;
            public object Value;

            public Item()
            {
                this.Text = "";
                this.Value = null;
            }

            public Item(string text)
            {
                this.Text = text;
                this.Value = null;
            }

            public Item(string text, object value)
            {
                this.Text = text;
                this.Value = value;
            }

            public override string ToString()
            {
                return this.Text;
            }
        }
    }
}


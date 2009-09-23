using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using TOP.Core.Facade;

namespace TOP.Applications.ItemDescriptionEdit
{
    public delegate void RemoveItem(Control ctrl);

    public partial class FrmDescriptionEdit : Form
    {
        public FrmDescriptionEdit()
        {
            InitializeComponent();
        }

        private string lastImageUrl = string.Empty;

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            CtrlImage ctrl = new CtrlImage();
            ctrl.BorderStyle = BorderStyle.Fixed3D;
            ctrl.OnRemoveItem = OnRemoveImageItem;
            fpnlImageList.Controls.Add(ctrl);

            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Html))
            {
                string html = iData.GetData(DataFormats.Html).ToString();
                int indexStart = html.IndexOf("SourceURL:", StringComparison.OrdinalIgnoreCase);
                int indexEnd = html.IndexOf("<!DOCTYPE HTML PUBLIC", StringComparison.OrdinalIgnoreCase);
                if (indexStart >= 0 && indexEnd > indexStart)
                {
                    string src = html.Substring(indexStart + "SourceURL:".Length, indexEnd - indexStart - "SourceURL:".Length);
                    indexStart = html.IndexOf("<IMG", StringComparison.OrdinalIgnoreCase);
                    if (indexStart >= 0)
                    {
                        indexEnd = html.IndexOf(">", indexStart, StringComparison.OrdinalIgnoreCase);
                        if (indexEnd > indexStart)
                        {
                            string img = html.Substring(indexStart, indexEnd - indexStart + 1);
                            indexStart = img.IndexOf("src=\"", StringComparison.OrdinalIgnoreCase);
                            if (indexStart >= 0)
                            {
                                indexEnd = img.IndexOf("\"", indexStart + "src=\"".Length, StringComparison.OrdinalIgnoreCase);
                                if (indexEnd > indexStart)
                                {
                                    string imgUrl = img.Substring(indexStart + "src=\"".Length, indexEnd - indexStart - "src=\"".Length).Trim('"');
                                    if (CheckImage(imgUrl))
                                    {
                                        if (CheckWebSite(imgUrl))
                                        {
                                            if (lastImageUrl != imgUrl)
                                            {
                                                ctrl.Value = imgUrl;
                                                lastImageUrl = imgUrl;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (iData.GetDataPresent(DataFormats.Text))
            {
                string imgUrl = iData.GetData(DataFormats.Text).ToString();
                if (CheckImage(imgUrl))
                {
                    if (CheckWebSite(imgUrl))
                    {
                        if (lastImageUrl != imgUrl)
                        {
                            ctrl.Value = imgUrl;
                            lastImageUrl = imgUrl;
                        }
                    }
                }
            }
        }

        private bool CheckImage(string imgUrl)
        {
            string currentPath = Assembly.GetExecutingAssembly().Location;
            string dir = new FileInfo(currentPath).DirectoryName;

            if (File.Exists(dir + "\\AllowImageExt.txt"))
            {
                using (StreamReader reader = new StreamReader(dir + "\\AllowImageExt.txt", Encoding.Default))
                {
                    string item = reader.ReadLine();
                    while (!string.IsNullOrEmpty(item))
                    {
                        if (imgUrl.EndsWith(item, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }

                        item = reader.ReadLine();
                    }
                }
            }
            return false;
        }

        private bool CheckWebSite(string imgUrl)
        {
            string currentPath = Assembly.GetExecutingAssembly().Location;
            string dir = new FileInfo(currentPath).DirectoryName;

            if (File.Exists(dir + "\\AllowImageCopySiteList.txt"))
            {
                using (StreamReader reader = new StreamReader(dir + "\\AllowImageCopySiteList.txt", Encoding.Default))
                {
                    string item = reader.ReadLine();
                    while (!string.IsNullOrEmpty(item))
                    {
                        if (imgUrl.IndexOf(item, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            return true;
                        }

                        item = reader.ReadLine();
                    }
                }
            }
            return false;
        }

        private void OnRemoveImageItem(Control ctrl)
        {
            fpnlImageList.Controls.Remove(ctrl);
        }

        private void btnAddAttr_Click(object sender, EventArgs e)
        {
            CtrlAttr ctrl = new CtrlAttr();
            ctrl.BorderStyle = BorderStyle.Fixed3D;
            ctrl.OnRemoveItem = OnRemoveAttrItem;
            fpnlAttrList.Controls.Add(ctrl);
        }

        private void OnRemoveAttrItem(Control ctrl)
        {
            fpnlAttrList.Controls.Remove(ctrl);
        }

        private void btnSelectItems_Click(object sender, EventArgs e)
        {
            FrmSelectItems frm = new FrmSelectItems();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (SampleListItem item in frm.SelectedIidList)
                {
                    CtrlSelectedItem ctrl = new CtrlSelectedItem();
                    ctrl.LoadItem(item.Id, item.Title, item.Price, item.PicPath, item.Location);
                    ctrl.OnRemoveItem = OnRemoveItemItem;
                    fpnlItemList.Controls.Add(ctrl);
                }
            }
        }

        private void OnRemoveItemItem(Control ctrl)
        {
            fpnlItemList.Controls.Remove(ctrl);
        }

        private void GenCodeAndCopy()
        {
            string currentPath = Assembly.GetExecutingAssembly().Location;
            string dir = new FileInfo(currentPath).DirectoryName;
            string img = string.Empty;
            foreach (CtrlImage ctrl in fpnlImageList.Controls)
            {
                if (!string.IsNullOrEmpty(ctrl.Value))
                {
                    using (StreamReader readerImg = new StreamReader(dir + "\\template_img.htm"))
                    {
                        string imgHtmlFormat = readerImg.ReadToEnd();
                        img += string.Format(imgHtmlFormat, ctrl.Value);
                    }
                }
            }
            string attr = string.Empty;
            foreach (CtrlAttr ctrl in fpnlAttrList.Controls)
            {
                if (!string.IsNullOrEmpty(ctrl.AttrName))
                {
                    using (StreamReader readerAttr = new StreamReader(dir + "\\template_attr.htm"))
                    {
                        string imgHtmlFormat = readerAttr.ReadToEnd();
                        attr += string.Format(imgHtmlFormat, ctrl.AttrName, ctrl.AttrValue);
                    }
                }
            }
            string item = string.Empty;
            foreach (CtrlSelectedItem ctrl in fpnlItemList.Controls)
            {
                using (StreamReader readerItem = new StreamReader(dir + "\\template_item.htm"))
                {
                    string itemHtmlFormat = readerItem.ReadToEnd();
                    item += string.Format(itemHtmlFormat, ctrl.Iid, ctrl.ItemName, ctrl.ImageUrl);
                }
            }
            using (StreamReader reader = new StreamReader(dir + "\\template.htm"))
            {
                string html = reader.ReadToEnd();
                html = html.Replace("{ProductDisplayDiv}", img);
                html = html.Replace("{SpecificationsDiv}", attr);
                html = html.Replace("{SimilarProductDiv}", item);
                Clipboard.SetDataObject(html);
            }
        }

        private void btnCode_Click(object sender, EventArgs e)
        {
            GenCodeAndCopy();
            InitControls();

            i = 0;
            timer.Start();
        }

        int i = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            i++;
            if (i >= 10)
            {
                lblMsg.Visible = false;
                timer.Stop();
            }
            else
            {
                lblMsg.Visible = true;
            }
        }

        private void InitControls()
        {
            fpnlImageList.Controls.Clear();
            fpnlAttrList.Controls.Clear();
            fpnlItemList.Controls.Clear();

            string currentPath = Assembly.GetExecutingAssembly().Location;
            string dir = new FileInfo(currentPath).DirectoryName;

            if (File.Exists(dir + "\\default_attr.txt"))
            {
                using (StreamReader reader = new StreamReader(dir + "\\default_attr.txt", Encoding.Default))
                {
                    string item = reader.ReadLine();
                    while (!string.IsNullOrEmpty(item))
                    {
                        CtrlAttr ctrl = new CtrlAttr();
                        ctrl.BorderStyle = BorderStyle.Fixed3D;
                        ctrl.OnRemoveItem = OnRemoveAttrItem;

                        string[] attr = item.Split(':');
                        if (attr.Length == 1)
                        {
                            ctrl.AttrName = attr[0];
                        }
                        else if (attr.Length == 2)
                        {
                            ctrl.AttrName = attr[0];
                            ctrl.AttrValue = attr[1];
                        }
                        fpnlAttrList.Controls.Add(ctrl);

                        item = reader.ReadLine();
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            InitControls();
        }

        private void FrmDescriptionEdit_Load(object sender, EventArgs e)
        {
            InitControls();
        }
    }
}

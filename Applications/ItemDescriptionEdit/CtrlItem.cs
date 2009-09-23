using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TOP.Applications.ItemDescriptionEdit
{
    public partial class CtrlItem : UserControl
    {
        public CtrlItem()
        {
            InitializeComponent();
        }

        private string _iid;
        public string Iid
        {
            get
            {
                return _iid;
            }
        }

        private string itemName;
        public string ItemName
        {
            get
            {
                return itemName;
            }
        }

        private string _price;
        public string Price
        {
            get
            {
                return _price;
            }
        }

        private string imagePath;
        public string ImagePath
        {
            get
            {
                return imagePath;
            }
        }

        private string imageUrl;
        public string ImageUrl
        {
            get
            {
                return imageUrl;
            }
        }

        public void LoadItem(string iid, string title, string price, string imgPath, string imgUrl)
        {
            imgView.ImageLocation = imgPath;
            cb.Text = title;

            imageUrl = imgUrl;
            imagePath = imgPath;
            _iid = iid;
            itemName = title;
            _price = price;
        }

        public bool Checked { get { return cb.Checked; } }
    }
}

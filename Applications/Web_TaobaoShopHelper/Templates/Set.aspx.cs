﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;
using System.IO;
using TOP.Template.Facade;

namespace TOP.Applications.TaobaoShopHelper.Templates
{
    public partial class Set : BasePage, IMenuPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CurrentUser == null)
                {
                    lbtnSave.Enabled = false;
                    lbtnCancel.Enabled = false;

                    DisplayInformations(GetUnLoginInformation());
                }
                else
                {
                    BindTemplateList();
                }
            }
        }

        private void BindTemplateList()
        {
            TemplateFacade facade = new TemplateFacade();
            List<TemplateInfo> templateList = facade.GetTemplateInfoListByUserId(CurrentUser.Id);
            rptTemplateList.DataSource = templateList;
            rptTemplateList.DataBind();
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string content;
            using (StreamReader reader = new StreamReader(fuFile.FileContent))
            {
                content = reader.ReadToEnd();
                reader.Close();
            }
            TemplateFacade facade = new TemplateFacade();
            facade.CreateTemplate(name, content, CurrentUser.Id);
            SetSuccessInformation("添加模板成功！");
        }

        protected void lbtnCancel_Click(object sender, EventArgs e)
        {

        }

        #region IMenuPage Members

        public string GetTopMenuId()
        {
            return "Template";
        }

        public string GetSecondMenuId()
        {
            return "Set";
        }

        #endregion
    }
}

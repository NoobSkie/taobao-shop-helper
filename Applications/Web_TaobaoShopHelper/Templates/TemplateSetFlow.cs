using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TOP.Template.Facade;

namespace TOP.Applications.TaobaoShopHelper.Templates
{
    /// <summary>
    /// 模板设置流程
    /// </summary>
    public class TemplateSetFlow
    {
        private List<TemplateSetItem> currentFlow;
        public List<TemplateSetItem> CurrentFlowList
        {
            get
            {
                if (currentFlow == null)
                {
                    currentFlow = new List<TemplateSetItem>();
                }
                return currentFlow;
            }
            set
            {
                currentFlow = value;
            }
        }

        public void AddFlow(TemplateSetItem flow)
        {
            flow.Index = GetMaxIndex();
            CurrentFlowList.Add(flow);
        }

        public void MoveUp(TemplateSetItem flow)
        {
            for (int i = 0; i < CurrentFlowList.Count; i++)
            {
                if (CurrentFlowList[i].Equals(flow))
                {
                    if (i > 0)
                    {
                        CurrentFlowList.RemoveAt(i);
                        CurrentFlowList.Insert(i - 1, flow);
                    }
                    break;
                }
            }
        }

        public void MoveDown(TemplateSetItem flow)
        {
            for (int i = 0; i < CurrentFlowList.Count; i++)
            {
                if (CurrentFlowList[i].Equals(flow))
                {
                    if (i < CurrentFlowList.Count - 1)
                    {
                        CurrentFlowList.RemoveAt(i);
                        CurrentFlowList.Insert(i + 1, flow);
                    }
                    break;
                }
            }
        }

        public void Remove(TemplateSetItem flow)
        {
            for (int i = 0; i < CurrentFlowList.Count; i++)
            {
                if (CurrentFlowList[i].Equals(flow))
                {
                    CurrentFlowList.RemoveAt(i);
                    break;
                }
            }
        }

        private int GetMaxIndex()
        {
            int index = 0;
            foreach (TemplateSetItem item in CurrentFlowList)
            {
                if (item.Index > index)
                {
                    index = item.Index;
                }
            }
            return index + 1;
        }
    }

    [Serializable]
    public class TemplateSetItem
    {
        public TemplateSetItem()
        {
            Iid = Guid.NewGuid();
        }

        private Guid Iid { get; set; }

        public string Action { get; set; }

        public string ContainerId { get; set; }

        public int ChildrenCount { get; set; }

        public string Value { get; set; }

        public int Index { get; set; }

        public TemplateObject Template { get; set; }

        public override bool Equals(object obj)
        {
            TemplateSetItem item = obj as TemplateSetItem;
            return Iid.Equals(item.Iid);
        }

        public override int GetHashCode()
        {
            return Iid.GetHashCode();
        }
    }
}

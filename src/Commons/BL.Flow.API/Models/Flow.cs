using System.Collections.Generic;

namespace BL.Flows.API.Models
{
    public class Flow
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string School { get; set; }

        public void BuildText() => Text = string.Join("_", CommonInfo.Title, CommonInfo.Creator.Name, CommonInfo.Creator.Org?.Name, Business);

        /// <summary>
        /// 流程业务[请假,出差等]
        /// </summary>
        public FlowBusiness Business { get; set; }

        /// <summary>
        /// 业务记录Id
        /// </summary>
        public string BusinessKeyId { get; set; }

        /// <summary>
        /// 业务内容
        /// </summary>
        public List<FlowBusinessContentsItem> BusinessContents { get; private set; }

        /// <summary>
        /// 流程通用信息
        /// </summary>
        public FlowCommonInfo CommonInfo { get; set; } = new FlowCommonInfo();

        /// <summary>
        /// 流程进度情况
        /// </summary>
        public FlowProcess Process { get; set; } = new FlowProcess();

        /// <summary>
        /// 流程状态
        /// </summary>
        public FlowStatus Status { get; set; } = new FlowStatus();

        /// <summary>
        /// 处理状态(用于流程结束后,业务系统需做后续处理)
        /// </summary>
        public bool DealStatus { get; set; }

        public void AddContentsItem(string label, string value)
        {
            BusinessContents.Add(new FlowBusinessContentsItem { Lable = label, Value = value });
        }
    }
}

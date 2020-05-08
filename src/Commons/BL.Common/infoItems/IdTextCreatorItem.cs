using BL.Common.Reflection;

namespace BL.Common
{
    /// <summary>
    /// 包含主键,搜索文本,创建信息的基类
    /// </summary>
    public class IdTextCreatorItem : IText
    {
        public IdTextCreatorItem() { }
        public IdTextCreatorItem(string id, string text) { Id = id; Text = text; }
        [PropertyMark("主键Id")]
        public string Id { get; set; }
        [PropertyMark("搜索文本")]
        public string Text { get; set; }
        /// <summary>
        /// 创建信息
        /// </summary>
        public OperatorItem Creator { get; set; }


        public override string ToString()
        {
            return Text;
        }

        void IText.BuildText()
        {
            throw new System.NotImplementedException();
        }
    }
}

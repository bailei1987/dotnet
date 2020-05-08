namespace BL.Common
{
    public interface IText
    {
        string Text { get; set; }
        /// <summary>
        /// 生成Text字段值,用于关键词查找
        /// </summary>
        void BuildText();
    }
    public interface IRid
    {
        string Rid { get; set; }
        /// <summary>
        /// 生成Id字段值,用作主键
        /// </summary>
        void BuildRid();
    }
}

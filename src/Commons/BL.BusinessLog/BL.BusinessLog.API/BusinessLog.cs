namespace BL.BusinessLog
{
    public class BusinessLog
    {
        public string Id { get; set; }
        public string Text { get; set; }

        public BusinessApp App { get; set; }
        public string Business { get; set; }
        public string OperateType { get; set; }
        public string Key { get; set; }
        public string Filter { get; set; }
        public string Update { get; set; }
        public long EffectCount { get; set; }
        public string Content { get; set; }
        public BusinessOperator Operator { get; set; }
    }

}

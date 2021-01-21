namespace BL.Flows.Domain
{
    public class FlowBusinessContentsItem
    {
        public FlowBusinessContentsItem(string label, string value)
        {
            Lable = label;
            Value = value;
        }
        public string Lable { get; private set; }
        public string Value { get; private set; }
    }
}

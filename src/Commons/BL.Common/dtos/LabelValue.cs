namespace BL.Common
{
    public class LabelValue<T>
    {
        public LabelValue() { }
        public LabelValue(string label,T value) { Label = label;Value = value; }
        public string Label { get; set; }
        public T Value { get; set; }
    }
}

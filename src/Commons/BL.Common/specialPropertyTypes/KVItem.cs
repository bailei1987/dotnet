namespace BL.Common
{
    public class KVItem
    {
        public KVItem() { }
        public KVItem(string k, string v) { K = k; V = v; }
        public string K { get; set; }
        public string V { get; set; }
        public override string ToString()
        {
            return V;
        }

        public bool IsIntegrated()
        {
            return string.IsNullOrEmpty(K) == false && string.IsNullOrEmpty(V) == false;
        }
    }
    public class KVItem<T>
    {
        public string K { get; set; }
        public T V { get; set; }
    }
}

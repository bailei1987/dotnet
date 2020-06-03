namespace BL.Regions
{
    public class RegionKV
    {
        public RegionKV() { }
        public RegionKV(string k, string v) { K = k; V = v; }
        public string K { get; set; }
        public string V { get; set; }
        public override string ToString()
        {
            return V;
        }
    }
}

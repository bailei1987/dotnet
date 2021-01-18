namespace BL.Flows.API.Models
{
    public class FlowReferenceItem
    {
        public FlowReferenceItem() { }
        public FlowReferenceItem(string rid, string name) { Rid = rid; Name = name; }
        public string Rid { get; set; }
        public string Name { get; set; }
    }
}

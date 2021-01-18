namespace BL.Flows.API.Models
{
    public class FlowCommonInfo
    {
        public string Title { get; set; }
        public FlowCreator Creator { get; set; }
        public FlowDefReference FlowDef { get; set; }
    }
}

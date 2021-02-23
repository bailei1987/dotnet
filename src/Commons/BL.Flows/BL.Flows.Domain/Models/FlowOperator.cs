using System;

namespace BL.Flows.Domain
{
    public class FlowOperator
    {
        public string Rid { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Rid) || string.IsNullOrWhiteSpace(Name) || Time == default) throw new("creator is not correct");
        }
    }
}

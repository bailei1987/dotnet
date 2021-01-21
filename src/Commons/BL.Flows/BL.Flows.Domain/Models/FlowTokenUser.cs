using System;

namespace BL.Flows.Domain
{
    public class FlowTokenUser
    {
        public string Rid { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string School { get; set; }
        public string Tag1 { get; set; }

        public FlowOperator ToOperator()
        {
            return new FlowOperator
            {
                Name = Name,
                Rid = Rid,
                Time = DateTime.Now
            };
        }
    }
}

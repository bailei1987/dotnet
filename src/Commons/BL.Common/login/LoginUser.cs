using System;

namespace BL.Common
{
    public class LoginUser
    {
        public string Rid { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string School { get; set; }
        public string Tag1 { get; set; }

        public OperatorItem ToOperator()
        {
            return new()
            {
                Name = Name,
                Rid = Rid,
                Time = DateTime.Now
            };
        }
    }
}

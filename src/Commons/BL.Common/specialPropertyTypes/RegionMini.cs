using System.Collections.Generic;

namespace BL.Common
{
    public class RegionMini : IIntegrate
    {
        public List<string> Codes { get; set; } = new();
        public List<string> Names { get; set; } = new();
        public string Text
        {
            get => Names.Count > 0 ? string.Join("/", Names) : null;
        }

        public override string ToString()
        {
            return Text;
        }
        public bool IsIntegrated()
        {
            return Codes.Count == 3 && Names.Count == 3;
        }
        public bool IsEmpty
        {
            get => Codes is null || Names is null || Codes.Count == 0 || Names.Count == 0;
        }
    }
}

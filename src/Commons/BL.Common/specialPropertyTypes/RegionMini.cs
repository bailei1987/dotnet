using System.Collections.Generic;

namespace BL.Common
{
    public class RegionMini : IIntegrate
    {
        public RegionMini()
        {
            Codes = new List<string>();
            Names = new List<string>();
        }
        public List<string> Codes { get; set; }
        public List<string> Names { get; set; }
        public string Text
        {
            get
            {
                if (Names.Count > 0) return string.Join("/", Names);
                else return null;
            }
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

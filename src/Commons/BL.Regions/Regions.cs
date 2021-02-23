using System.Collections.Generic;
using System.Linq;

namespace BL.Regions
{
    public partial class Regions
    {
#pragma warning disable IDE0051 // 删除未使用的私有成员
        private static object BuildAllLongNames()
#pragma warning restore IDE0051 // 删除未使用的私有成员
        {
            var alls = All().ToList();
            Dictionary<string, RegionItem> list = new();
            var strs = new List<string>();
            var ps = alls.FindAll(x => x.K.EndsWith("0000"));
            var cs = alls.FindAll(x => x.K.EndsWith("0000") == false && x.K.EndsWith("00"));
            var ds = alls.FindAll(x => x.K.EndsWith("00") == false);
            foreach (var p in ps)
            {
                foreach (var c in cs.FindAll(x => x.K.StartsWith(p.K.Substring(0, 2))))
                {
                    foreach (var d in ds.FindAll(x => x.K.StartsWith(c.K.Substring(0, 4))))
                    {
                        list.Add(p.V + c.V + d.V, new()
                        {
                            Codes = new() { p.K, c.K, d.K },
                            Names = new() { p.V, c.V, d.V }
                        });
                        strs.Add(string.Format("startxxcv \"{0}\",new() startxxcv Codes=[\"{1}\",\"{2}\",\"{3}\"],Names=[\"{4}\",\"{5}\",\"{6}\"] endxxcv endxxcv,",
                             p.V + c.V + d.V,
                             p.K, c.K, d.K,
                             p.V, c.V, d.V
                         ));
                    }
                }
            }
            var str = string.Join("\n", strs);
            return list;
        }
    }
    public class RegionItem
    {
        public List<string> Codes { get; set; } = new();
        public List<string> Names { get; set; } = new();
    }
}

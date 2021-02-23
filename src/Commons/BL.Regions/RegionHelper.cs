using System.Collections.Generic;
using System.Linq;

namespace BL.Regions
{
    public static class RegionHelper
    {
        public static List<RegionCascaderItem> GetProvinceCityDistrict(int? level = null)
        {
            var regions = Regions.All();
            var provinceList = regions.Where(w => w.K.EndsWith("0000")).ToList();
            List<RegionCascaderItem> list = new();
            foreach (var item in provinceList)
            {
                RegionCascaderItem province = new()
                {
                    Value = item.K,
                    Label = item.V,
                    Children = new()
                };
                list.Add(province);
                if (level is null or >= 2)
                {
                    var start = item.K.Substring(0, 2);
                    var clist = regions.Where(w => w.K.StartsWith(start) && w.K.EndsWith("00") && !w.K.EndsWith("0000")).ToList();
                    foreach (var it in clist)
                    {
                        RegionCascaderItem cityDto = new()
                        {
                            Value = it.K,
                            Label = it.V
                        };
                        province.Children.Add(cityDto);
                        if (level is null or >= 3)
                        {
                            var start1 = it.K.Substring(0, 4);
                            cityDto.Children = regions.Where(w => w.K.StartsWith(start1) && !w.K.EndsWith("00")).Select(w => new RegionCascaderItem
                            {
                                Value = w.K,
                                Label = w.V,
                                Children = new()
                            }).ToList();
                        }
                    }
                }
            }
            return list;
        }

        public static IEnumerable<RegionCascaderItem> GetChilds(string parentCode = null)
        {
            var regions = Regions.All();
            if (parentCode is null)
            {
                return regions.Where(w => w.K.EndsWith("0000"))
                    .Select(x => new RegionCascaderItem() { Value = x.K, Label = x.V, Children = new(), Loading = false });
            }
            if (parentCode.Length != 6) throw new("地区代码不正确");
            if (parentCode.EndsWith("0000"))
            {
                return regions.Where(w => w.K.StartsWith(parentCode.Substring(0, 2)) && w.K.EndsWith("00") && !w.K.EndsWith("0000"))
                    .Select(x => new RegionCascaderItem() { Value = x.K, Label = x.V, Children = new(), Loading = false });
            }
            else if (parentCode.EndsWith("00"))
            {
                return regions.Where(w => w.K.StartsWith(parentCode.Substring(0, 4)) && !w.K.EndsWith("00"))
                    .Select(x => new RegionCascaderItem() { Value = x.K, Label = x.V, Children = new() }); ;
            }
            throw new("地区代码不正确");
        }

        public static object GetByCodes(List<string[]> codes)
        {
            return codes.Count == 0
                ? throw new("参数不正确,正确格式:[['110000','110100','110101'],['340000','341800','341825']]")
                : codes.Find(x => x.Length == 0) != null
                ? throw new("参数不正确,正确格式:[['110000','110100','110101'],['340000','341800','341825']]")
                : null;
        }
    }
}

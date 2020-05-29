using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Common
{
    public static class RegionHelper
    {
        public static List<CascaderItem> GetProvinceCityDistrict(int? level = null)
        {
            var regions = Regions.All();
            var provinceList = regions.Where(w => w.K.EndsWith("0000")).ToList();
            List<CascaderItem> list = new List<CascaderItem>();
            foreach (var item in provinceList)
            {
                CascaderItem province = new CascaderItem
                {
                    Value = item.K,
                    Label = item.V,
                    Children = new List<CascaderItem>()
                };
                list.Add(province);
                if (level == null || level >= 2)
                {
                    var start = item.K.Substring(0, 2);
                    var clist = regions.Where(w => w.K.StartsWith(start) && w.K.EndsWith("00") && !w.K.EndsWith("0000")).ToList();
                    foreach (var it in clist)
                    {
                        CascaderItem cityDto = new CascaderItem
                        {
                            Value = it.K,
                            Label = it.V
                        };
                        province.Children.Add(cityDto);
                        if (level == null || level >= 3)
                        {
                            var start1 = it.K.Substring(0, 4);
                            cityDto.Children = regions.Where(w => w.K.StartsWith(start1) && !w.K.EndsWith("00")).Select(w => new CascaderItem
                            {
                                Value = w.K,
                                Label = w.V,
                                Children = new List<CascaderItem>()
                            }).ToList();
                        }
                    }
                }
            }
            return list;
        }

        public static IEnumerable<CascaderItem> GetChilds(string parentCode = null)
        {
            var regions = Regions.All();
            if (parentCode is null)
            {
                return regions.Where(w => w.K.EndsWith("0000"))
                    .Select(x => new CascaderItem() { Value = x.K, Label = x.V, Children = new List<CascaderItem>(), Loading = false });
            }
            if (parentCode.Length != 6) throw new Exception("地区代码不正确");
            if (parentCode.EndsWith("0000"))
            {
                return regions.Where(w => w.K.StartsWith(parentCode.Substring(0, 2)) && w.K.EndsWith("00") && !w.K.EndsWith("0000"))
                    .Select(x => new CascaderItem() { Value = x.K, Label = x.V, Children = new List<CascaderItem>(), Loading = false });
            }
            else if (parentCode.EndsWith("00"))
            {
                return regions.Where(w => w.K.StartsWith(parentCode.Substring(0, 4)) && !w.K.EndsWith("00"))
                    .Select(x => new CascaderItem() { Value = x.K, Label = x.V, Children = new List<CascaderItem>() }); ;
            }
            throw new Exception("地区代码不正确");
        }

        public static object GetByCodes(List<string[]> codes)
        {
            if (codes.Count == 0) throw new Exception("参数不正确,正确格式:[['110000','110100','110101'],['340000','341800','341825']]");
            if (codes.Find(x => x.Length == 0) != null) throw new Exception("参数不正确,正确格式:[['110000','110100','110101'],['340000','341800','341825']]");
            return null;
        }
    }
}

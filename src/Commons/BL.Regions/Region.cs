using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Regions
{
    public class Region
    {
        public string Str { get; set; }
        public List<string> Codes { get; set; } = new();
        public List<string> Names { get; set; } = new();
        public string Text
        {
            get
            {
                return Names.Count > 0 ? string.Join('/', Names) : null;
            }
        }

        public override string ToString()
        {
            return Text;
        }
        public string Fill(object sourceValue)
        {
            if (sourceValue is IEnumerable<object> array)
            {
                Str = string.Join("/", array);
                foreach (var item in array)
                {
                    Codes.Add(Convert.ToString(item));
                }
            }
            else
            {
                string code = sourceValue?.ToString();
                Str = code;
                if (string.IsNullOrWhiteSpace(code)) return "行政区划代码不正确";
                var splits = code.Split(',', ' ', '.', '/', '|');
                foreach (var item in splits)
                {
                    Codes.Add(item);
                }
            }
            return FillByCodesOrNames(1);
        }

        public static string GetCodesStr(Region region)
        {
            return region is null ? null : string.Join(',', region.Codes);
        }
        public string FillByCodesOrNames(int type)
        {
            List<string> vals = null;
            List<string> others = null;
            if (type == 1)
            {
                vals = Codes;
                others = Names;
            }
            else
            {
                vals = Names;
                others = Codes;
            }
            if (vals == null || vals.Count == 0) return null;
            List<string> msgs = new();
            vals = vals.FindAll(x => string.IsNullOrWhiteSpace(x) == false);
            Str = string.Join("/", vals);
            if (vals.Count > 3)
            {
                msgs.Add("传入数据超过(省,市,区)3个");
                return string.Join("|", msgs);
            }
            var alls = Regions.All();
            if (vals.Count == 3)
            {
                var province = alls.FirstOrDefault(x => type == 1 ? vals[0] == x.K : vals[0] == x.V);
                if (province != null) others.Add(type == 1 ? province.V : province.K);
                else
                {
                    others.Add(null);
                    msgs.Add("省[" + (type == 1 ? "行政区划码" : "行政区划名称") + "]不正确");
                }
                var city = alls.FirstOrDefault(x => type == 1 ? vals[1] == x.K : vals[1] == x.V);
                if (city != null)
                {
                    others.Add(type == 1 ? city.V : city.K);
                }
                else
                {
                    others.Add(null);
                    msgs.Add("市[" + (type == 1 ? "行政区划码" : "行政区划名称") + "]不正确");
                }
                var district = alls.FirstOrDefault(x => type == 1 ? vals[2] == x.K : vals[2] == x.V);
                if (district != null) others.Add(type == 1 ? district.V : district.K);
                else
                {
                    others.Add(null);
                    msgs.Add("区/县[" + (type == 1 ? "行政区划码" : "行政区划名称") + "]不正确");
                }
            }
            else if (vals.Count == 2)
            {
                var province = alls.FirstOrDefault(x => type == 1 ? vals[0] == x.K : vals[0] == x.V);
                if (province != null) others.Add(type == 1 ? province.V : province.K);
                else
                {
                    others.Add(null);
                    msgs.Add("省[" + (type == 1 ? "行政区划码" : "行政区划名称") + "]不正确");
                }
                var city = alls.FirstOrDefault(x => type == 1 ? vals[1] == x.K : vals[1] == x.V);
                if (city != null)
                {
                    others.Add(type == 1 ? city.V : city.K);
                }
                else
                {
                    others.Add(null);
                    msgs.Add("市[" + (type == 1 ? "行政区划码" : "行政区划名称") + "]不正确");
                }
            }
            else if (vals.Count == 1)
            {
                var value = vals[0];
                vals.Clear();
                //如果是行政区划码
                var region = alls.FirstOrDefault(x => type == 1 ? value == x.K : value == x.V);
                if (region == null)
                {
                    vals.Add(value);
                    others.Add(null);
                    msgs.Add((type == 1 ? "行政区划码" : "行政区划名称") + "不正确");
                }
                else
                {
                    if (region.K.EndsWith("0000"))
                    {
                        vals.Add(value);
                        others.Add(type == 1 ? region.V : region.K);
                    }
                    else if (region.K.EndsWith("0000") == false && region.K.EndsWith("00"))
                    {
                        var province = alls.First(x => x.K == region.K.Substring(0, 2) + "0000");
                        vals.Add(type == 1 ? province.K : province.V);
                        others.Add(type == 1 ? province.V : province.K);
                        vals.Add(type == 1 ? region.K : region.V);
                        others.Add(type == 1 ? region.V : region.K);
                    }
                    else
                    {
                        var province = alls.First(x => x.K == region.K.Substring(0, 2) + "0000");
                        vals.Add(type == 1 ? province.K : province.V);
                        others.Add(type == 1 ? province.V : province.K);
                        var city = alls.First(x => x.K == region.K.Substring(0, 4) + "00");
                        vals.Add(type == 1 ? city.K : city.V);
                        others.Add(type == 1 ? city.V : city.K);
                        vals.Add(type == 1 ? region.K : region.V);
                        others.Add(type == 1 ? region.V : region.K);
                    }
                }
            }
            var msg = string.Join("|", msgs);
            return msg == "" ? null : msg;
        }

        public string FillByCodes()
        {
            return FillByCodesOrNames(1);
        }

        public string FillByNames()
        {
            return FillByCodesOrNames(2);
        }
        public void FillByLongName()
        {
            if (string.IsNullOrWhiteSpace(Str)) return;
            var alls = Regions.AllLongNameAsKey();
            _ = alls.TryGetValue(Str, out RegionItem region);
            if (region != null)
            {
                Codes = region.Codes;
                Names = region.Names;
            }
        }
        public void ReFillByLongName()
        {
            Codes?.Clear();
            Names?.Clear();
            FillByLongName();
        }

        public string ReFillByCodes()
        {
            Names?.Clear();
            return FillByCodesOrNames(1);
        }
        public string ReFillByNames()
        {
            Codes?.Clear();
            return FillByCodesOrNames(2);
        }

        public bool IsIntegrated()
        {
            return Codes.Count == 3 && Names.Count == 3;
        }
    }
}

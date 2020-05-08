/*
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Common
{
    [Obsolete]
    public class DicItem : KVItem, IFill
    {
        public DicItem() { }
        public DicItem(string k, string v) : base(k, v) { }
        public DicItem FindOption(string text) { return Fill(AllOption(), text); }

        protected virtual DicItem[] AllOption() { return null; }
        protected DicItem Fill(DicItem[] options, string text)
        {
            var option = options.FirstOrDefault(x => x.K == text || x.V == text);
            if (option != null)
            {
                K = option.K;
                V = option.V;
            }
            else
            {
                V = text;
            }
            return this;
        }


        public void FillByV() { FillByV(AllOption()); }
        protected void FillByV(DicItem[] options)
        {
            if (string.IsNullOrWhiteSpace(V)) return;
            var option = options.FirstOrDefault(x => x.V == V);
            if (option != null) K = option.K;
        }
        public string Fill(object sourceValue)
        {
            V = sourceValue?.ToString();
            FillByV();
            return !string.IsNullOrWhiteSpace(K) ? null : "无匹配";
        }
public static Dictionary<string, DicItem[]> GetDics(params string[] dicKeys)
{
    Dictionary<string, DicItem[]> dics = new Dictionary<string, DicItem[]>();
    foreach (var key in dicKeys)
    {
        var type = Type.GetType("jg.dictionarys.Dic" + key);
        var dic = Activator.CreateInstance(type) as DicItem;
        if (dic is null) throw new Exception("该字典key值(" + key + ")不正确");
        dics.Add(key, dic.AllOption());
    }
    return dics;
}
public static string GetV(DicItem item)
{
    return item?.V;
}


    }
}
*/
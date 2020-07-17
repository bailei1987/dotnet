
using System.Collections.Generic;
using BL.Common;

namespace BL.Dictionary
{
    public class DictionaryItemKV
    {

        public string K { get; set; }
        public string V { get; set; }
    }
    public class DictionaryItem : DictionaryItemKV
    {
        public DictionaryItem()
        {

        }
        public string Id { get; set; }
        public string Type { get; set; }
        public string Order { get; set; }
        public string Desc { get; set; }
    }
    public static class DictionaryExtentions
    {
        public static void FillByDictionary(this KVItem item, List<DictionaryItemKV> list)
        {
            if (item is null || string.IsNullOrWhiteSpace(item.V)) return;
            var dic = list.Find(x => x.V == item.V);
            if (dic != null)
            {
                item.K = dic.K;
                item.V = dic.V;
            }
        }
    }
}

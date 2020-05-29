using System.Collections.Generic;
using BL.Common;

namespace BL.Common
{
    public static class SystemDictionary
    {
        private static Dictionary<string, List<KVItem>> dics = new Dictionary<string, List<KVItem>>
        {

        };

        public static void Init(Dictionary<string, List<KVItem>> dic)
        {
            dics = dic;
        }
        public static List<KVItem> Get(string type)
        {
            if (dics.ContainsKey(type) == false) throw new KeyNotFoundException($"type [{type}] is not correct");
            return dics[type];
        }
        public static Dictionary<string, List<KVItem>> GetMany(string[] types)
        {
            Dictionary<string, List<KVItem>> res = new Dictionary<string, List<KVItem>>();
            foreach (var type in types)
            {
                if (dics.TryGetValue(type, out List<KVItem> value)) res.Add(type, value);
            }
            return res;
        }
    }
}

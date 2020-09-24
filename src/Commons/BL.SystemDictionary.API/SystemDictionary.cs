using System;
using System.Collections.Generic;

namespace BL.SystemDictionary
{
    public class SystemDictionaryKV
    {
        public SystemDictionaryKV() { }
        public SystemDictionaryKV(string k, string v) { K = k; V = v; }
        public string K { get; set; }
        public string V { get; set; }
    }
    public static class SystemDictionary
    {
        private static Dictionary<string, List<SystemDictionaryKV>> dics = new Dictionary<string, List<SystemDictionaryKV>>
        {

        };

        public static void Init(Dictionary<string, List<SystemDictionaryKV>> dic)
        {
            dics = dic;
        }
        public static List<SystemDictionaryKV> Get(string type)
        {
            if (dics.ContainsKey(type) == false) throw new KeyNotFoundException($"type [{type}] is not correct");
            return dics[type];
        }
        public static Dictionary<string, List<SystemDictionaryKV>> GetMany(string[] types)
        {
            Dictionary<string, List<SystemDictionaryKV>> res = new Dictionary<string, List<SystemDictionaryKV>>();
            foreach (var type in types)
            {
                if (dics.TryGetValue(type, out List<SystemDictionaryKV> value)) res.Add(type, value);
            }
            return res;
        }
        public static SystemDictionaryKV GetItemByV(string type, string v)
        {
            if (dics.ContainsKey(type) == false) throw new KeyNotFoundException($"type [{type}] is not correct");
            return dics[type].Find(x => x.V == v) ?? throw new Exception($"can not find item by v [{v}] in {type}'s items");
        }
        public static SystemDictionaryKV GetItemByK(string type, string k)
        {
            if (dics.ContainsKey(type) == false) throw new KeyNotFoundException($"type [{type}] is not correct");
            return dics[type].Find(x => x.K == k) ?? throw new Exception($"can not find item by k [{k}] in {type}'s items");
        }
    }
}

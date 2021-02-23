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
        private static Dictionary<string, List<SystemDictionaryKV>> dics = new() { };

        public static void Init(Dictionary<string, List<SystemDictionaryKV>> dic)
        {
            dics = dic;
        }
        public static List<SystemDictionaryKV> Get(string type)
        {
            return dics.ContainsKey(type) switch
            {
                false => throw new KeyNotFoundException($"type [{type}] is not correct"),
                _ => dics[type],
            };
        }
        public static Dictionary<string, List<SystemDictionaryKV>> GetMany(string[] types)
        {
            Dictionary<string, List<SystemDictionaryKV>> res = new();
            foreach (var type in types)
            {
                if (dics.TryGetValue(type, out List<SystemDictionaryKV> value)) res.Add(type, value);
            }
            return res;
        }
        public static SystemDictionaryKV GetItemByV(string type, string v)
        {
            return dics.ContainsKey(type) switch
            {
                false => throw new KeyNotFoundException($"type [{type}] is not correct"),
                _ => dics[type].Find(x => x.V == v) ?? throw new($"can not find item by v [{v}] in {type}'s items")
            };
        }
        public static SystemDictionaryKV GetItemByK(string type, string k)
        {
            return dics.ContainsKey(type) switch
            {
                false => throw new KeyNotFoundException($"type [{type}] is not correct"),
                _ => dics[type].Find(x => x.K == k) ?? throw new($"can not find item by k [{k}] in {type}'s items")
            };
        }
    }
}

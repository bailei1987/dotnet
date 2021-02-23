using BL.Common;
using System;

namespace BL.StandardDictionary
{
    public static class KVItemExtensions
    {
        public static KVItem FillStandardByV(this KVItem obj, Type type)
        {
            if (string.IsNullOrWhiteSpace(obj.V)) throw new("V cant be null");
            if (type.IsSubclassOf(typeof(DicItem)) == false) throw new("type is not correct,must be subclass of StandardDictionary type");
            var dic = Activator.CreateInstance(type) as DicItem;
            dic.V = obj.V;
            dic.FillByV();
            obj.K = dic.K;
            return obj;
        }

        public static KVItem FillStandardByK(this KVItem obj, Type type)
        {
            if (string.IsNullOrWhiteSpace(obj.K)) throw new("K cant be null");
            if (type.IsSubclassOf(typeof(DicItem)) == false) throw new("type is not correct,must be subclass of StandardDictionary type");
            var dic = Activator.CreateInstance(type) as DicItem;
            dic.K = obj.K;
            dic.FillByK();
            obj.V = dic.V;
            return obj;
        }
    }
}

using System;
using BL.Common;

namespace BL.StandardDictionary
{
    public static class KVItemExtensions
    {
        public static void FillStandardByV(this KVItem obj, Type type)
        {
            if (string.IsNullOrWhiteSpace(obj.V)) throw new Exception("V cant be null");
            if (type.IsSubclassOf(typeof(DicItem)) == false) throw new Exception("type is not correct,must be subclass of StandardDictionary type");
            var dic = Activator.CreateInstance(type) as DicItem;
            dic.V = obj.V;
            dic.FillByV();
            obj.K = dic.K;
        }

        public static void FillStandardByK(this KVItem obj, Type type)
        {
            if (string.IsNullOrWhiteSpace(obj.K)) throw new Exception("K cant be null");
            if (type.IsSubclassOf(typeof(DicItem)) == false) throw new Exception("type is not correct,must be subclass of StandardDictionary type");
            var dic = Activator.CreateInstance(type) as DicItem;
            dic.K = obj.K;
            dic.FillByK();
            obj.V = dic.V;
        }
    }
}

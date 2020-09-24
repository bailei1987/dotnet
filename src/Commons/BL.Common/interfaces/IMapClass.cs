using System;

namespace BL.Common
{
    public interface IMapClass<T>
    {
        T GetMapClass(Action<T> action = null);
    }
    public interface IMapClassOnly<T>
    {
        T GetMapClass();
    }
    public interface IFromMapClass<Tfrom, Tto>
    {
        Tto FromMapClass(Tfrom tfrom);
    }
}

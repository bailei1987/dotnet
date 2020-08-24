using System;

namespace BL.Common
{
    public interface IMapClassFrom<T>
    {
        T GetMapClassFrom(T from, Action<T> action = null);
    }
}

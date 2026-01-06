using System;

namespace HW29_30
{
    public interface IReadOnlyVariable<T>
    {
        event Action Changed;

        T Value { get; }
    }
}

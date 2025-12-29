using System;

namespace HW29_30
{
    public interface IReadOnlyElement<TEnum, K>
    {
        event Action<TEnum, K> Changed;

        TEnum Type { get; }
        K Value { get; }
    }
}

using System;

namespace HW29_30
{
    public class ReactiveElement<TEnum, K> : IReadOnlyElement<TEnum, K> where TEnum : Enum where K : IEquatable<K>
    {
        public event Action<TEnum, K> Changed;

        private TEnum _type;
        private K _value;

        public ReactiveElement(TEnum type)
        {
            _type = type;
            _value = default(K);
        }

        public ReactiveElement(TEnum type, K value)
        {
            _type = type;
            _value = value;
        }

        public TEnum Type => _type;

        public K Value
        {
            get => _value;
            set
            {
                K oldValue = _value;

                _value = value;

                if (_value.Equals(oldValue) == false)
                    Changed?.Invoke(_type, _value);
            }
        }
    }
}

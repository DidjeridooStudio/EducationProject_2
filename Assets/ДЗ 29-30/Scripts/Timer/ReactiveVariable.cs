using System;

namespace HW29_30
{
    public class ReactiveVariable<T> : IReadOnlyVariable<T> where T : IEquatable<T>
    {
        public event Action Changed;

        private T _value;

        public ReactiveVariable(T value)
        {
            _value = value;
        }

        public T Value
        {
            get => _value;
            set
            {
                T oldValue = _value;

                _value = value;

                if (_value.Equals(oldValue) == false)
                    Changed?.Invoke();
            }
        }
    }
}

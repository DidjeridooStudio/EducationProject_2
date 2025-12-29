using System;

namespace HW29_30
{
    public class ReactiveVariable<T> : IReadOnlyVariable<T> where T : IEquatable<T>
    {
        public event Action Changed;
        public event Action Reseted;

        private T _value;
        private T _initialValue;

        public ReactiveVariable(T value)
        {
            _value = value;
            _initialValue = value;
        }

        public T Value
        {
            get => _value;
            set
            {
                T oldValue = _value;

                _value = value;

                if (_value.Equals(_initialValue) == true)
                {
                    Reseted?.Invoke();
                }
                else
                {
                    if (_value.Equals(oldValue) == false)
                        Changed?.Invoke();
                }
            }
        }

        public T InitialValue { get => _initialValue; set => _initialValue = value; }
    }
}

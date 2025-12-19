using UnityEngine;

namespace HW27_28
{
    public class Currency
    {
        public CurrencyType Type;
        public int Value;

        public Currency(CurrencyType type)
        {
            Type = type;
        }
    }
}

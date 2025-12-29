using System;
using System.Collections.Generic;
using UnityEngine;

namespace HW29_30
{
    public class Wallet
    {
        private List<ReactiveElement<CurrencyType, int>> _currencies;

        public Wallet()
        {
            _currencies = new List<ReactiveElement<CurrencyType, int>>(); ;
            _currencies.Add(new ReactiveElement<CurrencyType, int>(CurrencyType.Coin));
            _currencies.Add(new ReactiveElement<CurrencyType, int>(CurrencyType.Diamond));
            _currencies.Add(new ReactiveElement<CurrencyType, int>(CurrencyType.Energy));
        }

        public IReadOnlyList<IReadOnlyElement<CurrencyType, int>> Currencies => _currencies;

        public void AddCurrency(CurrencyFilter currencyFilter, int value)
        {
            if (IsValueValid(value) == false)
                return;

            foreach (ReactiveElement<CurrencyType, int> currency in _currencies)
            {
                if (currencyFilter.Invoke(currency.Type))
                    currency.Value += value;
            }
        }

        public void RemoveCurrency(CurrencyFilter currencyFilter, int value)
        {
            if (IsValueValid(value) == false)
                return;

            foreach (ReactiveElement<CurrencyType, int> currency in _currencies)
            {
                if (currencyFilter.Invoke(currency.Type))
                {
                    if (currency.Value - value < 0)
                        Debug.Log("Not enough funds");
                    else
                        currency.Value -= value;
                }
            }
        }

        private bool IsValueValid(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "The value cannot be negative");

            return true;
        }
    }
}

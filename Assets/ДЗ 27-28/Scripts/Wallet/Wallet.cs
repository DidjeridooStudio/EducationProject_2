using System;
using System.Collections.Generic;
using UnityEngine;

namespace HW27_28
{
    public class Wallet
    {
        public event Action<CurrencyType, int> CurrencyValueChanged;

        private List<Currency> _currencies;

        public List<Currency> Currencies => _currencies;

        public Wallet()
        {
            _currencies = new List<Currency>();

            _currencies.Add(new Currency(CurrencyType.Coin));
            _currencies.Add(new Currency(CurrencyType.Diamond));
            _currencies.Add(new Currency(CurrencyType.Energy));
        }

        public void AddCurrency(CurrencyFilter currencyFilter, int value)
        {
            if (IsValueValid(value) == false)
                return;

            foreach (Currency currency in _currencies)
            {
                if (currencyFilter.Invoke(currency))
                {
                    currency.Value += value;
                    CurrencyValueChanged?.Invoke(currency.Type, currency.Value);
                }
            }
        }

        public void RemoveCurrency(CurrencyFilter currencyFilter, int value)
        {
            if (IsValueValid(value) == false)
                return;

            foreach (Currency currency in _currencies)
            {
                if (currencyFilter.Invoke(currency))
                {
                    if (currency.Value - value < 0)
                    {
                        Debug.Log("Not enough funds");
                    }
                    else
                    {
                        currency.Value -= value;
                        CurrencyValueChanged?.Invoke(currency.Type, currency.Value);
                    }
                }
            }
        }

        private bool IsValueValid(int value)
        {
            if (value < 0)
            {
                Debug.LogError("The value cannot be negative");
                return false;
            }

            return true;
        }
    }
}

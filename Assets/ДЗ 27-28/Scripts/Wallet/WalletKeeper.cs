using System;
using UnityEngine;

namespace HW27_28
{
    public class WalletKeeper : MonoBehaviour
    {
        [SerializeField] private CurrencyType _currencyType;
        [SerializeField] private int _addingQuantity;
        [SerializeField] private int _removingQuantity;

        private Wallet _wallet;

        public Wallet Wallet => _wallet;

        private void Awake()
        {
            _wallet = new Wallet();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                _wallet.AddCurrency((currency) => currency.Type == _currencyType, _addingQuantity);

            if (Input.GetKeyDown(KeyCode.Alpha2))
                _wallet.RemoveCurrency((currency) => currency.Type == _currencyType, _removingQuantity);
        }
    }
}

using System;
using UnityEngine;

namespace HW29_30
{
    public class WalletKeeper : MonoBehaviour
    {
        [SerializeField] private CurrencyType _currencyType;
        [SerializeField] private int _addingQuantity;
        [SerializeField] private int _removingQuantity;
        [SerializeField] private WalletView _walletView;

        private Wallet _wallet;

        public Wallet Wallet => _wallet;

        private void Awake()
        {
            _wallet = new Wallet();
            _walletView.Initialize(_wallet);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                _wallet.AddCurrency((currencyType) => currencyType == _currencyType, _addingQuantity);

            if (Input.GetKeyDown(KeyCode.Alpha2))
                _wallet.RemoveCurrency((currencyType) => currencyType == _currencyType, _removingQuantity);
        }
    }
}

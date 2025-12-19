using TMPro;
using UnityEngine;

namespace HW27_28
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private WalletKeeper _walletKeeper;
        [SerializeField] private TMP_Text _currencyTMP_Text;

        private Wallet _wallet;

        private void Start()
        {
            _wallet = _walletKeeper.Wallet;
            _wallet.CurrencyValueChanged += OnCurrencyValueChanged;

            ShowCurrencyList();
        }

        private void OnDestroy()
        {
            _wallet.CurrencyValueChanged -= OnCurrencyValueChanged;
        }

        private void ShowCurrencyList()
        {
            string text = "";

            foreach (Currency currency in _wallet.Currencies)
            {
                text += $"{currency.Type}: {currency.Value}\n";
            }

            _currencyTMP_Text.text = text;
        }

        private void OnCurrencyValueChanged(CurrencyType type, int arg2)
        {
            ShowCurrencyList();
        }
    }
}

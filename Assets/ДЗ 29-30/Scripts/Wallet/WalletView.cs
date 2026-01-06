using TMPro;
using UnityEngine;

namespace HW29_30
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currencyTMP_Text;

        private Wallet _wallet;

        public void Initialize(Wallet wallet)
        {
            _wallet = wallet;

            foreach (IReadOnlyElement<CurrencyType, int> currency in _wallet.Currencies)
                currency.Changed += OnCurrencyValueChanged;

            ShowCurrencyList();
        }

        private void OnDestroy()
        {
            foreach (IReadOnlyElement<CurrencyType, int> currency in _wallet.Currencies)
                currency.Changed -= OnCurrencyValueChanged;
        }

        private void ShowCurrencyList()
        {
            string text = "";

            foreach (IReadOnlyElement<CurrencyType, int> currency  in _wallet.Currencies)
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

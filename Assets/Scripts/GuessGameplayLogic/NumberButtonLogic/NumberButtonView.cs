using GuessGameplayLogic.InputFieldLogic;
using TMPro;
using UnityEngine;
using Zenject;

namespace GuessGameplayLogic.NumberButtonLogic
{
    public class NumberButtonView : MonoBehaviour
    {
        private InputFieldViewModel _inputFieldViewModel;
        
        public RectTransform RectTransform => _rectTransform;
        private RectTransform _rectTransform;
        
        [SerializeField] private TextMeshProUGUI _numberText;
        
        private int _numberValue;

        [Inject]
        private void Construct(DiContainer container)
        {
            _inputFieldViewModel = container.Resolve<InputFieldViewModel>();

            _rectTransform = GetComponent<RectTransform>();
        }
        
        public void Setup(int number)
        {
            _numberValue = number;
            _numberText.text = _numberValue.ToString();
        }

        public void OnSelect()
        {
            _inputFieldViewModel.AddNumber(_numberValue);
        }
    }
}
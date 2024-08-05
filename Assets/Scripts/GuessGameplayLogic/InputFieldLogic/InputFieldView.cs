using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace GuessGameplayLogic.InputFieldLogic
{
    public class InputFieldView : MonoBehaviour
    {
        private InputFieldViewModel _viewModel;

        [SerializeField] private TextMeshProUGUI _inputText;
        
        private CompositeDisposable _disposable;
        
        [Inject]
        public virtual void Construct(DiContainer container)
        {
            _viewModel = container.Resolve<InputFieldViewModel>();

            _disposable = new CompositeDisposable();
        }
        
        private void Start()
        {
            _viewModel.Input.Subscribe((value) => DisplayInput(value)).AddTo(_disposable);
        }

        private void DisplayInput(string value)
        {
            _inputText.text = value;
        }
    }
}
using UniRx;
using Zenject;

namespace GuessGameplayLogic.InputFieldLogic
{
    public class InputFieldViewModel
    {
        private InputFieldModel _model;
        public ReactiveProperty<string> Input { get; }

        private CompositeDisposable _disposable;
        
        public InputFieldViewModel(DiContainer container)
        {
            _model = container.Resolve<InputFieldModel>();

            Input = new ReactiveProperty<string>();
            _disposable = new CompositeDisposable();

            _model.Input.Subscribe((value) => Input.Value = value).AddTo(_disposable);
        }

        public void Remove()
        {
            _model.Remove();
        }

        public void AddNumber(int number)
        {
            _model.AddNumber(number);
        }
    }
}
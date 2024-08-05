using UniRx;
using Zenject;

namespace GuessGameplayLogic.InputFieldLogic
{
    public class InputFieldViewModel
    {
        public InputFieldModel Model { get; }
        public ReactiveProperty<string> Input { get; }

        private CompositeDisposable _disposable;
        
        public InputFieldViewModel(DiContainer container)
        {
            Model = container.Resolve<InputFieldModel>();

            Input = new ReactiveProperty<string>();
            _disposable = new CompositeDisposable();

            Model.Input.Subscribe((value) => Input.Value = value).AddTo(_disposable);
        }

        public void Remove()
        {
            Model.Remove();
        }

        public void AddNumber(int number)
        {
            Model.AddNumber(number);
        }
    }
}
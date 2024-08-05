using GuessGameplayLogic.InputFieldLogic.SenderLogic;
using UniRx;
using Zenject;

namespace GuessGameplayLogic.NumberButtonLogic.ListLogic
{
    public class NumberButtonsListViewModel
    {
        public ReactiveCommand OnSuffleButtons { get; }

        private InputFieldSenderViewModel _inputFieldSenderViewModel;

        private CompositeDisposable _disposable;
        public NumberButtonsListViewModel(DiContainer container)
        {
            _inputFieldSenderViewModel = container.Resolve<InputFieldSenderViewModel>();

            OnSuffleButtons = new ReactiveCommand();
            _disposable = new CompositeDisposable();
        }

        public void Setup()
        {
            _inputFieldSenderViewModel.OnSended.Subscribe((value) => OnSuffleButtons?.Execute()).AddTo(_disposable);
        }
    }
}
using GuessGameplayLogic.InputFieldLogic.SenderLogic;
using UniRx;
using Zenject;

namespace GuessGameplayLogic.NumberButtonLogic.ListLogic
{
    public class NumberButtonsListViewModel
    {
        public ReactiveCommand OnShuffleButtons { get; }

        private InputFieldSenderViewModel _inputFieldSenderViewModel;

        private CompositeDisposable _disposable;
        public NumberButtonsListViewModel(DiContainer container)
        {
            _inputFieldSenderViewModel = container.Resolve<InputFieldSenderViewModel>();

            OnShuffleButtons = new ReactiveCommand();
            _disposable = new CompositeDisposable();
            
            _inputFieldSenderViewModel.OnSended.Subscribe((value) => OnShuffleButtons?.Execute()).AddTo(_disposable);
        }
    }
}
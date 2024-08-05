using GuessGameplayLogic.TurnLogic.HandlerLogic;
using UniRx;
using Zenject;

namespace GuessGameplayLogic.InputFieldLogic.SenderLogic
{
    public class InputFieldSenderViewModel
    {
        public ReactiveCommand OnSended { get; }

        private ITurnHandler _turnHandler;
        private InputFieldViewModel _inputFieldViewModel;
        
        public InputFieldSenderViewModel(DiContainer container)
        {
            _turnHandler = container.Resolve<ITurnHandler>();
            _inputFieldViewModel = container.Resolve<InputFieldViewModel>();

            OnSended = new ReactiveCommand();
        }

        public void Send()
        {
            _turnHandler.MakeTurn(int.Parse(_inputFieldViewModel.Input.Value));
            _inputFieldViewModel.Remove();

            OnSended?.Execute();
        }
    }
}
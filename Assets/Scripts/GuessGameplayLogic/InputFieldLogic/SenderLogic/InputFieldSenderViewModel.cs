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
            if (!int.TryParse(_inputFieldViewModel.Input.Value, out int value)) return;
            
            _turnHandler.MakeGuess(value);
            _inputFieldViewModel.Remove();

            OnSended?.Execute();
        }
    }
}
using GuessGameplayLogic.TurnLogic.HandlerLogic;
using UnityEngine;
using Zenject;

namespace GuessGameplayLogic.InputFieldLogic
{
    public class InputFieldSenderView : MonoBehaviour
    {
        private ITurnHandler _turnHandler;
        private InputFieldViewModel _inputFieldViewModel;
        
        [Inject]
        public virtual void Construct(DiContainer container)
        {
            _turnHandler = container.Resolve<ITurnHandler>();
            _inputFieldViewModel = container.Resolve<InputFieldViewModel>();
        }

        public void OnSend()
        {
            _turnHandler.MakeTurn(int.Parse(_inputFieldViewModel.Input.Value));
            _inputFieldViewModel.Remove();
        }
    }
}
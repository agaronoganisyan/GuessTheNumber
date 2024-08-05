using GuessGameplayLogic.TurnLogic.HandlerLogic;
using UnityEngine;
using Zenject;

namespace GuessGameplayLogic.InputFieldLogic.SenderLogic
{
    public class InputFieldSenderView : MonoBehaviour
    {
        private InputFieldSenderViewModel _viewModel;
        
        [Inject]
        public virtual void Construct(DiContainer container)
        {
            _viewModel = container.Resolve<InputFieldSenderViewModel>();
        }

        public void OnSend()
        {
            _viewModel.Send();
        }
    }
}
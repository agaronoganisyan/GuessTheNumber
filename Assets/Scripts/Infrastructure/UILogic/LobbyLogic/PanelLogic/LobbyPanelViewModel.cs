using Infrastructure.GameStateLogic;
using Zenject;

namespace Infrastructure.UILogic.LobbyLogic.PanelLogic
{
    public class LobbyPanelViewModel
    {
        protected IGameStateMachine _gameStateMachine;
        
        public void Setup(DiContainer container)
        {
            _gameStateMachine = container.Resolve<IGameStateMachine>();
        }
        
        public void StartMatch()
        {
            _gameStateMachine.SwitchState(GameState.Gameplay);
        }
        
        public void OpenSettings()
        {
        }
    }
}
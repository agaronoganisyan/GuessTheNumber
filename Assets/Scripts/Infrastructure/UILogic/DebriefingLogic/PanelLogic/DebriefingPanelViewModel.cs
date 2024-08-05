using Infrastructure.GameStateLogic;
using UniRx;
using Zenject;

namespace Infrastructure.UILogic.DebriefingLogic.PanelLogic
{
    public class DebriefingPanelViewModel
    {
        private IGameStateMachine _gameStateMachine;
        
        private CompositeDisposable _disposable;

        public DebriefingPanelViewModel(DiContainer container)
        {
            _disposable = new CompositeDisposable();
        }
        
        public void Setup(DiContainer container)
        {
            _gameStateMachine = container.Resolve<IGameStateMachine>();
        }
        
        public void ToLobby()
        {
            _gameStateMachine.SwitchState(GameState.Lobby);
        }
    }
}
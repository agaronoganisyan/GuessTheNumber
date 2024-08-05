using GuessGameplayLogic.TurnLogic.HandlerLogic;
using Infrastructure.GameStateLogic;
using UniRx;
using Zenject;

namespace Infrastructure.UILogic.DebriefingLogic.PanelLogic
{
    public class DebriefingPanelViewModel
    {
        public ReactiveCommand<string> OnDisplayWinnerName { get; }
        
        private IGameStateMachine _gameStateMachine;
        private ITurnHandler _turnHandler;
        
        private CompositeDisposable _disposable;
        
        public DebriefingPanelViewModel()
        {
            _disposable = new CompositeDisposable();
            OnDisplayWinnerName = new ReactiveCommand<string>();
        }
        
        public void Setup(DiContainer container)
        {
            _gameStateMachine = container.Resolve<IGameStateMachine>();
            _turnHandler = container.Resolve<ITurnHandler>();

            _turnHandler.OnWinnerDetermined.Subscribe((value) => OnDisplayWinnerName?.Execute(value.Name))
                .AddTo(_disposable);
        }
        
        public void ToLobby()
        {
            _gameStateMachine.SwitchState(GameState.Lobby);
        }
        
        public string GetWinnerName()
        {
            return _turnHandler.GetCurrentTurnEntity().Name;
        }
    }
}
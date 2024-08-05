using Cysharp.Threading.Tasks;
using GuessGameplayLogic.NumberGeneratorLogic;
using GuessGameplayLogic.TurnLogic.EntityLogic;
using GuessGameplayLogic.TurnLogic.HandlerLogic;
using Infrastructure.StateMachineLogic;
using Infrastructure.UILogic.UIStateMachineLogic;
using Zenject;

namespace Infrastructure.GameStateLogic
{
    public class Gameplay : GameBaseState<GameState>
    {
        private INumberGenerator _numberGenerator;
        private ITurnHandler _turnHandler;
        
        public Gameplay(IStateMachine<GameState> stateMachine, DiContainer container) : base(stateMachine,container)
        {
            _numberGenerator = container.Resolve<INumberGenerator>();
            _turnHandler = container.Resolve<ITurnHandler>();
        }
        
        public override async UniTask Enter()
        {
            if (!_isSetuped)
            {
                _turnHandler.Setup(_container);
                
                _isSetuped = true;
            }
            
            _numberGenerator.Generate();
            
            _turnHandler.AddEntity(new Player("Player", _container));
            _turnHandler.AddEntity(new AI("AI", _container));
            
            _turnHandler.Start();
            
            _uiStateMachine.SwitchState(UIState.Gameplay);
        }

        public override async UniTask Exit()
        {
            _turnHandler.Cleanup();
        }
    }
}
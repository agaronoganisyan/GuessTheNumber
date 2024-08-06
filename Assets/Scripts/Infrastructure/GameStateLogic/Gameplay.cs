using Cysharp.Threading.Tasks;
using GuessGameplayLogic.GuessLogic.FactoryLogic;
using GuessGameplayLogic.GuessLogic.ListLogic;
using GuessGameplayLogic.NumberButtonLogic.ListLogic;
using GuessGameplayLogic.NumberGeneratorLogic;
using GuessGameplayLogic.TurnLogic.EntityLogic.ProviderLogic;
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
        private GuessesListViewModel _guessesListViewModel;
        private IGuessFactory _guessFactory;
        private NumberButtonsListViewModel _numberButtonsListViewModel;
        private ITurnEntitiesProvider _turnEntitiesProvider;
        
        public Gameplay(IStateMachine<GameState> stateMachine, DiContainer container) : base(stateMachine,container)
        {
            _numberGenerator = container.Resolve<INumberGenerator>();
            _turnHandler = container.Resolve<ITurnHandler>();
            _guessesListViewModel = container.Resolve<GuessesListViewModel>();
            _guessFactory = container.Resolve<IGuessFactory>();
            _numberButtonsListViewModel = container.Resolve<NumberButtonsListViewModel>();
            _turnEntitiesProvider = container.Resolve<ITurnEntitiesProvider>();
        }
        
        public override async UniTask Enter()
        {
            if (!_isSetuped)
            {
                _turnHandler.Setup(_container);
                _numberButtonsListViewModel.Setup();
                
                _isSetuped = true;
            }

            await _guessFactory.Setup();
            _guessesListViewModel.Setup();

            _numberGenerator.Generate();
            _turnEntitiesProvider.Provide();
            
            _turnHandler.Start();
            
            _uiStateMachine.SwitchState(UIState.Gameplay);
        }

        public override async UniTask Exit()
        {
            _guessFactory.ReturnAllBack();
        }
    }
}
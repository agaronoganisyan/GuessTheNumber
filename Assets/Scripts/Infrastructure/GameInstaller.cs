using GuessGameplayLogic.GuessLogic;
using GuessGameplayLogic.GuessLogic.FactoryLogic;
using GuessGameplayLogic.GuessLogic.ListLogic;
using GuessGameplayLogic.InputFieldLogic;
using GuessGameplayLogic.InputFieldLogic.SenderLogic;
using GuessGameplayLogic.NumberButtonLogic.ListLogic;
using GuessGameplayLogic.NumberGeneratorLogic;
using GuessGameplayLogic.TurnLogic.HandlerLogic;
using GuessGameplayLogic.ValidatorLogic;
using Infrastructure.AssetManagementLogic;
using Infrastructure.GameStateLogic;
using Infrastructure.PoolLogic;
using Infrastructure.UILogic.DebriefingLogic;
using Infrastructure.UILogic.DebriefingLogic.PanelLogic;
using Infrastructure.UILogic.FactoryLogic;
using Infrastructure.UILogic.GameplayLogic;
using Infrastructure.UILogic.LobbyLogic;
using Infrastructure.UILogic.LobbyLogic.PanelLogic;
using Infrastructure.UILogic.UIStateMachineLogic;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameConfig _gameConfig;
        
        public override void InstallBindings()
        {
            //General
            Container.Bind<IAssetsProvider>().To<AssetsProvider>().FromNew().AsSingle();
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().FromNew().AsSingle();
            Container.Bind<IUIFactory>().To<UIFactory>().FromNew().AsSingle();
            Container.Bind<IUIStateMachine>().To<UIStateMachine>().FromNew().AsSingle();
            
            Container.Bind<ITurnHandler>().To<TurnHandler>().FromNew().AsSingle();
            Container.Bind<IGameValidator>().To<GameValidator>().FromNew().AsSingle();
            Container.Bind<INumberGenerator>().To<NumberGenerator>().FromNew().AsSingle();

            Container.Bind<ObjectPool<GuessView>>().FromNew().AsTransient();
            Container.Bind<GuessViewFactory<GuessView>>().FromNew().AsTransient();

            Container.Bind<IGuessFactory>().To<GuessFactory>().FromNew().AsSingle();
            Container.Bind<GuessesListViewModel>().FromNew().AsSingle();

            Container.Bind<InputFieldModel>().FromNew().AsSingle();
            Container.Bind<InputFieldViewModel>().FromNew().AsSingle();
            
            Container.Bind<NumberButtonsListViewModel>().FromNew().AsSingle();

            
            Container.Bind<InputFieldSenderViewModel>().FromNew().AsSingle();

            Container.Bind<GameConfig>().FromInstance(_gameConfig).AsSingle();
            
            //Canvases
            Container.Bind<LobbyCanvasViewModel>().FromNew().AsSingle();
            Container.Bind<GameplayCanvasViewModel>().FromNew().AsSingle();
            Container.Bind<DebriefingCanvasViewModel>().FromNew().AsSingle();
            
            //CanvasPanels
            Container.Bind<LobbyPanelViewModel>().FromNew().AsSingle();
            Container.Bind<DebriefingPanelViewModel>().FromNew().AsSingle();
        }
    }
}

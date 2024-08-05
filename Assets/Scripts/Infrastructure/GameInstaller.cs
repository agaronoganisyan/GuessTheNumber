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
using Zenject;

namespace Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //General
            Container.Bind<IAssetsProvider>().To<AssetsProvider>().FromNew().AsSingle();
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().FromNew().AsSingle();
            Container.Bind<IUIFactory>().To<UIFactory>().FromNew().AsSingle();
            Container.Bind<IUIStateMachine>().To<UIStateMachine>().FromNew().AsSingle();
            
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

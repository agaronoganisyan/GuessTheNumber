using Cysharp.Threading.Tasks;
using UniRx;
using Zenject;

namespace GuessGameplayLogic.GuessLogic.FactoryLogic
{
    public class GuessFactory : IGuessFactory
    {
        public ReactiveCommand OnSetuped { get; private set; }
        private bool _isSetuped;

        private GuessViewFactory<GuessView> _viewFactory;
        
        private const string _address = "GuessView";

        public GuessFactory(DiContainer container)
        {
            OnSetuped = new ReactiveCommand();
            
            _viewFactory = container.Resolve<GuessViewFactory<GuessView>>();
        }

        public async UniTask Setup()
        {
            if (_isSetuped) return;
            
            await _viewFactory.Setup(_address);

            SetAsSetuped();
        }

        public void ReturnAllBack()
        {
            _viewFactory.ReturnAllObjectToPool();
        }

        public GuessView Get(GuessViewModel viewModel)
        {
            return _viewFactory.Get(viewModel);
        }
                
        private void SetAsSetuped()
        {
            _isSetuped = true;
            OnSetuped.Execute();
        }
    }
}
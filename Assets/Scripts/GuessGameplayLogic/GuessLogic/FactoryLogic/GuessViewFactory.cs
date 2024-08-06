using Cysharp.Threading.Tasks;
using Infrastructure.AssetManagementLogic;
using Infrastructure.ObjectFactoryLogic;
using Infrastructure.PoolLogic;
using UnityEngine;
using Zenject;

namespace GuessGameplayLogic.GuessLogic.FactoryLogic
{
    public class GuessViewFactory : ObjectFactory<GuessView>
    {
        private IAssetsProvider _assetsProvider;
        
        public GuessViewFactory(DiContainer container)
        {
            _pool = container.Resolve<ObjectPool<GuessView>>();
            _assetsProvider = container.Resolve<IAssetsProvider>();
        }
        
        public override async UniTask Setup(string addressToPrefab)
        {
            GameObject prefab = await _assetsProvider.Load<GameObject>(addressToPrefab);
            _pool.Setup(prefab.GetComponent<GuessView>());
        }

        public GuessView Get(GuessViewModel viewModel)
        {
            GuessView fieldView = base.Get();
            fieldView.Setup(viewModel);
            return fieldView;
        }
    }
}
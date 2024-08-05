using Cysharp.Threading.Tasks;
using Infrastructure.AssetManagementLogic;
using Infrastructure.ObjectFactoryLogic;
using Infrastructure.PoolLogic;
using UnityEngine;
using Zenject;

namespace GuessGameplayLogic.GuessLogic.FactoryLogic
{
    public class GuessViewFactory<T> : ObjectFactory<T> where T : MonoBehaviour, Infrastructure.PoolLogic.IPoolable<T>
    {
        private IAssetsProvider _assetsProvider;
        
        public GuessViewFactory(DiContainer container)
        {
            _pool = container.Resolve<ObjectPool<T>>();
            _assetsProvider = container.Resolve<IAssetsProvider>();
        }
        
        public override async UniTask Setup(string addressToPrefab)
        {
            GameObject prefab = await _assetsProvider.Load<GameObject>(addressToPrefab);
            _pool.Setup(prefab.GetComponent<T>());
        }

        public GuessView Get(GuessViewModel viewModel)
        {
            GuessView fieldView = base.Get() as GuessView;
            fieldView.Setup(viewModel);
            return fieldView;
        }
    }
}
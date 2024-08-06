using System.Collections.Generic;
using Zenject;

namespace GuessGameplayLogic.TurnLogic.EntityLogic.ProviderLogic
{
    public class TurnEntitiesProvider : ITurnEntitiesProvider
    {
        private TurnEntitiesModel _entitiesModel;
        private DiContainer _container;
 
        
        public TurnEntitiesProvider(DiContainer container)
        {
            _container = container;
            
            _entitiesModel = _container.Resolve<TurnEntitiesModel>();
        }

        public void Provide()
        {
            _entitiesModel.Setup(new List<TurnEntity>
            {
                new Player("Player", _container),
                new AI("AI", _container)
            });
        }
    }
}
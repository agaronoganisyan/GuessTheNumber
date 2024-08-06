using System.Collections.Generic;
using Zenject;

namespace GuessGameplayLogic.TurnLogic.EntityLogic
{
    public class TurnEntitiesModel
    {
        public List<TurnEntity> Entities { get; }
        
        public TurnEntitiesModel()
        {
            Entities = new List<TurnEntity>();
        }
        
        public void Setup(List<TurnEntity> entities)
        {
            Entities.Clear();
            for (int i = 0; i < entities.Count; i++)
            {
                Entities.Add(entities[i]);
            }
        }
    }
}
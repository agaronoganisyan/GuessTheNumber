using Zenject;

namespace GuessGameplayLogic.TurnLogic.EntityLogic
{
    public abstract class TurnEntity
    {
        public string Name { get; }

        public TurnEntity(string name, DiContainer container)
        {
            Name = name;
        }

        public abstract void MakeTurn();
    }
}
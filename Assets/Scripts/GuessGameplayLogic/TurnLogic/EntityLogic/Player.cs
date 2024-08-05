using Zenject;

namespace GuessGameplayLogic.TurnLogic.EntityLogic
{
    public class Player : TurnEntity
    {
        public Player(string name, DiContainer container) : base(name, container)
        {
        }

        public override void MakeTurn()
        {
            //если дальше развивать проект, то здесь надо будет добавить через ViewModel активацию UI для ввода чисел игроком 
        }
    }
}
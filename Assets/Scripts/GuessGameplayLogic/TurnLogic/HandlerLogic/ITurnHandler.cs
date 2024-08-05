using GuessGameplayLogic.TurnLogic.EntityLogic;
using GuessGameplayLogic.ValidatorLogic;
using UniRx;
using Zenject;

namespace GuessGameplayLogic.TurnLogic.HandlerLogic
{
    public interface ITurnHandler
    {
        ReactiveCommand<TurnEntity> OnWinnerDetermined { get; }
        void Setup(DiContainer container);
        void AddEntity(TurnEntity entity);
        void Start();
        NumberStatus MakeTurn(int number);
        void Cleanup();
        TurnEntity GetCurrentTurnEntity();
    }
}
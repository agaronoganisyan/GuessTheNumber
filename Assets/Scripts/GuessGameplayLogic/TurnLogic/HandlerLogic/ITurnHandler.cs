using GuessGameplayLogic.GuessLogic;
using GuessGameplayLogic.TurnLogic.EntityLogic;
using UniRx;
using Zenject;

namespace GuessGameplayLogic.TurnLogic.HandlerLogic
{
    public interface ITurnHandler
    {
        ReactiveCommand<TurnEntity> OnWinnerDetermined { get; }
        void Setup(DiContainer container);
        void Start();
        NumberStatus MakeGuess(int number);
        TurnEntity GetCurrentTurnEntity();
    }
}
using GuessGameplayLogic.TurnLogic.EntityLogic;
using UniRx;

namespace GuessGameplayLogic.ValidatorLogic
{
    public interface IGameValidator
    {
        ValidationResult Validate(TurnEntity turnEntity, int number);
    }
}
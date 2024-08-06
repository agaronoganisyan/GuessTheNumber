using GuessGameplayLogic.TurnLogic.EntityLogic;

namespace GuessGameplayLogic.GuessLogic.ValidatorLogic
{
    public interface IGuessValidator
    {
        NumberStatus Validate(GuessModel guessModel);
    }
}
using GuessGameplayLogic.NumberGeneratorLogic;
using GuessGameplayLogic.TurnLogic.EntityLogic;
using UniRx;
using Zenject;

namespace GuessGameplayLogic.ValidatorLogic
{
    public class GameValidator : IGameValidator
    {
        private INumberGenerator _numberGenerator;

        public GameValidator(DiContainer container)
        {
            _numberGenerator = container.Resolve<INumberGenerator>();
        }

        public ValidationResult Validate(TurnEntity turnEntity, int number)
        {
            ValidationResult result = new ValidationResult(turnEntity.Name, number, GetNumberStatus(number));
            
            return result;
        }
        

        private NumberStatus GetNumberStatus(int number)
        {
            NumberStatus status = NumberStatus.None;

            if (number == _numberGenerator.GeneratedNumber) status = NumberStatus.Correct;
            else if (number > _numberGenerator.GeneratedNumber) status = NumberStatus.Higher;
            else if (number < _numberGenerator.GeneratedNumber) status = NumberStatus.Lower;

            return status;
        }
    }
}
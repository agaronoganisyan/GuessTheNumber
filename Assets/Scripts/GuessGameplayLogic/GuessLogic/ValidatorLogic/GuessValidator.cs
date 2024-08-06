using GuessGameplayLogic.NumberGeneratorLogic;
using Zenject;

namespace GuessGameplayLogic.GuessLogic.ValidatorLogic
{
    public class GuessValidator : IGuessValidator
    {
        private INumberGenerator _numberGenerator;

        public GuessValidator(DiContainer container)
        {
            _numberGenerator = container.Resolve<INumberGenerator>();
        }

        public NumberStatus Validate(GuessModel guessModel)
        {
            NumberStatus status = GetNumberStatus(guessModel.NumberValue);
            guessModel.SetStatus(status);
                
            return status;
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
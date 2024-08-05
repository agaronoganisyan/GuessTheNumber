using GuessGameplayLogic.ValidatorLogic;

namespace GuessGameplayLogic.GuessLogic
{
    public class GuessModel
    {
        public string Owner { get; }
        public int NumberValue { get; }
        public NumberStatus NumberStatus { get; }

        public GuessModel(string owner, int numberValue, NumberStatus numberStatus)
        {
            Owner = owner;
            NumberValue = numberValue;
            NumberStatus = numberStatus;
        }
    }
}
namespace GuessGameplayLogic.GuessLogic
{
    public enum NumberStatus
    {
        None,
        Higher,
        Lower,
        Correct
    }
    
    public class GuessModel
    {
        public string Owner { get; }
        public int NumberValue { get; }
        public NumberStatus NumberStatus { get; private set; }

        public GuessModel(string owner, int numberValue)
        {
            Owner = owner;
            NumberValue = numberValue;
        }

        public void SetStatus(NumberStatus numberStatus)
        {
            NumberStatus = numberStatus;
        }
    }
}
using Unity.VisualScripting;

namespace GuessGameplayLogic.ValidatorLogic
{
    public enum NumberStatus
    {
        None,
        Higher,
        Lower,
        Correct
    }

    public struct ValidationResult
    {
        public string Owner { get; }
        public int Number { get; }
        public NumberStatus Status { get; }

        public ValidationResult(string owner, int number, NumberStatus status)
        {
            Owner = owner;
            Number = number;
            Status = status;
        }
    }
}
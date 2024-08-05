namespace GuessGameplayLogic.NumberGeneratorLogic
{
    public interface INumberGenerator
    {
        int GeneratedNumber { get; }
        void Generate();
    }
}
using UnityEngine;
using Zenject;
using Random = System.Random;

namespace GuessGameplayLogic.NumberGeneratorLogic
{
    public class NumberGenerator : INumberGenerator
    {
        public int GeneratedNumber { get; private set; }

        private GameConfig _gameConfig;
        private Random _random;

        public NumberGenerator(DiContainer container)
        {
            _gameConfig = container.Resolve<GameConfig>();
            _random = new Random();
        }

        public void Generate()
        {
            GeneratedNumber = _random.Next(0, _gameConfig.MaxNumberValue + 1);
            Debug.Log($"GeneratedNumber {GeneratedNumber}");
        }
    }
}
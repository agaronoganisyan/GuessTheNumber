using GuessGameplayLogic.NumberGeneratorLogic;
using GuessGameplayLogic.TurnLogic.HandlerLogic;
using GuessGameplayLogic.ValidatorLogic;
using UnityEngine;
using Zenject;

namespace GuessGameplayLogic.TurnLogic.EntityLogic
{
    public class AI: TurnEntity
    {
        private ITurnHandler _turnHandler;
        private GameConfig _gameConfig;
        
        private int _lowerBound;
        private int _upperBound;
        private int _currentGuess;   
        
        public AI(string name, DiContainer container) : base(name, container)
        {
            _turnHandler = container.Resolve<ITurnHandler>();
            _gameConfig = container.Resolve<GameConfig>();
            
            _lowerBound = 0;
            _upperBound = _gameConfig.MaxNumberValue;
        }

        public override void MakeTurn()
        {
            _currentGuess = (_lowerBound + _upperBound) / 2;
            NumberStatus status = _turnHandler.MakeTurn(_currentGuess);
            switch (status)
            {
                case NumberStatus.Lower:
                    _lowerBound = _currentGuess + 1;
                    break;
                case NumberStatus.Higher:
                    _upperBound = _currentGuess - 1;
                    break;
            }
        }
    }
}
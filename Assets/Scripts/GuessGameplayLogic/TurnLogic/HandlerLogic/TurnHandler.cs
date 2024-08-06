using System.Collections.Generic;
using GuessGameplayLogic.GuessLogic;
using GuessGameplayLogic.GuessLogic.ListLogic;
using GuessGameplayLogic.GuessLogic.ValidatorLogic;
using GuessGameplayLogic.TurnLogic.EntityLogic;
using Infrastructure.GameStateLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace GuessGameplayLogic.TurnLogic.HandlerLogic
{
    public class TurnHandler : ITurnHandler
    {
        public ReactiveCommand<TurnEntity> OnWinnerDetermined { get; }

        private TurnEntitiesModel _turnEntitiesModel;
        private IGuessValidator _guessValidator;
        private IGameStateMachine _gameStateMachine;
        private GuessesListViewModel _guessesListViewModel;
        
        private TurnEntity _currentTurnEntity;
        private int _currentTurnEntityIndex;
        
        public TurnHandler()
        {
            OnWinnerDetermined = new ReactiveCommand<TurnEntity>();
        }

        public void Setup(DiContainer container)
        {
            _guessValidator = container.Resolve<IGuessValidator>();
            _gameStateMachine = container.Resolve<IGameStateMachine>();
            _guessesListViewModel = container.Resolve<GuessesListViewModel>();
            _turnEntitiesModel = container.Resolve<TurnEntitiesModel>();
        }

        public void Start()
        {
            _currentTurnEntityIndex = 0;
            PassTurn(_currentTurnEntityIndex);
        }

        public NumberStatus MakeGuess(int number)
        {
            GuessModel guessModel = new GuessModel(_currentTurnEntity.Name, number);
            NumberStatus status = _guessValidator.Validate(guessModel);

            if (status == NumberStatus.Correct)
            {
                OnWinnerDetermined?.Execute(_currentTurnEntity);
                _gameStateMachine.SwitchState(GameState.Debriefing);
            }
            else
            {
                _guessesListViewModel.Add(guessModel);
                
                _currentTurnEntityIndex = GetNextTurnEntityIndex();
                PassTurn(_currentTurnEntityIndex);
            }

            return status;
        }

        public TurnEntity GetCurrentTurnEntity()
        {
            return _currentTurnEntity;
        }

        private int GetNextTurnEntityIndex()
        {
            int nextIndex = _currentTurnEntityIndex + 1;
            if (nextIndex >= _turnEntitiesModel.Entities.Count) nextIndex = 0;

            return nextIndex;
        }

        private void PassTurn(int index)
        {
            _currentTurnEntity = _turnEntitiesModel.Entities[index];
            _currentTurnEntity.MakeGuess();
        }
    }
}
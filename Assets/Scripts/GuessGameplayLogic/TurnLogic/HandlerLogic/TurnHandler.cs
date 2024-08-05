using System.Collections.Generic;
using GuessGameplayLogic.GuessLogic.ListLogic;
using GuessGameplayLogic.TurnLogic.EntityLogic;
using GuessGameplayLogic.ValidatorLogic;
using Infrastructure.GameStateLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace GuessGameplayLogic.TurnLogic.HandlerLogic
{
    public class TurnHandler : ITurnHandler
    {
        public ReactiveCommand<TurnEntity> OnWinnerDetermined { get; }
        
        private IGameValidator _gameValidator;
        private IGameStateMachine _gameStateMachine;
        private GuessesListViewModel _guessesListViewModel;

        private List<TurnEntity> _entities;

        private TurnEntity _currentTurnEntity;
        private int _currentTurnEntityIndex;
        
        public TurnHandler()
        {
            OnWinnerDetermined = new ReactiveCommand<TurnEntity>();
            
            _entities = new List<TurnEntity>();
        }

        public void Setup(DiContainer container)
        {
            _gameValidator = container.Resolve<IGameValidator>();
            _gameStateMachine = container.Resolve<IGameStateMachine>();
            _guessesListViewModel = container.Resolve<GuessesListViewModel>();
        }

        public void AddEntity(TurnEntity entity)
        {
            _entities.Add(entity);
        }

        public void Start()
        {
            _currentTurnEntityIndex = 0;
            PassTurn(_currentTurnEntityIndex);
        }

        public NumberStatus MakeTurn(int number)
        {
            Debug.Log($"MakeTurn {number}");
            
            ValidationResult result = _gameValidator.Validate(_currentTurnEntity, number);

            if (result.Status == NumberStatus.Correct)
            {
                OnWinnerDetermined?.Execute(_currentTurnEntity);
                _gameStateMachine.SwitchState(GameState.Debriefing);
            }
            else
            {
                _guessesListViewModel.Add(result);
                
                _currentTurnEntityIndex = GetNextTurnEntityIndex();
                PassTurn(_currentTurnEntityIndex);
            }
            
            return result.Status;
        }
        
        public void Cleanup()
        {
            _entities.Clear();
        }

        public TurnEntity GetCurrentTurnEntity()
        {
            return _currentTurnEntity;
        }

        private int GetNextTurnEntityIndex()
        {
            int nextIndex = _currentTurnEntityIndex + 1;
            if (nextIndex >= _entities.Count) nextIndex = 0;

            return nextIndex;
        }

        private void PassTurn(int index)
        {
            _currentTurnEntity = _entities[index];
            _currentTurnEntity.MakeTurn();
        }
    }
}
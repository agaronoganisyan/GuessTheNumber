using System.Collections.Generic;
using GuessGameplayLogic.TurnLogic.HandlerLogic;
using GuessGameplayLogic.ValidatorLogic;
using UniRx;
using Zenject;

namespace GuessGameplayLogic.GuessLogic.ListLogic
{
    public class GuessesListViewModel
    {
        public ReactiveCommand<List<GuessViewModel>> OnSetuped;
        public ReactiveCommand<List<GuessViewModel>> OnExtended;

        private List<GuessViewModel> _guesses;

        public GuessesListViewModel()
        {
            _guesses = new List<GuessViewModel>();
            OnSetuped = new ReactiveCommand<List<GuessViewModel>>();
            OnExtended = new ReactiveCommand<List<GuessViewModel>>();
        }

        public void Setup()
        {
            _guesses.Clear();

            OnSetuped?.Execute(_guesses);
        }

        public void Add(ValidationResult result)
        {
            GuessViewModel guess = new GuessViewModel(new GuessModel(result.Owner, result.Number, result.Status));
            _guesses.Add(guess);

            OnExtended?.Execute(_guesses);
        }
    }
}
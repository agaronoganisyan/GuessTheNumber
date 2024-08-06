using System.Collections.Generic;
using GuessGameplayLogic.TurnLogic.HandlerLogic;
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

        public void Add(GuessModel guess)
        {
            GuessViewModel guessViewModel = new GuessViewModel(guess);
            _guesses.Add(guessViewModel);

            OnExtended?.Execute(_guesses);
        }
    }
}
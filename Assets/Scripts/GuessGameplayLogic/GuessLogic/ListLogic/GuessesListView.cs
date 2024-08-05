using System.Collections.Generic;
using GuessGameplayLogic.GuessLogic.FactoryLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace GuessGameplayLogic.GuessLogic.ListLogic
{
    public class GuessesListView : MonoBehaviour
    {
        private GuessesListViewModel _viewModel;
        private IGuessFactory _guessViewFactory;

        private CompositeDisposable _disposable;

        [SerializeField] private RectTransform _container;

        private List<GuessViewModel> _guessesInList;
        
        private const float Spacing = 0;
        
        [Inject]
        private void Construct(DiContainer container)
        {
            _viewModel = container.Resolve<GuessesListViewModel>();
            _guessViewFactory = container.Resolve<IGuessFactory>();

            _guessesInList = new List<GuessViewModel>();
            _disposable = new CompositeDisposable();
        }
        
        private void Start()
        {
            _viewModel.OnExtended.Subscribe(DisplayGuesses).AddTo(_disposable);
            _viewModel.OnSetuped.Subscribe(Setup).AddTo(_disposable);
        }

        private void Setup(List<GuessViewModel> guesses)
        {
            _guessesInList.Clear();
            DisplayGuesses(guesses);
        }

        private void DisplayGuesses(List<GuessViewModel> guesses)
        {
            int numAllItems = guesses.Count;
            Vector2 size = new Vector2(_container.sizeDelta.x, 0);
            Vector2 origin = new Vector2(0, Spacing);

            for (int i = 0; i < numAllItems; i++)
            {
                size += new Vector2(0,GuessViewStaticData.BaseHeight + Spacing);
                if (i == numAllItems - 1) size += new Vector2(0, Spacing);

                if (!_guessesInList.Contains(guesses[i]))
                {
                    GuessView view = _guessViewFactory.Get(guesses[i]);
                    view.transform.SetParent(_container); //намеренно добавлено, потому что иначе какой-то глюк c UniRx 
                    view.GetComponent<RectTransform>().anchoredPosition = origin; //при размещении первого элемента
                    
                    guesses[i].SetParentAndPosition(_container, origin);
                    
                    _guessesInList.Add(guesses[i]);

                }
                
                origin -= new Vector2(0, GuessViewStaticData.BaseHeight + Spacing);
            }

            _container.sizeDelta = size;
            
            if (numAllItems==0) _container.anchoredPosition = new Vector3(_container.anchoredPosition.x,0);
        }
    }
}
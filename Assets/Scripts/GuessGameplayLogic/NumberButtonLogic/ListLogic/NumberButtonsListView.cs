using System;
using UniRx;
using UnityEngine;
using Zenject;
using Random = System.Random;

namespace GuessGameplayLogic.NumberButtonLogic.ListLogic
{
    public class NumberButtonsListView : MonoBehaviour
    {
        private NumberButtonsListViewModel _viewModel;
        
        [SerializeField] private NumberButtonView[] _buttons;

        private CompositeDisposable _disposable;
        private Random _random;
        
        [Inject]
        private void Construct(DiContainer container)
        {
            _viewModel = container.Resolve<NumberButtonsListViewModel>();

            _disposable = new CompositeDisposable();
            _random = new Random();
        }

        private void Start()
        {
            _viewModel.OnSuffleButtons.Subscribe((value) => Shuffle()).AddTo(_disposable);
            
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].Setup(i);
            }
        }
        
        private void Shuffle()
        {
            int n = _buttons.Length;
            for (int i = n - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);

                if (i != j)
                {
                    Vector3 temp = _buttons[i].transform.position;
                    _buttons[i].transform.position = _buttons[j].transform.position;
                    _buttons[j].transform.position = temp;
                }
            }
        }
    }
}
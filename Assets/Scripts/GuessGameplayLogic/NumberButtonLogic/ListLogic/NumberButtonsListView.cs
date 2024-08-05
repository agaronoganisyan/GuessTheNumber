using System;
using UnityEngine;
using Zenject;

namespace GuessGameplayLogic.NumberButtonLogic.ListLogic
{
    public class NumberButtonsListView : MonoBehaviour
    {
        [SerializeField] private NumberButtonView[] _buttons;
        
        [Inject]
        private void Construct()
        {
            
        }

        private void Start()
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].Setup(i);
            }
        }
    }
}
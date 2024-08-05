using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Infrastructure.UILogic.DebriefingLogic.PanelLogic
{
    public class DebriefingPanelView : MonoBehaviour
    {
        private DebriefingPanelViewModel _viewModel;
        
        [SerializeField] private TextMeshProUGUI[] _wordTexts;

        private CompositeDisposable _disposable;
        
        [Inject]
        public virtual void Construct(DiContainer container)
        {
            _viewModel = container.Resolve<DebriefingPanelViewModel>();
            
            _disposable = new CompositeDisposable();
        }
        
        public void OnToLobby()
        {
            _viewModel.ToLobby();
        }
    }
}
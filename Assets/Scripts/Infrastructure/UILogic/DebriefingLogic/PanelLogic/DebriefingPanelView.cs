using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Infrastructure.UILogic.DebriefingLogic.PanelLogic
{
    public class DebriefingPanelView : MonoBehaviour
    {
        private DebriefingPanelViewModel _viewModel;
        
        [FormerlySerializedAs("_winnerNameTexts")] [SerializeField] private TextMeshProUGUI _winnerNameText;

        private CompositeDisposable _disposable;
        
        [Inject]
        public virtual void Construct(DiContainer container)
        {
            _viewModel = container.Resolve<DebriefingPanelViewModel>();
            
            _disposable = new CompositeDisposable();
        }
        
        private void Start()
        {
            _viewModel.OnDisplayWinnerName.Subscribe((value) => DisplayWinnerName(value)).AddTo(_disposable);

            DisplayWinnerName(_viewModel.GetWinnerName());
        }

        private void DisplayWinnerName(string name)
        {
            _winnerNameText.text = name;
        }

        public void OnToLobby()
        {
            _viewModel.ToLobby();
        }
    }
}
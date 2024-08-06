using System;
using TMPro;
using UniRx;
using UnityEngine;

namespace GuessGameplayLogic.GuessLogic
{
    public class GuessView : MonoBehaviour, Infrastructure.PoolLogic.IPoolable<GuessView>
    {
        private GuessViewModel _viewModel;

        public RectTransform RectTransform => _rectTransform;
        private RectTransform _rectTransform;
        [SerializeField] private TextMeshProUGUI _guessOwnerText;
        [SerializeField] private TextMeshProUGUI _guessValueText;
        [SerializeField] private RectTransform _indicator;

        private CompositeDisposable _disposable;
        
        private Action<GuessView> _returnToPool;
        
        public void Setup(GuessViewModel viewModel)
        {
            _disposable?.Dispose();
            _disposable = new CompositeDisposable();

            _rectTransform = GetComponent<RectTransform>();
            
            _viewModel = viewModel;

            _viewModel.ParentTransform.Subscribe((value) => SetParent(value)).AddTo(_disposable);
            _viewModel.Position.Subscribe((value) => SetPosition(value)).AddTo(_disposable);
            
            ConfigureView();

            gameObject.SetActive(true);
        }

        private void ConfigureView()
        {
            _guessOwnerText.text = _viewModel.Model.Owner;
            _guessValueText.text = _viewModel.Model.NumberValue.ToString();
            if (_viewModel.Model.NumberStatus == NumberStatus.Lower) _indicator.localEulerAngles = new Vector3(0,0,180);
            else if (_viewModel.Model.NumberStatus == NumberStatus.Higher) _indicator.localEulerAngles = Vector3.zero;
        }
        
        private void SetParent(Transform parent)
        {
            _rectTransform.SetParent(parent);
            _rectTransform.localScale = Vector3.one;
        }

        private void SetPosition(Vector2 position)
        {
            _rectTransform.anchoredPosition = position;   
        }
        
        #region POOL_LOGIC
        
        public void PoolInitialize(Action<GuessView> returnAction)
        {
            _returnToPool = returnAction;
        }
        
        public virtual void ReturnToPool()
        {
            _returnToPool?.Invoke(this);
        }
        
        #endregion
    }
}
using Infrastructure.UILogic.GameplayLogic;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace GuessGameplayLogic.GuessLogic
{
    public class GuessViewModel
    {
        public GuessModel Model { get; }
        
        public IReadOnlyReactiveProperty<Transform> ParentTransform => _parentTransform;
        private ReactiveProperty<Transform> _parentTransform;
        public IReadOnlyReactiveProperty<Vector2> Position => _position;
        private ReactiveProperty<Vector2> _position;
        
        public GuessViewModel(GuessModel model)
        {
            Model = model;
            
            _parentTransform = new ReactiveProperty<Transform>();
            _position = new ReactiveProperty<Vector2>();
        }
        
        public void SetParentAndPosition(Transform parent, Vector2 position)
        {
            _parentTransform.Value = parent;
            _position.Value = position;
        }

        private void SetParent(Transform parent)
        {
            _parentTransform.Value = parent;
        }

        private void SetPosition(Vector2 position)
        {
            _position.Value = position;
        }
    }
}
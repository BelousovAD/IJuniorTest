namespace Fort.View
{
    using UnityEngine;
    using Zenject;

    public class FortSelectionView : MonoBehaviour
    {
        [SerializeField] private Fort _fort;
        [SerializeField] private MonoBehaviour _outlineComponent;

        private FortContainer _fortContainer;

        private void OnEnable()
        {
            _fortContainer.Selection.Changed += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _fortContainer.Selection.Changed -= UpdateView;

        [Inject]
        private void Initialize(FortContainer fortContainer) =>
            _fortContainer = fortContainer;

        private void UpdateView() =>
            _outlineComponent.enabled = _fortContainer.Selection.Value == _fort;
    }
}
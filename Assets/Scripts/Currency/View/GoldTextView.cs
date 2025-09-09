namespace Currency.View
{
    using TMPro;
    using UnityEngine;

    [RequireComponent(typeof(TMP_Text))]
    public class GoldTextView : MonoBehaviour
    {
        [SerializeField] private string _format = "{0}";
        [SerializeField] private Gold _gold;
        
        private TMP_Text _textField;

        private void Awake() =>
            _textField = GetComponent<TMP_Text>();

        private void OnEnable()
        {
            _gold.Changed += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _gold.Changed -= UpdateView;

        private void UpdateView() =>
            _textField.text = string.Format(_format, _gold.Value);
    }
}

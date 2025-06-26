namespace DevPackages.UI
{
    using Common;
    using TMPro;
    using UnityEngine;

    [RequireComponent(typeof(TextMeshProUGUI))]
    public abstract class AbstractTextView<T> : AbstractParameterView<T> where T : IChangableParameter
    {
        [SerializeField] protected string TextFormat;

        protected TextMeshProUGUI TextField;

        protected virtual void Awake() =>
            TextField = GetComponent<TextMeshProUGUI>();
    }
}
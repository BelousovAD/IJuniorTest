using Common.ChangeableValue;
using Common.View;
using TMPro;
using UnityEngine;

namespace UI.View
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public abstract class AbstractTextView<T> : AbstractParameterView<T> where T : IChangeableValue
    {
        [SerializeField] protected string TextFormat;

        protected TextMeshProUGUI TextField;

        protected virtual void Awake() =>
            TextField = GetComponent<TextMeshProUGUI>();
    }
}
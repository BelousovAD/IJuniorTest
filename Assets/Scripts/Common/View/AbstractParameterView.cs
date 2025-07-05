using Common.ChangeableValue;
using UnityEngine;

namespace Common.View
{
    public abstract class AbstractParameterView<T> : MonoBehaviour where T : IChangeableValue
    {
        [SerializeField] protected T Parameter;

        protected virtual void OnEnable()
        {
            Parameter.ValueChanged += UpdateView;
            UpdateView();
        }

        protected virtual void OnDisable() =>
            Parameter.ValueChanged -= UpdateView;

        protected abstract void UpdateView();
    }
}
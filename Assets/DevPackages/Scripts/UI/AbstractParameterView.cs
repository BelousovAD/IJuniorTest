namespace DevPackages.UI
{
    using Common;
    using UnityEngine;

    public abstract class AbstractParameterView<T> : MonoBehaviour where T : IChangableParameter
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
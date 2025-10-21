namespace UI.Window.View
{
    using UnityEngine;

    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(Window))]
    public abstract class AbstractWindowView : MonoBehaviour
    {
        protected const float MinAlpha = 0f;
        protected const float MaxAlpha = 1f;

        protected CanvasGroup CanvasGroup { get; private set; }

        protected Window Window { get; private set; }

        protected virtual void Awake()
        {
            CanvasGroup = GetComponent<CanvasGroup>();
            Window = GetComponent<Window>();
        }

        protected void OnEnable()
        {
            Window.VisibleChanged += UpdateView;
            UpdateView();
        }

        protected void OnDisable() =>
            Window.VisibleChanged -= UpdateView;

        public abstract void UpdateView();
    }
}
namespace UI.View
{
    using TMPro;
    using UnityEngine;

    [RequireComponent(typeof(TMP_Text))]
    public abstract class AbstractTMPView : MonoBehaviour, IView
    {
        [SerializeField] private string _format;
        
        protected TMP_Text TextField { get; private set; }

        protected string Format => _format;

        protected virtual void Awake() =>
            TextField = GetComponent<TMP_Text>();

        public abstract void UpdateView();
    }
}
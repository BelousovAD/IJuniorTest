using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class AbstractButton : MonoBehaviour
{
    protected Button Button;

    protected virtual void Awake() =>
        Button = GetComponent<Button>();

    protected virtual void OnEnable() =>
        Button.onClick.AddListener(ClickHandler);

    protected virtual void OnDisable() =>
        Button.onClick.RemoveListener(ClickHandler);

    protected abstract void ClickHandler();
}

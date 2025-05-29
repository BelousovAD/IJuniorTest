using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CounterTextView : MonoBehaviour
{
    [SerializeField]
    private Counter _counter;

    private Text _textField;

    private void Awake() =>
        _textField = GetComponent<Text>();

    private void OnEnable()
    {
        _counter.CountChanged += UpdateUI;
        UpdateUI();
    }

    private void OnDisable() =>
        _counter.CountChanged -= UpdateUI;

    private void UpdateUI() =>
        _textField.text = _counter.Count.ToString();
}

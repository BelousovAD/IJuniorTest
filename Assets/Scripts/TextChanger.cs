using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextChanger : MonoBehaviour
{
    private const int LoopCount = -1;
    
    [SerializeField] private string _replacingText;
    [SerializeField] private string _appendedText;
    [SerializeField] private string _hackedText;
    [SerializeField] private float _stepDuration;
    [SerializeField] private float _delay;
    
    private Text _textField;

    private void Awake() =>
        _textField = GetComponent<Text>();

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_textField.DOText(_replacingText, _stepDuration));
        sequence.AppendInterval(_delay);
        sequence.Append(_textField.DOText(_appendedText, _stepDuration).SetRelative());
        sequence.AppendInterval(_delay);
        sequence.Append(_textField.DOText(_hackedText, _stepDuration, true, ScrambleMode.All));
        sequence.AppendInterval(_delay);
        sequence.SetLoops(LoopCount, LoopType.Restart);
    }
}
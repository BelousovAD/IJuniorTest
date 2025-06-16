using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = nameof(Jump);

    private int _horizontalInput;

    public event Action<int> HorizontalInputChanged;
    public event Action JumpRequested;

    private int HorizontalInput
    {
        set
        {
            if (value != _horizontalInput)
            {
                _horizontalInput = value;
                HorizontalInputChanged?.Invoke(_horizontalInput);
            }
        }
    }

    private void Update()
    {
        HorizontalInput = Mathf.RoundToInt(Input.GetAxisRaw(Horizontal));

        if (Input.GetButton(Jump))
        {
            JumpRequested?.Invoke();
        }
    }
}

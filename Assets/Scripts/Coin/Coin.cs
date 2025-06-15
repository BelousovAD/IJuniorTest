using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private uint _value;

    public uint Value =>
        _value;
}

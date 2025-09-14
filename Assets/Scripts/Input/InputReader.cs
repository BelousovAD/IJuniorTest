namespace Input
{
    using System;
    using UnityEngine;

    public class InputReader : MonoBehaviour
    {
        [SerializeField] private KeyCode _throwKey;
        [SerializeField] private KeyCode _readyKey;
        [SerializeField] private KeyCode _spawnBallKey;
        [SerializeField] private KeyCode _pushKey;

        public event Action ThrowRequested;
        public event Action GetReadyRequested;
        public event Action SpawnBallRequested;
        public event Action PushRequested;
        
        private void Update()
        {
            if (Input.GetKeyDown(_throwKey))
            {
                ThrowRequested?.Invoke();
            }

            if (Input.GetKeyDown(_readyKey))
            {
                GetReadyRequested?.Invoke();
            }

            if (Input.GetKeyDown(_spawnBallKey))
            {
                SpawnBallRequested?.Invoke();
            }
            
            if (Input.GetKeyDown(_pushKey))
            {
                PushRequested?.Invoke();
            }
        }
    }
}

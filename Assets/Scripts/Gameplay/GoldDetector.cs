namespace Gameplay
{
    using System;
    using Item;
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    public class GoldDetector : MonoBehaviour
    {
        public event Action<Gold> Detected;

        private void OnTriggerEnter(Collider other)
        {
            Gold gold = other.GetComponent<Gold>();
            
            if (gold is not null && gold.IsDetected == false)
            {
                gold.Detect();
                Detected?.Invoke(gold);
            }
        }
    }
}
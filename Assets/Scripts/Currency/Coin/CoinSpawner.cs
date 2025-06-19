namespace Currency.Coin
{
    using System.Collections.Generic;
    using UnityEngine;

    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField] private Coin _prefab;
        [SerializeField] private Transform _parent;
        [SerializeField] private List<Transform> _spawnPoints = new();

        private void Start() =>
            SpawnAtPoints();

        public void SpawnAtPoints()
        {
            foreach (Transform point in _spawnPoints)
            {
                Coin coin = Instantiate(_prefab, point.position, Quaternion.identity, _parent);
                coin.Collected += DestroyCoin;
            }
        }

        private void DestroyCoin(Coin coin)
        {
            coin.Collected -= DestroyCoin;
            Destroy(coin.gameObject);
        }

#if UNITY_EDITOR
        [ContextMenu(nameof(RefreshPointsArray))]
        private void RefreshPointsArray()
        {
            int pointCount = transform.childCount;

            for (int i = 0; i < pointCount; i++)
            {
                _spawnPoints.Add(transform.GetChild(i));
            }
        }
#endif
    }
}

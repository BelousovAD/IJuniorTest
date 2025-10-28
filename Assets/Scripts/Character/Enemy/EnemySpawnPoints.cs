namespace Character.Enemy
{
    using System.Collections.Generic;
    using Common.Spawn;
    using UnityEngine;

    public class EnemySpawnPoints : MonoBehaviour
    {
        [SerializeField] private List<Transform> _points = new();

        public Vector3 GetRandomPoint()
        {
            Transform point = _points[Random.Range(0, _points.Count)];

            return point.position;
        }
    }
}
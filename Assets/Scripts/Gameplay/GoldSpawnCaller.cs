namespace Gameplay
{
    using System.Collections;
    using Common.Spawn;
    using UnityEngine;

    public class GoldSpawnCaller : MonoBehaviour
    {
        [SerializeField, Min(0.005f)] private float _spawnDelay = 0.1f;
        [SerializeField] private SpawnPlane _spawnPlane;
        [SerializeField] private Spawner _spawner;

        private void OnEnable() =>
            StartCoroutine(SpawnWithDelayRoutine(_spawnDelay));

        private IEnumerator SpawnWithDelayRoutine(float triggerTime)
        {
            while (isActiveAndEnabled)
            {
                yield return new WaitForSeconds(triggerTime);

                _spawner.SpawnAt(_spawnPlane.GetRandomPoint());
            }
        }
    }
}
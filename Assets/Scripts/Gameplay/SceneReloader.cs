namespace Gameplay
{
    using Common.Spawn;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class SceneReloader : MonoBehaviour
    {
        [SerializeField] private PooledComponent _player;

        private static void ReloadScene(PooledComponent pooledComponent) =>
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        private void OnEnable() =>
            _player.ReleaseRequested += ReloadScene;

        private void OnDisable() =>
            _player.ReleaseRequested -= ReloadScene;
    }
}
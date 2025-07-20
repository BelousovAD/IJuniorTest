namespace Gameplay
{
    using Character.Player;
    using UI.Window;
    using UnityEngine;

    public class PlayerDeathObserver : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private WindowManipulator _windowManipulator;

        private void OnEnable() =>
            _player.Died += OpenRestartWindow;

        private void OnDisable() =>
            _player.Died -= OpenRestartWindow;

        private void OpenRestartWindow() =>
            _windowManipulator.OpenWindow(WindowId.Restart);
    }
}
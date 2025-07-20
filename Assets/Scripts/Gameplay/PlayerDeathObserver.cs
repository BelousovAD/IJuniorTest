using Character.Player;
using UI;
using UnityEngine;

namespace Gameplay
{
    using UI.Window;

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
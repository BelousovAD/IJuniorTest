using UnityEngine;
using UnityEngine.UI;

namespace Common.View
{
    [RequireComponent(typeof(Text))]
    public class SpawnerView : MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;
        
        private Text _textField;

        private void Awake() =>
            _textField = GetComponent<Text>();

        private void OnEnable() =>
            _spawner.SpawnCountChanged += UpdateView;

        private void OnDisable() =>
            _spawner.SpawnCountChanged -= UpdateView;

        private void UpdateView() =>
            _textField.text = $"{nameof(_spawner.SpawnCount)}: {_spawner.SpawnCount}\n" +
                              $"{nameof(_spawner.InstanceCount)}: {_spawner.InstanceCount}\n" +
                              $"{nameof(_spawner.ActiveInstanceCount)}: {_spawner.ActiveInstanceCount}";
    }
}
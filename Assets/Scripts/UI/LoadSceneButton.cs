using Common.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class LoadSceneButton : AbstractButton
    {
        [SerializeField]
        private string _sceneToLoad;
        public override void OnClick() =>
            SceneManager.LoadScene(_sceneToLoad);
    }
}
namespace UI.Button
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class LoadSceneButton : AbstractButton
    {
        [SerializeField] private string _sceneToLoad;
        
        public override void HandleClick() =>
            SceneManager.LoadScene(_sceneToLoad);
    }
}
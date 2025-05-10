using UnityEngine;
using UnityEngine.SceneManagement;

namespace KartGame.UI
{
    public class LoadSceneButton : MonoBehaviour
    {
        [Tooltip("What is the name of the scene we want to load when clicking the button?")]
        public string SceneName;

        public void LoadTargetScene() 
        {
            SceneManager.LoadSceneAsync(SceneName);
        }

        public void QuitGame()
        {
            Debug.Log("Quitter le jeu...");
            Application.Quit();

#if UNITY_EDITOR
            // Pour que ça fonctionne dans l'éditeur Unity
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}

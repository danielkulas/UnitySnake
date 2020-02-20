using UnityEngine;
using UnityEngine.SceneManagement;


namespace DanielKulasSnake
{
    public class PersistentSceneManager : MonoBehaviour
    {
        public static PersistentSceneManager instance {get; private set;}

        void Awake()
        {
            if(instance == null)
            {   
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void goToMenuScene() 
        {
            SceneManager.LoadScene("MenuScene");
        }

        public void goToGameScene() 
        {
            SceneManager.LoadScene("GameScene");
        }

        public void goToGameOverScene()
        {       
            SceneManager.LoadScene("GameOverScene");
        }
    }
}

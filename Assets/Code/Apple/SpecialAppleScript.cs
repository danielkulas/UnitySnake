using UnityEngine;


namespace DanielKulasSnake
{
    public class SpecialAppleScript : MonoBehaviour
    {
        private BoardManager boardManager;
        private float timeToFlick;

        public void initialize(BoardManager boardManager, float timeToDestroy, float flickingTime)
        {
            this.boardManager = boardManager;
            Invoke("DestroyApple", timeToDestroy);
            timeToFlick = timeToDestroy - flickingTime;
        }

        void Update()
        {
            timeToFlick -= Time.deltaTime;

            if(timeToFlick < 0)
                GetComponent<Animation>().enabled = true;
        }

        void DestroyApple()
        {
            boardManager.removeApple(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}

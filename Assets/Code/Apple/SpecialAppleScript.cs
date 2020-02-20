using UnityEngine;


namespace DanielKulasSnake
{
    public class SpecialAppleScript : MonoBehaviour
    {
        private BoardManager boardManager; //Reference to boardManager
        private float timeToFlick; //After timeToFlick, flick animation is turned on


        /// <summary>
        /// This metod is called by AppleSpawner.
        /// It sets parameters.
        /// After timeToDestroy the object is being destroyed(DestroyApple method is called)
        /// </summary>
        public void initialize(BoardManager boardManager, float timeToDestroy, float flickingTime)
        {
            this.boardManager = boardManager;
            Invoke("DestroyApple", timeToDestroy);
            timeToFlick = timeToDestroy - flickingTime;
        }

        /// <summary>
        /// This method counts the time to turn on the flicking animation.
        /// </summary>
        void Update()
        {
            timeToFlick -= Time.deltaTime;

            if(timeToFlick < 0)
                GetComponent<Animation>().enabled = true;
        }

        /// <summary>
        /// This metod is called after timeToDestroy(in initialize method)
        /// It removes this object from boardManager list.
        /// Then Destroy method is called
        /// </summary>
        void DestroyApple()
        {
            boardManager.removeApple(this.gameObject.transform);
            Destroy(this.gameObject);
        }
    }
}

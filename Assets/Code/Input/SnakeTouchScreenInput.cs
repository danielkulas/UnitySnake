using UnityEngine;


namespace DanielKulasSnake
{
    public class SnakeTouchScreenInput : SnakeBaseInput
    {
        #region Variables
            private float screenCenterX; //Center of the screen horizontally
            protected float touchTime; //Time of the last touch
            protected float minTouchInterval = 0.1f; //Minimum interval between touches(in seconds)
        #endregion

        #region Methods
        void Start() 
        {
            screenCenterX = Screen.width * 0.5f;
            touchTime = Time.time;
        }

        /// <summary>
        /// This method is overrided for touch screens devices
        /// </summary>
        public override void handleInput()
        {
            if(Input.touchCount > 0) //If there are any touches
            {
                Touch touch = Input.GetTouch(0);
                
                if (touch.phase == TouchPhase.Began && touch.phase != TouchPhase.Canceled && //When touch began
                    Time.time - touchTime > minTouchInterval)
                {
                    if(Input.GetTouch(0).position.x < screenCenterX)
                        left = true;
                    else
                        right = true;

                    touchTime = Time.time;
                }
            }
        }
        #endregion
    }
}

using UnityEngine;


namespace DanielKulasSnake
{
    public class SnakeTouchScreenInput : SnakeBaseInput
    {
        #region Variables
            private float screenCenterX; 
            protected float touchTime; 
            protected float minTouchInterval = 0.1f; 
        #endregion

        #region Methods
        void Start() 
        {
            screenCenterX = Screen.width * 0.5f;
            touchTime = Time.time;
        }

        public override void handleInput()
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                
                if (touch.phase == TouchPhase.Began && touch.phase != TouchPhase.Canceled &&
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

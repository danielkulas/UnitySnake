using UnityEngine;


namespace DanielKulasSnake
{    
    public class SnakeBaseInput : MonoBehaviour
    {
        #region Variables
        protected static bool left = false;
        protected static bool right = false;
        #endregion


        /// <summary>
        /// After get request, field(left or right) is reset
        /// </summary>
        #region Properties
        public bool Left   
        {
            get { 
                bool tmp = left;
                left = false;
                return tmp; 
            } 
        }

        public bool Right
        {
            get { 
                bool tmp = right;
                right = false;
                return tmp; 
            } 
        }
        #endregion


        #region Methods
        void Update()
        {
            handleInput();
        }

        /// <summary>
        /// It checks if turn command was invoked
        /// </summary>
        public virtual void handleInput() 
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                left = true;
            else if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                right = true;
        }

        /// <summary>
        /// This method reset left and right fields.
        /// </summary>
        public void resetInputs() 
        {
            left = false;
            right = false;
        }
        #endregion
    }
}

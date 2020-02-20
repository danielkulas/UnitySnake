using UnityEngine;


namespace DanielKulasSnake
{    
    public class SnakeBaseInput : MonoBehaviour
    {
        #region Variables
        protected static bool left = false;
        protected static bool right = false;
        #endregion


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

        public virtual void handleInput() 
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                left = true;
            else if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                right = true;
        }

        public void resetInputs() 
        {
            left = false;
            right = false;
        }
        #endregion
    }
}

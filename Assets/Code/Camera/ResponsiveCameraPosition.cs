using UnityEngine;


namespace DanielKulasSnake
{
    [RequireComponent(typeof(Camera))] //Requires Camera
    public class ResponsiveCameraPosition : MonoBehaviour
    {
        [SerializeField]
        private BoardCreator boardCreator; //Reference to boardCreator
        
        
        void Start()
        {
            boardCreator = boardCreator.GetComponent<BoardCreator>();
            setCameraPosition();
        }

        /// <summary>
        /// This method is called on Start.
        /// It sets position of the camera, so that the board is in the middle of the screen.
        /// (0,0) point is on the bottom left. (maxX,maxY) is on the top right of the screen.
        /// </summary>
        private void setCameraPosition()
        {
            float wallSize = 1.0f;
            int noOfFieldsX = getNoOfFieldsX();
            float cameraSize = GetComponent<Camera>().orthographicSize; //How many fields is visible vertically(multiplied by 2)

            float cameraPosX = ((float)noOfFieldsX/2.0f) - (0.5f * wallSize); //Board in the middle of the screen
            float cameraPoxY = cameraSize - wallSize; //Coords(0,0) on the bottom of the screen + wallSize offset up
            transform.position = new Vector3(cameraPosX, cameraPoxY, transform.position.z);
        }

        /// <summary>
        /// This metod returns number of fields horizontally(x axis) from boardCreator (or returns default value=10)
        /// </summary>
        private int getNoOfFieldsX()
        {
            int noOfFieldsX = 10;

            if(boardCreator)
                noOfFieldsX = boardCreator.GetNoOfFieldsX();

            return noOfFieldsX;
        }
    }
}

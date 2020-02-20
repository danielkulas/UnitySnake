using UnityEngine;


namespace DanielKulasSnake
{
    [RequireComponent(typeof(Camera))]
    public class ResponsiveCameraPosition : MonoBehaviour
    {
        [SerializeField]
        private BoardCreator boardCreator;
        
        
        void Start()
        {
            boardCreator = boardCreator.GetComponent<BoardCreator>();
            setCameraPosition();
        }

        private void setCameraPosition()
        {
            int noOfFieldsX = getNoOfFieldsX();
            float wallSize = 1.0f;
            float cameraSize = GetComponent<Camera>().orthographicSize;

            float cameraPosX = ((float)noOfFieldsX/2.0f) - (0.5f * wallSize);
            transform.position = new Vector3(cameraPosX, cameraSize - wallSize, transform.position.z);
        }

        private int getNoOfFieldsX()
        {
            int noOfFieldsX = 10;

            if(boardCreator)
                noOfFieldsX = boardCreator.GetNoOfFieldsX();

            return noOfFieldsX;
        }
    }
}

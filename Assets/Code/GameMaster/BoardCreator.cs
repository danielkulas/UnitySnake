using UnityEngine;


namespace DanielKulasSnake
{
    public class BoardCreator : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private GameObject bgLightFieldPrefab; //Prefab of the light field
        [SerializeField]
        private GameObject bgDarkFieldPrefab; //Prefab of the dark field
        [SerializeField]
        [Range(5,20)] 
        private int noOfFieldsX = 10; //Number of field horizontally
        [SerializeField]
        [Range(5,20)]
        private int noOfFieldsY = 15; //Number of fields vertically
        #endregion


        #region Paremeters 
        //Getters
        public int GetNoOfFieldsX()
        {
            return noOfFieldsX;
        }

        public int GetNoOfFieldsY()
        {
            return noOfFieldsY;
        }
        #endregion


        #region Methods
        private void Start() 
        {
            generateFields();
        }

        /// <summary>
        /// This method generates graphics of the board
        /// It places fields from (0,0) point, to (maxX, maxY)(each field is 1.0 size)
        /// </summary>
        private void generateFields()
        {
            Vector3Int startPos = new Vector3Int(0,0,10);
            Vector3Int pos = startPos;
            GameObject newField;

            for(int i = 0; i < noOfFieldsY; i++)
            {
                for(int j = 0; j < noOfFieldsX; j++)
                {
                    if(bgDarkFieldPrefab != null && bgLightFieldPrefab != null)
                    {
                        if((i + j) % 2 == 0) //Alternately light and dark
                            newField = Instantiate(bgDarkFieldPrefab);
                        else
                            newField = Instantiate(bgLightFieldPrefab);

                        newField.transform.SetParent(this.transform);
                        newField.transform.position = pos;
                    }

                    pos.x++;
                }
                pos.x = startPos.x;
                pos.y ++;
            }
        }
        #endregion
    }
}

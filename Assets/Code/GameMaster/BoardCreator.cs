using UnityEngine;


namespace DanielKulasSnake
{
    public class BoardCreator : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private GameObject bgLightFieldPrefab;
        [SerializeField]
        private GameObject bgDarkFieldPrefab;
        [SerializeField]
        [Range(5,20)] 
        private int noOfFieldsX = 10;
        [SerializeField]
        [Range(5,20)]
        private int noOfFieldsY = 15;
        #endregion


        #region Paremeters
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
                        if((i + j) % 2 == 0)
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

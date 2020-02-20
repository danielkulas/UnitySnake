using System.Collections.Generic;
using UnityEngine;


namespace DanielKulasSnake
{
    public class SnakeController : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private BoardManager boardManager;
        [SerializeField]
        private GameObject snakeBodyPartPrefab;
        private SnakeBaseInput input;
        [Range(0.05f,2.0f)]
        [SerializeField]
        [Tooltip("In seconds(speed)")]
        private float timeToNextMove = 0.2f;
        [Range(2,5)]
        [SerializeField]
        private int initialSnakeLength = 5;
        private int snakeLength = 1;
        private Vector2 movement = Vector2.up;
        private List<Vector3> positionHistory = new List<Vector3>();
        private List<GameObject> snakeBodyParts = new List<GameObject>();
        #endregion

        #region Methods
        void Start()
        {
            input = GetComponent<SnakeBaseInput>();

            if(!input.isActiveAndEnabled)
                input = GetComponent<SnakeTouchScreenInput>();

            transform.position = new Vector3Int(0, 4, (int)transform.position.z);
            InvokeRepeating("move", timeToNextMove, timeToNextMove);

            setInitialLen();
        }

        private void setInitialLen()
        {
            boardManager.addSnakePart(this.gameObject);

            for(int i = 0; i < initialSnakeLength - 1; i++)
            {
                Vector3 historyPos = new Vector3(transform.position.x, transform.position.y - (float)i - 1.0f, transform.position.z);
                positionHistory.Insert(i, historyPos);
                grow();
            }
        }

        private void move()
        { 
            Vector2 tmp = movement;

            if(input.Left)
            {
                if(movement.Equals(Vector2.up))
                    tmp = Vector2.left;
                else if(movement.Equals(Vector2.right))
                    tmp = Vector2.up;
                else if(movement.Equals(Vector2.down))
                    tmp = Vector2.right;
                else if(movement.Equals(Vector2.left))
                    tmp = Vector2.down;
            }
            else if(input.Right)
            {
                if(movement.Equals(Vector2.up))
                    tmp = Vector2.right;
                else if(movement.Equals(Vector2.right))
                    tmp = Vector2.down;
                else if(movement.Equals(Vector2.down))
                    tmp = Vector2.left;
                else if(movement.Equals(Vector2.left))
                    tmp = Vector2.up;
            }

            positionHistory.Insert(0, transform.position);
            if(positionHistory.Count > snakeLength + 1)
                positionHistory.RemoveAt(positionHistory.Count - 1);

            movement = tmp;
            transform.position += (Vector3)movement;

            setSnakeBodyPartsPos();
            boardManager.validatePosition();
        }

        private void setSnakeBodyPartsPos()
        {
            for(int i = 0; i < snakeBodyParts.Count; i++)
            {
                snakeBodyParts[i].transform.position = positionHistory[i];
            }
        }

        public void grow()
        {
            GameObject newBodyPart = Instantiate(snakeBodyPartPrefab, transform.position, Quaternion.identity);
            newBodyPart.transform.SetParent(transform);
            newBodyPart.transform.position = boardManager.getLastSnakePartPos();
            snakeBodyParts.Add(newBodyPart);
            boardManager.addSnakePart(newBodyPart);
            snakeLength++;
            setSnakeBodyPartsPos();
        }
        #endregion
    }
}

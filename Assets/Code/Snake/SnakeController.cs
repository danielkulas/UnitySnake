using System.Collections.Generic;
using UnityEngine;


namespace DanielKulasSnake
{
    public class SnakeController : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private BoardManager boardManager; //Reference to boardManager
        [SerializeField]
        private GameObject snakeBodyPartPrefab; //Prefab of the snake body
        private SnakeBaseInput input; //Reference to snakeBaseInput
        [Range(0.05f,2.0f)]
        [SerializeField]
        [Tooltip("In seconds(speed)")]
        private float timeToNextMove = 0.2f; //Determines time to next move(in seconds)
        [Range(1,5)]
        [SerializeField]
        private int initialSnakeLength = 5; //Snake lenght on beginning
        /// <summary>
        /// Current snake length. 1 - only head.
        /// On beginning(Start method) snake will grow to initialSnakeLength
        /// </summary>
        private int snakeLength = 1;
        private Vector2 movement = Vector2.up; //Vector of movement. Determines direction of next move
        /// <summary>
        /// Snake history positions.
        /// Snake root saves its positions, snake bodyparts follow these positions
        /// </summary>
        private List<Vector2> positionHistory = new List<Vector2>();
        private List<GameObject> snakeBodyParts = new List<GameObject>(); //List of all snake parts
        #endregion

        #region Methods
        void Start()
        {
            input = GetComponent<SnakeBaseInput>(); //Keyboard

            if(!input.isActiveAndEnabled)
                input = GetComponent<SnakeTouchScreenInput>(); //Touch screen

            transform.position = new Vector3Int(4, 4, (int)transform.position.z);
            InvokeRepeating("move", timeToNextMove, timeToNextMove);
            setInitialLen();
        }

        /// <summary>
        /// This method adds snake body parts(to initialSnakeLength)
        /// </summary>
        private void setInitialLen()
        {
            boardManager.addSnakePart(this.gameObject.transform);

            for(int i = 0; i < initialSnakeLength - 1; i++)
            {
                Vector2 historyPos = new Vector2(transform.position.x, transform.position.y - (float)i - 1.0f);
                positionHistory.Insert(i, historyPos);
                grow();
            }
        }

        /// <summary>
        /// This method takes inputs from SnakeBaseInput and sets movement vector
        /// </summary>
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

            setPosHistory();

            movement = tmp;
            transform.position += (Vector3)movement;

            setSnakeBodyPartsPos();
            boardManager.validatePosition();
        }

        /// <summary>
        /// This method adds current position to positionHistory list
        /// If there are too many positions, it removes them
        /// </summary>
        private void setPosHistory()
        {
            positionHistory.Insert(0, transform.position);
            if(positionHistory.Count > snakeLength + 1)
                positionHistory.RemoveAt(positionHistory.Count - 1);
        }

        /// <summary>
        /// This method sets snake body parts positions(based on positionHistory)
        /// </summary>
        private void setSnakeBodyPartsPos()
        {
            for(int i = 0; i < snakeBodyParts.Count; i++)
            {
                snakeBodyParts[i].transform.position = positionHistory[i];
            }
        }

        /// <summary>
        /// This method adds new body part to snake
        /// </summary>
        public void grow()
        {
            GameObject newBodyPart = Instantiate(snakeBodyPartPrefab, transform.position, Quaternion.identity);
            newBodyPart.transform.SetParent(transform);
            snakeBodyParts.Add(newBodyPart);
            boardManager.addSnakePart(newBodyPart.transform);
            snakeLength++;
            setSnakeBodyPartsPos();
        }
        #endregion
    }
}

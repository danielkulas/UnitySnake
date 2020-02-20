using System.Collections.Generic;
using UnityEngine;


namespace DanielKulasSnake
{
    public class BoardManager : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private int noOfPointsForApple = 1; //Number of points for eating an apple
        [SerializeField]
        private int noOfPointsForSpecialApple = 10; //Number of points for eating a special apple
        private List<Transform> snakeParts = new List<Transform>(); //List of snake body parts 
        private List<Transform> apples = new List<Transform>(); //List of apples 
        private int noOfFieldsX; //Number of fields vertically
        private int noOfFieldsY; //Number of fields horizontally
        private PositionsValidator positionsValidator; //Reference to positionsValidator
        private PlayerStats playerStats; //Referece to playerStats
        #endregion


        #region Parameters
        public void addSnakePart(Transform snakePart)
        {
            snakeParts.Add(snakePart);
        }

        public void addApple(Transform apple)
        {
            apples.Add(apple);
        }

        public void removeApple(Transform apple)
        {
            apples.Remove(apple);
        }

        public Vector3Int getEmptyField()
        {
            return positionsValidator.getEmptyField(snakeParts, apples, noOfFieldsX, noOfFieldsY);
        }
        #endregion


        #region Methods
        void Awake()
        {
            positionsValidator = GetComponent<PositionsValidator>();
            playerStats = GetComponent<PlayerStats>();
            noOfFieldsX = GetComponent<BoardCreator>().GetNoOfFieldsX();
            noOfFieldsY = GetComponent<BoardCreator>().GetNoOfFieldsY();
        }

        public void validatePosition()
        {
            checkSnakeAteApple();
            checkEndGame();
        }

        /// <summary>
        /// Checks if the snake ate an apple
        /// </summary>
        private void checkSnakeAteApple()
        {
            if(positionsValidator)
            {
                Transform eatenApple = positionsValidator.doesSnakeAteApple(snakeParts, apples);
                if(eatenApple != null)
                {
                    if(eatenApple.tag == "Special")
                    {
                        playerStats.addPoints(noOfPointsForSpecialApple);
                    }
                    else
                    {
                        playerStats.addPoints(noOfPointsForApple);
                        GetComponent<AppleSpawner>().spawnApple(positionsValidator.getEmptyField(snakeParts, apples, noOfFieldsX, noOfFieldsY), false);
                    }

                    snakeParts[0].GetComponent<SnakeController>().grow();
                    snakeParts[0].GetComponent<AudioSource>().Play();
                    apples.Remove(eatenApple);
                    Destroy(eatenApple.gameObject);
                }
            }
        }

        /// <summary>
        /// Checks if the game should end(snake collisions)
        /// </summary>
        private void checkEndGame()
        {
            if(positionsValidator)
            {
                if(positionsValidator.doesSnakeCollidedHimself(snakeParts) || 
                    positionsValidator.doesSnakeHitWall(snakeParts, noOfFieldsX, noOfFieldsY))
                {
                        endGame();
                }
            }
        }
        
        private void endGame()
        {
            PersistentSceneManager.instance.goToGameOverScene();
        }
        #endregion
    }
}

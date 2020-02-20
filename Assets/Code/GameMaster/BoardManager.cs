using System.Collections.Generic;
using UnityEngine;


namespace DanielKulasSnake
{
    public class BoardManager : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private int noOfPointsForApple = 1;
        [SerializeField]
        private int noOfPointsForSpecialApple = 10;
        private List<GameObject> snakeParts = new List<GameObject>();
        private List<GameObject> apples = new List<GameObject>();
        private int noOfFieldsX;
        private int noOfFieldsY;
        private PositionsValidator positionsValidator;
        private PlayerStats playerStats;
        #endregion


        #region Parameters
        public Vector3 getLastSnakePartPos()
        {
            return snakeParts[snakeParts.Count - 1].transform.position;
        }

        public void addSnakePart(GameObject snakePart)
        {
            snakeParts.Add(snakePart);
        }

        public void addApple(GameObject apple)
        {
            apples.Add(apple);
        }

        public void removeApple(GameObject apple)
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

        private void checkSnakeAteApple()
        {
            if(positionsValidator)
            {
                GameObject eatenApple = positionsValidator.doesSnakeAteApple(snakeParts, apples);
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
                    Destroy(eatenApple);
                }
            }
        }

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

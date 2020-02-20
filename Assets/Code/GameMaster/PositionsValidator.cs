using System.Collections.Generic;
using UnityEngine;


namespace DanielKulasSnake
{
    public class PositionsValidator : MonoBehaviour
    {
        /// <summary>
        /// Checks if snake and apples have collided
        /// This method return Transform of eaten apple, or null
        /// </summary>
        public Transform doesSnakeAteApple(List<Transform> snakeParts, List<Transform> apples)
        {
            Transform eatenApple = null;

            foreach(Transform apple in apples)
            {
                if(snakeParts[0].transform.position == apple.transform.position)
                {
                    eatenApple = apple;
                    return eatenApple;        
                }
            }

            return eatenApple;
        }

        /// <summary>
        /// Checks if the snake collided with itself
        /// This method return true if it collided, or false when doesn't
        /// </summary>
        public bool doesSnakeCollidedHimself(List<Transform> snakeParts)
        {
            for(int i = 1; i < snakeParts.Count; i++)
            {
                if (snakeParts[0].transform.position == snakeParts[i].transform.position)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if the snake collided with the wall
        /// This method return true if it collided, or false when doesn't
        /// </summary>
        public bool doesSnakeHitWall(List<Transform> snakeParts, int noOfFieldsX, int noOfFieldsY)
        {
            if(snakeParts[0].transform.position.x < 0 || snakeParts[0].transform.position.x >= noOfFieldsX ||
                snakeParts[0].transform.position.y < 0 || snakeParts[0].transform.position.y >= noOfFieldsY)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// This method returns Vector3Int of empty field on the board
        /// </summary>
        public Vector3Int getEmptyField(List<Transform> snakeParts, List<Transform> apples, int noOfFieldsX, int noOfFieldsY)
        {
            bool isNotEmpty;
            int xPos = 0, yPos = 0;

            do
            {
                isNotEmpty = false;
                xPos = Random.Range(0, noOfFieldsX);
                yPos = Random.Range(0, noOfFieldsY);

                foreach(Transform snakePart in snakeParts)
                {
                    if(xPos == snakePart.transform.position.x &&
                        yPos == snakePart.transform.position.y)
                    {
                        isNotEmpty = true;
                        break;
                    }
                }

                if(isNotEmpty)
                    continue;

                foreach(Transform apple in apples)
                {
                    if(xPos == apple.transform.position.x &&
                        yPos == apple.transform.position.y)
                    {
                        isNotEmpty = true;
                        break;
                    }
                }
            } while(isNotEmpty);

            Vector3Int pos = new Vector3Int(xPos, yPos, 0);
            return pos;
        }
    }
}

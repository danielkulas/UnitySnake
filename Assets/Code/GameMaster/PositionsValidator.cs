using System.Collections.Generic;
using UnityEngine;


namespace DanielKulasSnake
{
    public class PositionsValidator : MonoBehaviour
    {
        public GameObject doesSnakeAteApple(List<GameObject> snakeParts, List<GameObject> apples)
        {
            GameObject eatenApple = null;

            foreach(GameObject snakePart in snakeParts)
            {
                foreach(GameObject apple in apples)
                {
                    if(snakePart.transform.position == apple.transform.position)
                    {
                        eatenApple = apple;
                        return eatenApple;        
                    }
                }
            }

            return eatenApple;
        }

        public bool doesSnakeCollidedHimself(List<GameObject> snakeParts)
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

        public bool doesSnakeHitWall(List<GameObject> snakeParts, int noOfFieldsX, int noOfFieldsY)
        {
            if(snakeParts[0].transform.position.x < 0 || snakeParts[0].transform.position.x >= noOfFieldsX ||
                snakeParts[0].transform.position.y < 0 || snakeParts[0].transform.position.y >= noOfFieldsY)
            {
                return true;
            }

            return false;
        }

        public Vector3Int getEmptyField(List<GameObject> snakeParts, List<GameObject> apples, int noOfFieldsX, int noOfFieldsY)
        {
            bool isNotEmpty;
            int xPos = 0, yPos = 0;

            do
            {
                isNotEmpty = false;
                xPos = Random.Range(0, noOfFieldsX);
                yPos = Random.Range(0, noOfFieldsY);

                foreach(GameObject snakePart in snakeParts)
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

                foreach(GameObject apple in apples)
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

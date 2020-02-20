using UnityEngine;
using UnityEngine.UI;


namespace DanielKulasSnake
{
    public class GameOverTextScoreSetter : MonoBehaviour
    {
        void Start()
        {
            Text score = GetComponent<Text>();

            if(score)
            {
                score.text += PlayerPrefs.GetInt("LastScore", 0).ToString();
            }
        }
    }
}

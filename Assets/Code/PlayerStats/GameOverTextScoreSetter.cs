using UnityEngine;
using UnityEngine.UI;


namespace DanielKulasSnake
{
    public class GameOverTextScoreSetter : MonoBehaviour
    {
        void Start()
        {
            setLastScore();
        }

        /// <summary>
        /// This method sets last score value in UI
        /// </summary>
        private void setLastScore()
        {
            Text score = GetComponent<Text>();

            if(score)
                score.text += PlayerPrefs.GetInt("LastScore", 0).ToString();
        }
    }
}

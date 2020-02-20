using UnityEngine;
using UnityEngine.UI;


namespace DanielKulasSnake
{
    public class TextScoreSetter : MonoBehaviour
    {
        [SerializeField]
        Text scoreText; //Reference to UI text(current result)
        private string scoreOnBegin; //UI text before modifying
        [SerializeField]
        Text highestScoreText; //Reference to UI text(best result)
        private string highScoreOnBegin; //UI text before modifying
        [SerializeField]
        private PlayerStats playerStats; //Reference to playerStats


        void Start()
        {
            if(scoreText)
            {
                scoreOnBegin = scoreText.text;
                scoreText.text = scoreOnBegin + playerStats.score.ToString();
            }

            if(highestScoreText)
            {
                highScoreOnBegin = highestScoreText.text;
                highestScoreText.text = highScoreOnBegin + playerStats.highestScore.ToString();
            }
        }

        /// <summary>
        /// This method sets current score in UI
        /// </summary>
        public void setScore()
        {
            if(scoreText)
                scoreText.text = scoreOnBegin + playerStats.score.ToString();
        }
    }
}

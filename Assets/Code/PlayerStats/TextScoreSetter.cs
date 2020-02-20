using UnityEngine;
using UnityEngine.UI;

namespace DanielKulasSnake
{
    public class TextScoreSetter : MonoBehaviour
    {
        [SerializeField]
        Text scoreText;
        private string scoreOnBegin;
        [SerializeField]
        Text highestScoreText;
        [SerializeField]
        private PlayerStats playerStats;
        private string highScoreOnBegin;

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

        public void setScore()
        {
            if(scoreText)
                scoreText.text = scoreOnBegin + playerStats.score.ToString();
        }
    }
}

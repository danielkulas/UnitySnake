using UnityEngine;
using UnityEngine.Events;


namespace DanielKulasSnake
{
    public class PlayerStats : MonoBehaviour
    {
        public int score{get; private set;}
        public int highestScore{get; private set;}
        UnityEvent scoringPointsEvent = new UnityEvent();
        [SerializeField]
        private TextScoreSetter textScoreSetter;
        private string highestScorePrefsName = "HighestScore2";


        void Start()
        {
            textScoreSetter = textScoreSetter.GetComponent<TextScoreSetter>();
            if(textScoreSetter)
                scoringPointsEvent.AddListener(textScoreSetter.setScore);
            
            PlayerPrefs.SetInt("LastScore", 0);

            score = 0;
            highestScore = PlayerPrefs.GetInt(highestScorePrefsName);
        }

        void OnDestroy()
        {
            PlayerPrefs.SetInt("LastScore", score);

            if(score > PlayerPrefs.GetInt(highestScorePrefsName))
                PlayerPrefs.SetInt(highestScorePrefsName, score);
        }

        public void addPoints(int points)
        {
            score += points;

            if(scoringPointsEvent != null)
                scoringPointsEvent.Invoke();
        }
    }
}

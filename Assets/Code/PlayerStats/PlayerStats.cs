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
        public string highestScorePrefsName{get; private set;} = "HighestScore";
        public string lastScorePrefsName{get; private set;} = "LastScore";

        void Awake()
        {
            PlayerPrefs.SetInt(lastScorePrefsName, 0);
            highestScore = PlayerPrefs.GetInt(highestScorePrefsName, 0);
            score = 0;
        }

        void Start()
        {
            textScoreSetter = textScoreSetter.GetComponent<TextScoreSetter>();
            if(textScoreSetter)
                scoringPointsEvent.AddListener(textScoreSetter.setScore);
        }

        void OnDestroy()
        {
            PlayerPrefs.SetInt(lastScorePrefsName, score);

            if(score > PlayerPrefs.GetInt(highestScorePrefsName, 0))
                PlayerPrefs.SetInt(highestScorePrefsName, score);

            PlayerPrefs.Save();
        }

        public void addPoints(int points)
        {
            score += points;

            if(scoringPointsEvent != null)
                scoringPointsEvent.Invoke();
        }
    }
}

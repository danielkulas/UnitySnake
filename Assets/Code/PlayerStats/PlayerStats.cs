using UnityEngine;
using UnityEngine.Events;


namespace DanielKulasSnake
{
    public class PlayerStats : MonoBehaviour
    {
        public int score{get; private set;} //Current player score
        public int highestScore{get; private set;} //Best player score
        UnityEvent scoringPointsEvent = new UnityEvent(); //Event is called(to UI text setter) after adding points
        [SerializeField]
        private TextScoreSetter textScoreSetter; //Reference to textScoreSetter
        public string highestScorePrefsName{get; private set;} = "HighestScore"; //Name of best score in PlayerPrefs
        public string lastScorePrefsName{get; private set;} = "LastScore"; //Name of last score in PlayerPrefs

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

        /// <summary>
        /// This method is called when the MonoBehaviour will be destroyed
        /// It sets last score, and checks if the current score is the highest score
        /// </summary>
        void OnDestroy()
        {
            PlayerPrefs.SetInt(lastScorePrefsName, score);

            if(score > PlayerPrefs.GetInt(highestScorePrefsName, 0))
                PlayerPrefs.SetInt(highestScorePrefsName, score);

            PlayerPrefs.Save();
        }

        /// <summary>
        /// This method takes points as an argument, and adds it to current score
        /// After this the scoringPointsEvent is invoked
        /// </summary>
        public void addPoints(int points)
        {
            score += points;

            if(scoringPointsEvent != null)
                scoringPointsEvent.Invoke();
        }
    }
}

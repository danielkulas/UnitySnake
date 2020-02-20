using UnityEngine;
using UnityEngine.UI;


namespace DanielKulasSnake
{
    public class GameOverTextScoreSetter : MonoBehaviour
    {
        void Start()
        {
            Text score = GetComponent<Text>();

            if(score && PlayerPrefs.HasKey("LastScore"))
            {
                score.text += PlayerPrefs.GetInt("LastScore").ToString();
            }
        }
    }
}

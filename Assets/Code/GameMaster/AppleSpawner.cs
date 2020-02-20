using UnityEngine;


namespace DanielKulasSnake
{
    public class AppleSpawner : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private GameObject applePrefab;
        [SerializeField]
        private GameObject specialApplePrefab;
        private BoardManager boardManager;

        [Header("Special apple settings")]
        [SerializeField]
        [Range(1,10)]
        [Tooltip("In seconds")]
        private float flickingTime = 3.0f;
        [SerializeField]
        [Range(3,8)]
        [Tooltip("In seconds")]
        private float minTimeOfLife = 5.0f;
        [SerializeField]
        [Range(8,13)]
        [Tooltip("In seconds")]
        private float maxTimeOfLife = 10.0f;
        [SerializeField]
        [Range(13,20)]
        [Tooltip("In seconds")]
        private float minIntervalBetweenSpawns = 18.0f;
        [SerializeField]
        [Range(20,30)]
        [Tooltip("In seconds")]
        private float maxInterfalBetweenSpawns = 28.0f;
        #endregion


        #region Methods
        void Start() 
        {
            boardManager = GetComponent<BoardManager>();
            if(boardManager)
                spawnApple(boardManager.getEmptyField(), false); 

            Invoke("spawnSpecialApple", Random.Range(minIntervalBetweenSpawns, maxInterfalBetweenSpawns));
        }

        public void spawnApple(Vector3 pos, bool isSpecial)
        {
            Quaternion rot = Quaternion.identity;
            GameObject newApple = null;

            if(!isSpecial && applePrefab!= null)
            {
                newApple = Instantiate(applePrefab, pos, rot);
            }
            else if(isSpecial && specialApplePrefab != null)
            {
                newApple = Instantiate(specialApplePrefab, pos, rot);
                float timeOfLife = Random.Range(minTimeOfLife, maxTimeOfLife);

                SpecialAppleScript specialAppleScript = newApple.GetComponent<SpecialAppleScript>();
                if(specialAppleScript)
                    specialAppleScript.initialize(boardManager, timeOfLife, 3.0f);
            }

            if(newApple != null)
                boardManager.addApple(newApple);
        }

        private void spawnSpecialApple()
        {
            float timeToSpawn = Random.Range(minIntervalBetweenSpawns, maxInterfalBetweenSpawns);
            spawnApple(boardManager.getEmptyField(), true);
            Invoke("spawnSpecialApple", timeToSpawn);
        }
        #endregion
    }
}

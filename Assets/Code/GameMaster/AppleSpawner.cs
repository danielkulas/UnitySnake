using UnityEngine;


namespace DanielKulasSnake
{
    public class AppleSpawner : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private GameObject applePrefab; //Special apple prefab
        [SerializeField]
        private GameObject specialApplePrefab; //Apple prefab
        private BoardManager boardManager; //Reference to boardManager

        [Header("Special apple settings")]
        [SerializeField]
        [Range(1,10)]
        [Tooltip("In seconds")]
        private float flickingTime = 3.0f; //It specifies how long special apple blinks
        [SerializeField]
        [Range(3,8)]
        [Tooltip("In seconds")]
        private float minTimeOfLife = 5.0f; //It specifies minimum time of life of special apple
        [SerializeField]
        [Range(8,13)]
        [Tooltip("In seconds")]
        private float maxTimeOfLife = 10.0f; //It specifies maximum time of life of special apple
        [SerializeField]
        [Range(13,20)]
        [Tooltip("In seconds")]
        private float minIntervalBetweenSpawns = 18.0f; //It specifies minimum interval between spawns of the special apples
        [SerializeField]
        [Range(20,30)]
        [Tooltip("In seconds")]
        private float maxInterfalBetweenSpawns = 28.0f; //It specifies maximum interval between spawns of the special apples
        #endregion


        #region Methods
        /// <summary>
        /// It calls the spawnApple method for regular apple
        ///     and calls the spawnApple for special apple after random time
        /// </summary>
        void Start() 
        {
            boardManager = GetComponent<BoardManager>();
            if(boardManager)
                spawnApple(boardManager.getEmptyField(), false); 

            Invoke("spawnSpecialApple", Random.Range(minIntervalBetweenSpawns, maxInterfalBetweenSpawns));
        }

        /// <summary>
        /// This method takes position(where to spawn an apple) and bool isSpecial as parameters
        /// A new apple is spawned in this position
        /// </summary>
        public void spawnApple(Vector3Int pos, bool isSpecial)
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
                boardManager.addApple(newApple.transform);
        }

        /// <summary>
        /// It calls spawnApple method after random time to spawn a special apple
        /// </summary>
        private void spawnSpecialApple()
        {
            float timeToSpawn = Random.Range(minIntervalBetweenSpawns, maxInterfalBetweenSpawns);
            spawnApple(boardManager.getEmptyField(), true);
            Invoke("spawnSpecialApple", timeToSpawn);
        }
        #endregion
    }
}

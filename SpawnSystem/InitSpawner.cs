using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem
{
    public class InitSpawner : MonoBehaviour
    {
        void Start()
        {
            for (int i = 0; i < count; ++i)
            {
                _randX = Random.Range(xAxisBeginOfRange, xAxisEndOfRange);
                _randY = Random.Range(yAxisBeginOfRange, yAxisEndOfRange);
                _spawnPosition = new Vector2(_randX, _randY);
                Instantiate(gameObject, _spawnPosition, Quaternion.identity);
            }
        }

        //data members

        public GameObject gameObject;
        public float xAxisBeginOfRange;
        public float xAxisEndOfRange;
        public float yAxisBeginOfRange;
        public float yAxisEndOfRange;
        public int count;

        private float _randX;
        private float _randY;
        private Vector2 _spawnPosition;
    }
}//end of namespace SpawnSystem

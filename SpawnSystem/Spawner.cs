using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem
{
    public class Spawner : MonoBehaviour
    {
        void Start()
        {
            spawnRate = 2f;
            _nextSpawn = 0.0f;
            _count = 0;
        }
        
        void Update()
        {
            if (Time.time > _nextSpawn && _count < maxCount)
            {
                _nextSpawn = Time.time + spawnRate;
                _randX = Random.Range(-xAxisBeginOfRange + 50f, -xAxisEndOfRange + 50f);
                _randY = Random.Range(-yAxisBeginOfRange + 50f, -yAxisEndOfRange + 50f);
                _spawnPosition = new Vector2(_randX, _randY);
                Instantiate(spawnEntity, _spawnPosition, Quaternion.identity);
                ++_count;
            }
        }
        
        //data members
        public GameObject spawnEntity;
        [Range(0f, 100f)] public float spawnRate;
        [Range(1, 100)] public int maxCount;
        public float xAxisBeginOfRange;
        public float xAxisEndOfRange;
        public float yAxisBeginOfRange;
        public float yAxisEndOfRange;

        private float _randX;
        private float _randY;
        private int _count;
        private Vector2 _spawnPosition;
        private float _nextSpawn;
    }
}//end of namespace SpawnSystem

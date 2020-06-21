using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class Spawn : MonoBehaviour
    {
        void Start()
        {
            _playerPos = GameObject.Find("Player").GetComponent<Transform>();
        }

        public void SpawnItem()
        {
            Vector2 playerPos = new Vector2(_playerPos.position.x, _playerPos.position.y + 1.5f);
            Instantiate(item, playerPos, Quaternion.identity);
        }


        //data members
        public GameObject item;

        private Transform _playerPos;
    }
}//end of namespace InventorySystem
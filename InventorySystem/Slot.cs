using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class Slot : MonoBehaviour
    {
        private void Start()
        {
            _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        }

        private void Update()
        {
            if (transform.childCount <= 0)
            {
                _playerInventory.items[index] = 0;
            }
        }

        public void Cross()
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<Spawn>().SpawnItem();
                Destroy(child.gameObject);
            }
        }

        public void DestroyItem()
        {
            Destroy(this.gameObject);
        }

        //data members
        public int index;
        public GameObject destroyButton;

        private Inventory _playerInventory;
    }
}// end of namespace InventorySystem
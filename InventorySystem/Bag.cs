using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class Bag : MonoBehaviour
    {
        void Start()
        {
            _playerInventory = GameObject.Find("Player").GetComponent<Inventory>();
        }

        public void OpenCloseBag()
        {
            if (_isClosed == true)
            {
                foreach (var bagElement in _playerInventory.slots)
                {
                    bagElement.SetActive(true);
                }

                _isClosed = false;
            }
            else
            {
                foreach (var bagElement in _playerInventory.slots)
                {
                    bagElement.SetActive(false);
                }

                _isClosed = true;
            }
        }

        //data members
        private bool _isClosed;
        private InventorySystem.Inventory _playerInventory;
    }
}


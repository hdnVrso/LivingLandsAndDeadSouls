using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Interaction
{
    public class HouseInteraction : MonoBehaviour
    {
        void Start()
        {
            _playerInventory = GameObject.Find("Player").GetComponent<InventorySystem.Inventory>();
            _playerHealthComponent = GameObject.Find("Player").GetComponent<HealthFight.HealthComponent>();
            _isLooted = false;
            lootButton.SetActive(false);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_isLooted)
                return;
            if (other.name == "Player")
                lootButton.SetActive(true);
        }

        public void Use()
        {
            var i = Random.Range(0, loots.Length);
            if (i == loots.Length)
            {
                _playerHealthComponent.IncreaseHealth(10);
                return;
            }
            
            for (var j = 0; j < _playerInventory.items.Length; j++)
            {
                if (_playerInventory.items[j] != 0) continue;
                _playerInventory.items[j] = 1;
                var gunSelectComp = loots[i].GetComponent<InventorySystem.GunSelect>();
                if (gunSelectComp != null)
                    gunSelectComp.slotIndex = i;
                var outfitSelectComp = loots[i].GetComponent<InventorySystem.OutfitSelect>();
                if (outfitSelectComp != null)
                    outfitSelectComp.slotIndex = i;
                Instantiate(loots[i], _playerInventory.slots[j].transform, false);
                break;
            }
            _isLooted = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.name == "Player")
                lootButton.SetActive(false);
        }
        
        //data members
        public GameObject lootButton;
        public GameObject[] loots;
        
        private InventorySystem.Inventory _playerInventory;
        private HealthFight.HealthComponent _playerHealthComponent;
        private bool _isLooted;
    }
}// end of namespace interaction

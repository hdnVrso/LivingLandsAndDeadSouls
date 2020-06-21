using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class OutfitSlot : MonoBehaviour
    {
        public void ChangeOutfit(int i)
        {
            _gunSlot.skinIndex = skinIndex;
            _gunSlot.ChangeSkin();
            var child1 = this.gameObject.transform.GetChild(0);
            var child2 = this.gameObject.transform.GetChild(1);
            itemButton.SetActive(true);
            itemButton.GetComponent<OutfitSelect>().slotIndex = i;
            Instantiate(itemButton, _playerInventory.slots[i].transform, false);
            Destroy(child1.gameObject);
            Destroy(child2.gameObject);
        }

        public void ChangeSkin()
        {
            _gunSlot.skinIndex = skinIndex;
            _gunSlot.ChangeSkin();
        }

        public void SwapOutfits(int i)
        {
            var child1 = this.gameObject.transform.GetChild(0);
            var child2 = this.gameObject.transform.GetChild(1);
            itemButton.SetActive(true);
            itemButton.GetComponent<OutfitSelect>().slotIndex = i;
            Instantiate(itemButton, _playerInventory.slots[i].transform, false);
            Destroy(child1.gameObject);
            Destroy(child2.gameObject);
        }

        public void Cross()
        {
            var child1 = this.gameObject.transform.GetChild(0);
            var child2 = this.gameObject.transform.GetChild(1);
            if (child1 == null)
                return;
            for (int i = 0; i < _playerInventory.items.Length; ++i)
            {
                if (_playerInventory.items[i] == 0)
                {
                    itemButton.SetActive(true);
                    Instantiate(itemButton, _playerInventory.slots[i].transform, false);
                    itemButton.GetComponent<OutfitSelect>().skinIndex = i;
                    _playerInventory.items[i] = 1;
                    Destroy(child1.gameObject);
                    Destroy(child2.gameObject);
                    skinIndex = 0;
                    ChangeSkin();
                    return;
                }
            }

            Destroy(child1.gameObject);
            Destroy(child2.gameObject);
        }

        void Start()
        {
            _gunSlot = GameObject.Find("GunSlot").GetComponent<GunSlot>();
            _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        }

        //data members
        public int skinIndex;
        public GameObject itemButton;

        private Inventory _playerInventory;
        private GunSlot _gunSlot;
    }
}// end of namespace InventorySystem

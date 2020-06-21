using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace InventorySystem
{
    public class GunSlot : MonoBehaviour
    {
        public void Cross()
        {
            var child1 = this.gameObject.transform.GetChild(0);
            var child2 = this.gameObject.transform.GetChild(1);
            if (child1 == null)
                return;
            itemButton.GetComponent<GunSelect>().ammoCount =
                GameObject.Find("FireButton").GetComponent<HealthFight.Gun>().ammoCount;
            Debug.Log(itemButton);
            _playerAnimator.runtimeAnimatorController = animatorOverrideWG[skinIndex];
            for (int i = 0; i < _playerInventory.items.Length; ++i)
            {
                if (_playerInventory.items[i] == 0)
                {
                    itemButton.SetActive(true);
                    Instantiate(itemButton, _playerInventory.slots[i].transform, false);
                    itemButton.GetComponent<GunSelect>().skinIndex = i;
                    _playerInventory.items[i] = 1;
                    Destroy(child1.gameObject);
                    Destroy(child2.gameObject);
                    isEmpty = 1;
                    _gunComponent.ammoCount = 0;
                    return;
                }
            }

            Destroy(child1.gameObject);
            Destroy(child2.gameObject);
            isEmpty = 1;
            _gunComponent.ammoCount = 0;
        }

        public void SwapGuns(int i)
        {
            var child1 = this.gameObject.transform.GetChild(0);
            var child2 = this.gameObject.transform.GetChild(1);
            itemButton.GetComponent<GunSelect>().ammoCount =
                GameObject.Find("FireButton").GetComponent<HealthFight.Gun>().ammoCount;
            itemButton.SetActive(true);
            itemButton.GetComponent<GunSelect>().slotIndex = i;
            Instantiate(itemButton, _playerInventory.slots[i].transform, false);
            Destroy(child1.gameObject);
            Destroy(child2.gameObject);
        }

        private void Start()
        {
            _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            _playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
            _gunComponent = GameObject.Find("FireButton").GetComponent<HealthFight.Gun>();
        }

        public void ChangeSkin()
        {
            if (isEmpty == 1)
            {
                _playerAnimator.runtimeAnimatorController = animatorOverrideWG[skinIndex];
                return;
            }

            Debug.Log(skinIndex);
            _playerAnimator.runtimeAnimatorController = animatorOverride[skinIndex];
            Debug.Log("Changed skin");
        }

        //data members
        public GameObject itemButton;
        public AnimatorOverrideController[] animatorOverride;
        public AnimatorOverrideController[] animatorOverrideWG;
        public int skinIndex = 0;
        public int isEmpty = 1;

        private HealthFight.Gun _gunComponent;
        private Inventory _playerInventory;
        private Animator _playerAnimator;
    }
}
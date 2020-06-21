using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class GunSelect : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            _gunSlot = GameObject.Find("GunSlot");
        }

        // Update is called once per frame
        public void Use()
        {
            if (_gunSlot.transform.childCount > 0)
            {
                _gunSlot.GetComponent<GunSlot>().SwapGuns(slotIndex);
            }

            _gunSlot.GetComponent<GunSlot>().animatorOverride = animatorOverride;
            Instantiate(gunImage, _gunSlot.transform, false);
            _gunSlot.GetComponent<GunSlot>().itemButton = Instantiate(gunButton, _gunSlot.transform, false);
            _gunSlot.GetComponent<GunSlot>().itemButton.SetActive(false);
            _gunSlot.GetComponent<GunSlot>().isEmpty = 0;
            _gunSlot.GetComponent<GunSlot>().ChangeSkin();
            _fireButton = GameObject.Find("FireButton").GetComponent<HealthFight.Gun>();
            _fireButton.damage = damage;
            _fireButton.ammoCount = ammoCount;
            GameObject.Find("AmmoText").GetComponent<Text>().text = ammoCount.ToString();
            _fireButton.fireRate = fireRate;
            Destroy(gameObject);
        }

        public void DestroyItem()
        {
            Destroy(this.gameObject);
        }


        //data members
        public GameObject gunButton;
        public GameObject gunImage;
        public int damage;
        public int slotIndex;
        public int fireRate;
        public int ammoCount;
        public int skinIndex;
        public AnimatorOverrideController[] animatorOverride;

        private GameObject _gunSlot;
        private HealthFight.Gun _fireButton;
    }
}// end of namespace InventorySystem
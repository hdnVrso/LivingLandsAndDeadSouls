using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class OutfitSelect : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            _outfitSlot = GameObject.Find("SuitSlot");
        }

        public void Use()
        {
            if (_outfitSlot.transform.childCount > 0)
            {
                _outfitSlot.GetComponent<OutfitSlot>().SwapOutfits(slotIndex);
            }

            Debug.Log(outfitButton);
            Instantiate(outfitImage, _outfitSlot.transform, false);
            _outfitSlot.GetComponent<OutfitSlot>().itemButton = Instantiate(outfitButton, _outfitSlot.transform, false);
            _outfitSlot.GetComponent<OutfitSlot>().itemButton.SetActive(false);
            _outfitSlot.GetComponent<OutfitSlot>().skinIndex = skinIndex;
            _outfitSlot.GetComponent<OutfitSlot>().ChangeSkin();
            Debug.Log(gameObject);
            Destroy(gameObject);
        }

        public void DestroyItem()
        {
            Destroy(this.gameObject);
        }

        //data members
        public GameObject outfitButton;
        public GameObject outfitImage;
        public int slotIndex;
        public int skinIndex;

        private GameObject _outfitSlot;
    }
}// end of namespace InventorySystem

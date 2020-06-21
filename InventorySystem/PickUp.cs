using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
   public class PickUp : MonoBehaviour
   {
      private void Start()
      {
         _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
      }

      private void OnTriggerEnter2D(Collider2D other)
      {
         if (other.CompareTag("Player"))
         {
            for (int i = 0; i < _playerInventory.items.Length; i++)
            {
               if (_playerInventory.items[i] == 0)
               {
                  _playerInventory.items[i] = 1;
                  var gunSelectComp = itemButton.GetComponent<GunSelect>();

                  if (gunSelectComp != null)
                  {
                     gunSelectComp.slotIndex = i;
                  }

                  var outfitSelectComp = itemButton.GetComponent<OutfitSelect>();
                  if (outfitSelectComp != null)
                  {
                     outfitSelectComp.slotIndex = i;
                  }

                  Instantiate(itemButton, _playerInventory.slots[i].transform, false);
                  Destroy(gameObject);
                  break;
               }
            }
         }
      }

      //data members
      public GameObject itemButton;

      private Inventory _playerInventory;
   }
}// end of namespace InventorySystem


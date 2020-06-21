using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InventorySystem
{
    public class DropItem : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
    {
        public void OnBeginDrag(PointerEventData eventData)
        {

        }

        public void OnDrag(PointerEventData eventData)
        {

        }

        public void OnEndDrag(PointerEventData eventData)
        {
            this.GetComponent<Spawn>().SpawnItem();
            Destroy(gameObject);
        }
    }
}// end of namespace InventorySystem

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;


namespace SaveLoadSystem
{
    [System.Serializable]
    public class PlayerData
    {
        public int health;
        public float[] position;
        public int[] inventory;
        public int gun;
        public int outfit;

        //0 - empty
        //1 - medkit
        //2 - meat
        //3 - gun1
        //4 - gun2
        //5 - ammo
        //6 - outfit1
        //7 - outfit2

        public PlayerData(Vector3 playerPosition, InventorySystem.Inventory playerInventory, int health)
        {
            this.health = health;
            position = new float[3];
            position[0] = playerPosition.x;
            position[1] = playerPosition.y;
            position[2] = playerPosition.z;
            this.inventory = new int[6];
            for (int i = 0; i < playerInventory.slots.Length; ++i)
            {
                if (playerInventory.slots[i].transform.childCount <= 0)
                {
                    inventory[i] = 0;
                }
                else if (playerInventory.slots[i].transform.GetChild(0).GetComponent<InventorySystem.HealthBoost>() != null)
                {
                    if (playerInventory.slots[i].transform.GetChild(0).GetComponent<InventorySystem.HealthBoost>().healthBoost == 70)
                    {
                        inventory[i] = 1;
                    }
                    else
                    {
                        inventory[i] = 2;
                    }
                }
                else if (playerInventory.slots[i].transform.GetChild(0).GetComponent<InventorySystem.GunSelect>() != null)
                {
                    var dmg = playerInventory.slots[i].transform.GetChild(0).GetComponent<InventorySystem.GunSelect>().damage;
                    if (dmg == 10)
                    {
                        inventory[i] = 3;
                    }
                    else
                    {
                        inventory[i] = 4;
                    }
                }
                else if (playerInventory.slots[i].transform.GetChild(0).GetComponent<AmmoPick>() != null)
                {
                    inventory[i] = 5;
                }
                else
                {
                    Debug.Log(i);
                    var otft = playerInventory.slots[i].transform.GetChild(0).GetComponent<InventorySystem.OutfitSelect>().skinIndex;
                    if (otft == 1)
                    {
                        inventory[i] = 6;
                    }
                    else
                    {
                        inventory[i] = 7;
                    }
                }
            }
        }
    }
}// end of namespace SaveLoadSystem
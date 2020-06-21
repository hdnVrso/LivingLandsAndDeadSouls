using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Resources.scripts;


namespace SaveLoadSystem
{
    public class Load : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            LoadPlayer();
            Destroy(this.gameObject);
        }


        public void LoadPlayer()
        {
            Debug.Log("Continue");
            PlayerData data = SaveSystem.LoadPlayer();
            if (data == null)
                return;
            var player = GameObject.Find("Player");
            player.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
            player.GetComponent<HealthFight.HealthComponent>().health = data.health;
            var playerInventory = player.GetComponent<InventorySystem.Inventory>();
            Debug.Log("Continue22222");
            GameObject loadedObj;
            for (int i = 0; i < playerInventory.slots.Length; ++i)
            {
                switch (data.inventory[i])
                {
                    case 0:
                        continue;
                        break;
                    case 1:
                        Instantiate(medkitButton, playerInventory.slots[i].transform, false);
                        playerInventory.items[i] = 1;
                        break;
                    case 2:
                        Instantiate(meatButton, playerInventory.slots[i].transform, false);
                        playerInventory.items[i] = 1;
                        break;
                    case 3:
                        loadedObj = Instantiate(gun1Button, playerInventory.slots[i].transform, false);
                        playerInventory.items[i] = 1;
                        var gunSelectComp = loadedObj.GetComponent<InventorySystem.GunSelect>();
                        gunSelectComp.slotIndex = i;
                        break;
                    case 4:
                        loadedObj = Instantiate(gun2Button, playerInventory.slots[i].transform, false);
                        playerInventory.items[i] = 1;
                        var gunSelectComp2 = loadedObj.GetComponent<InventorySystem.GunSelect>();
                        gunSelectComp2.slotIndex = i;
                        break;
                    case 5:
                        Instantiate(ammoButton, playerInventory.slots[i].transform, false);
                        playerInventory.items[i] = 1;
                        break;
                    case 6:
                        loadedObj = Instantiate(outfit1Button, playerInventory.slots[i].transform, false);
                        playerInventory.items[i] = 1;
                        var outfitSelectComp = loadedObj.GetComponent<InventorySystem.OutfitSelect>();
                        outfitSelectComp.slotIndex = i;
                        break;
                    case 7:
                        loadedObj = Instantiate(outfit2Button, playerInventory.slots[i].transform, false);
                        playerInventory.items[i] = 1;
                        var outfitSelectComp2 = loadedObj.GetComponent<InventorySystem.OutfitSelect>();
                        outfitSelectComp2.slotIndex = i;
                        break;
                }
            }
        }

        //data members
        //data members
        public GameObject medkitButton;
        public GameObject meatButton;
        public GameObject outfit1Button;
        public GameObject outfit2Button;
        public GameObject gun1Button;
        public GameObject gun2Button;
        public GameObject ammoButton;

    }
}// end of namespace SaveLoadSystem

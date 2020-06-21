using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using Resources.scripts;

namespace SaveLoadSystem
{
    public static class SaveSystem
    {
        public static void SavePlayer(GameObject player)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/player.data";
            Debug.Log(path);
            PlayerData data = new PlayerData(player.transform.position,
                player.GetComponent<InventorySystem.Inventory>(),
                player.GetComponent<HealthFight.HealthComponent>().health);
            FileStream stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, data);
            stream.Close();
            Debug.Log("Saved");
        }

        public static PlayerData LoadPlayer()
        {
            string path = Application.persistentDataPath + "/player.data";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                stream.Close();
                return data;
            }
            else
            {
                return null;
            }
        }
    }
}// end of namespace SaveLoadSystem

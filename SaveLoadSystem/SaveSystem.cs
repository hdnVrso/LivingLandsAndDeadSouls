using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

namespace SaveLoadSystem
{
    public static class SaveSystem
    {
        public static void SavePlayer(GameObject player)
        {
            var formatter = new BinaryFormatter();
            var path = Application.persistentDataPath + "/player.data";
            Debug.Log(path);
            var data = new PlayerData(player.transform.position,
                player.GetComponent<InventorySystem.Inventory>(),
                player.GetComponent<HealthFight.HealthComponent>().health);
            var stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, data);
            stream.Close();
            Debug.Log("Saved");
        }

        public static PlayerData LoadPlayer()
        {
            var path = Application.persistentDataPath + "/player.data";
            if (File.Exists(path))
            {
                var formatter = new BinaryFormatter();
                var stream = new FileStream(path, FileMode.Open);
                var data = formatter.Deserialize(stream) as PlayerData;
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

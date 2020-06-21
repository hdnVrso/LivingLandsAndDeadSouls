using System.Collections;
using System.Collections.Generic;
using Resources.scripts;
using UnityEngine;

namespace InventorySystem
{
    public class HealthBoost : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            _playerHealth = GameObject.Find("Player").GetComponent<HealthFight.HealthComponent>();
        }

        public void Use()
        {
            if (_playerHealth.health + healthBoost > 100)
            {
                _playerHealth.health = 100;
                Destroy(gameObject);
                return;
            }

            _playerHealth.health += healthBoost;
            Destroy(gameObject);
        }

        //data members
        public int healthBoost;

        private HealthFight.HealthComponent _playerHealth;
    }
}// end of namespace inventorySystems
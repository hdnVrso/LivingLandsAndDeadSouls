using System.Collections;
using System.Collections.Generic;
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
            _playerHealth.IncreaseHealth(healthBoost);
            Destroy(gameObject);
        }

        //data members
        public int healthBoost;

        private HealthFight.HealthComponent _playerHealth;
    }
}// end of namespace inventorySystems
using System.Collections;
using System.Collections.Generic;
using HealthFight;
using UnityEngine;

namespace Characteristics
{
    public class ButtonHandler : MonoBehaviour
    {
        public void UpStrength()
        {
            characteristics = GameObject.Find("Characteristics");
            if (characteristics.GetComponent<AllParameters>().freePoints > 0)
            {
                GameObject.Find("FireButton").GetComponent<Gun>().damageBuff += 10;
                characteristics.GetComponent<AllParameters>().freePoints -= 1;
                characteristics.GetComponent<AllParameters>().strength += 1;
                characteristics.GetComponent<AllParameters>().Display();
            }
        }

        public void UpHealth()
        {
            characteristics = GameObject.Find("Characteristics");
            if (characteristics.GetComponent<AllParameters>().freePoints > 0)
            {
                GameObject.Find("Player").GetComponent<HealthComponent>().maxHealth += 10;
                characteristics.GetComponent<AllParameters>().freePoints -= 1;
                characteristics.GetComponent<AllParameters>().health += 1;
                characteristics.GetComponent<AllParameters>().Display();
            }
        }

        public void UpSniper()
        {
            characteristics = GameObject.Find("Characteristics");
            if (characteristics.GetComponent<AllParameters>().freePoints > 0)
            {
                characteristics.GetComponent<AllParameters>().freePoints -= 1 ;
                characteristics.GetComponent<AllParameters>().sniper += 1 ;
                characteristics.GetComponent<AllParameters>().Display();
            }
        }

        public GameObject characteristics;
        public Component parameters;
    }
}

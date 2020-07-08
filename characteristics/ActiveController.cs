using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characteristics
{
    public class ActiveController : MonoBehaviour
    {
        private GameObject characteristics;

        void Start()
        {
            characteristics = GameObject.Find("Characteristics");
        }

        public void Enable()
        {
            characteristics.GetComponent<Canvas>().enabled = true;
            characteristics.GetComponent<AllParameters>().Display();
        }

        public void Disabled()
        {
            characteristics.GetComponent<Canvas>().enabled = false;
        }
    }
}
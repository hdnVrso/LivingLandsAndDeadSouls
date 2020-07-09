using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characteristics
{
    public class ActivityController : MonoBehaviour
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

        public void Disable()
        {
            characteristics.GetComponent<Canvas>().enabled = false;
        }
    }
}
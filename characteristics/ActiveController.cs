using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveController : MonoBehaviour
{
    private GameObject characteristics;

    void Start()
    {
        characteristics=GameObject.Find("Characteristics");    
    }

    public void Enable()
    {
        characteristics.GetComponent<Canvas>().enabled=true;
    }

    public void Disabled()
    {
        characteristics.GetComponent<Canvas>().enabled=false;
    }
}

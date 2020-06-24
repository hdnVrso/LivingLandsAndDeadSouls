using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public GameObject characteristics;
    public Component parameters;

    public void UpStrength()
    {
        characteristics=GameObject.Find("Characteristics");
        if (characteristics.GetComponent<AllParameters>().freePoints>0)
        {
            characteristics.GetComponent<AllParameters>().freePoints-=1;
            characteristics.GetComponent<AllParameters>().strength+=1;
            characteristics.GetComponent<AllParameters>().Display();
        }
    }

    public void UpHealth()
    {
        characteristics=GameObject.Find("Characteristics");
        if (characteristics.GetComponent<AllParameters>().freePoints>0)
        {
            characteristics.GetComponent<AllParameters>().freePoints-=1;
            characteristics.GetComponent<AllParameters>().health+=1;
            characteristics.GetComponent<AllParameters>().Display();
        }
    }

    public void UpSniper()
    {
        characteristics=GameObject.Find("Characteristics");
        if (characteristics.GetComponent<AllParameters>().freePoints>0)
        {
            characteristics.GetComponent<AllParameters>().freePoints-=1;
            characteristics.GetComponent<AllParameters>().sniper+=1;
            characteristics.GetComponent<AllParameters>().Display();
        }
    }
}

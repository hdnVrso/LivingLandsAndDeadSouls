using System;
using System.Collections;
using System.Collections.Generic;
using HealthFight;
using UnityEngine;

public class UnitDeath : MonoBehaviour
{
    public GameObject loot;
    
    public void AfterDeath()
    {
        Vector3 meatPosition = gameObject.transform.position;
        GameObject locMeat = Instantiate(loot);
        locMeat.transform.position = meatPosition;
        Debug.Log("Loot dropped !");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoPick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        _fireButton = GameObject.Find("FireButton");
    }

    // Update is called once per frame
    public void Use()
    {
        gun = _fireButton.GetComponent<HealthFight.Gun>();
        gun.ammoCount += ammoCount;
        GameObject.Find("AmmoText").GetComponent<Text>().text = gun.ammoCount.ToString();
        Destroy(gameObject);
    }
    
    //data members
    public int ammoCount;
    
    private GameObject _fireButton;
    private HealthFight.Gun gun;
}

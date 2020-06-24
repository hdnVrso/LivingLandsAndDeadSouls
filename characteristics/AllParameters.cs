using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllParameters : MonoBehaviour
{
    private Canvas canvas;
    private bool infoOpen = false;
    public float expirience = 0;
    public int level = 1;
    public float toNextLevelExp = 100;
    public int strength;
    public int health;
    public int sniper;
    public int freePoints;
    private GameObject ValueSniper;
    private GameObject ValueHealth;
    private GameObject ValueFreePoints;
    private GameObject ValueLevel;
    private GameObject ValueStrength;
    private Component value;
    public void AddExpirience(float exp)
    {
        if (expirience+exp>toNextLevelExp)
        {
            expirience=expirience+exp-toNextLevelExp;
            level+=1;
            freePoints+=2;
            toNextLevelExp=toNextLevelExp*1.5f;
            Update();
        }
        else
        {
            expirience+=exp;
            Update();
        }
    }

    public void Display()
    {
        ValueLevel.GetComponent<UnityEngine.UI.Text>().text=level.ToString();
        ValueFreePoints.GetComponent<UnityEngine.UI.Text>().text=freePoints.ToString();
        ValueStrength.GetComponent<UnityEngine.UI.Text>().text=strength.ToString();
        ValueHealth.GetComponent<UnityEngine.UI.Text>().text=health.ToString();
        ValueSniper.GetComponent<UnityEngine.UI.Text>().text=sniper.ToString();
    }

    void Start()
    {
        ValueFreePoints=GameObject.Find("ValueFreePoints");
        ValueLevel=GameObject.Find("ValueLevel");
        ValueHealth=GameObject.Find("ValueHealth");
        ValueStrength=GameObject.Find("ValueStrength");
        ValueSniper=GameObject.Find("ValueSniper");
        canvas=GetComponent<Canvas>();
        canvas.enabled=false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (canvas.enabled)
            {
                canvas.enabled=false;
            }
            else
            {
                Display();
                canvas.enabled=true;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using Menu;
using UnityEngine;

namespace Characteristics
{
    public class AllParameters : MonoBehaviour
{
    public void AddExperience(float exp)
    {
        if (experience + exp >= toNextLevelExp)
        {
            experience = experience + exp - toNextLevelExp;
            level += 1;
            freePoints += 2;
            toNextLevelExp = toNextLevelExp*1.5f;
            Update();
        }
        else
        {
            experience += exp;
            Update();
        }
    }

    public void Display()
    {
        _personName.GetComponent<UnityEngine.UI.Text>().text = _playerName;
        _valueLevel.GetComponent<UnityEngine.UI.Text>().text = level.ToString();
        _valueFreePoints.GetComponent<UnityEngine.UI.Text>().text = freePoints.ToString();
        _valueStrength.GetComponent<UnityEngine.UI.Text>().text = strength.ToString();
        _valueHealth.GetComponent<UnityEngine.UI.Text>().text = health.ToString();
        valueSniper.GetComponent<UnityEngine.UI.Text>().text = sniper.ToString();
    }

    void Start()
    {
        switch (GameObject.Find("ParametersManager").GetComponent<ParameterManager>().characterI)
        {
            case 0:
                _playerName = "Dick Clarque";
                break;
            case 1:
                _playerName = "Hu Lee";
                break;
            case 2:
                _playerName = "Vitali Tsal";
                break;
        }
        _personName = GameObject.Find("Person name");
        _valueFreePoints = GameObject.Find("ValueFreePoints");
        _valueLevel = GameObject.Find("ValueLevel");
        _valueHealth = GameObject.Find("ValueHealth");
        _valueStrength = GameObject.Find("ValueStrength");
        valueSniper = GameObject.Find("ValueSniper");
        _canvas = GetComponent<Canvas>();
        _canvas.enabled = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (_canvas.enabled)
            {
                _canvas.enabled = false;
            }
            else
            {
                Display();
                _canvas.enabled = true;
            }
        }
    }
    //data members
    public float experience = 0;
    public int level = 1;
    public float toNextLevelExp = 100;
    public int strength;
    public int health;
    public int sniper;
    public int freePoints;
    
    private GameObject valueSniper;
    private GameObject _personName;
    private GameObject _valueHealth;
    private GameObject _valueFreePoints;
    private GameObject _valueLevel;
    private GameObject _valueStrength;
    private Component _val3ue;
    private string _playerName;
    private Canvas _canvas;
    private bool _infoOpen = false;
}
}

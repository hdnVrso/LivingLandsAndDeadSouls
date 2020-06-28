using System.Collections;
using System.Collections.Generic;
using GenerateMap;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;
public class TimeController : MonoBehaviour
{
    public UnityEngine.Experimental.Rendering.Universal.Light2D light;
    public UnityEngine.Experimental.Rendering.Universal.Light2D playerLight;
    public Text DayYear;
    public Generator generate;
    public GameObject Rain_Generator;
    public GameObject Snow_Generator;
    public float hour=12;
    public float timeS=0.01f;
    public int year=0;
    public int season=0;
    public int day = 0;
    double weather_chance=2;
    int precipitation;
    bool weather_is_act = false;
    public int weather_TTL;
    public double ch;
    void RainControll(double chance)
    {
        
        if (weather_is_act == false)
        {
            
            ch = Random.Range(0, 7000);
            if (ch <= chance)
            {
                weather_TTL = Random.Range(300, 3000);
                if (season == 2)
                    Snow_Generator.SetActive(true);
                else
                    Rain_Generator.SetActive(true);
                weather_is_act = true;
            }
        }
        if (weather_TTL > 0)
        {
            weather_TTL -= 1;
        }
        else
        {
            Rain_Generator.SetActive(false);
            Snow_Generator.SetActive(false);
            weather_is_act = false;
        }


    }
    
    void Start()
    {
        playerLight = GameObject.Find("Player").GetComponent<Light2D>();
        playerLight.intensity = 0;
       // light.color = new Vector4(0.83f, 0.81f, 0.42f, 1);
        precipitation = ParameterManager.instance.precipitation;
        season=GameObject.Find("ParametersManager").GetComponent<ParameterManager>().startSeason;
        changeSeason();
    }
    void FixedUpdate()
    {
        hour += timeS;
        if (hour >= 24)
        {
            hour = 0f;
            day += 1;
            if (day % 1 == 0)
            {
                if (season==3)
                {
                    season = 0;
                    year += 1;
                }
                else season += 1;
                changeSeason();
            }
            
        }
        RainControll(weather_chance);

        if (hour >= 3.5 && hour < 17 && light.intensity <= 1)
        {
            light.intensity += 0.0015f;
        }
        else if (light.intensity >= 0)
            light.intensity -= 0.0015f;

        if (light.intensity == 1)
        {
            playerLight.intensity = 0;
        }
        if (hour > 18  && hour <22 && playerLight.intensity<1)
        {
            playerLight.intensity += 0.0025f;
        }

        if (hour > 4 && hour < 8  && playerLight.intensity > 0)
        {
            playerLight.intensity -= 0.0025f;
        }
        DayYear.text = "Day " + day.ToString()+"\n Year " +year.ToString();
    }
    public void changeSeason()
    {
        switch (season)
        {
            case 0:
                weather_chance=2*precipitation;
                light.color=new Vector4(0.95f, 0.76f, 0.35f, 1);
                generate.treeList.ForEach(tree =>
                {
                    var spR = tree.GetComponentInChildren<SpriteRenderer>();

                    spR.sprite=UnityEngine.Resources.Load<Sprite>("Sprites/environment/tri");

                });
                break;

            case 1:
                light.color=new Vector4(1f, 1f, 1f, 1);
                weather_chance=10*precipitation;
                generate.treeList.ForEach(tree =>
                {
                    var spR = tree.GetComponentInChildren<SpriteRenderer>();

                    spR.sprite=UnityEngine.Resources.Load<Sprite>("Sprites/environment/Yellow_Tree");

                });
                generate.bushList.ForEach(bush =>
                {
                    var spR = bush.GetComponent<SpriteRenderer>();

                    spR.sprite=UnityEngine.Resources.Load<Sprite>("Sprites/environment/Fall_Bush");

                });
                for (int x = 0; x<generate.width; x++)
                {
                    for (int y = 0; y<generate.height; y++)
                    {

                        generate.topMap.SetTile(new Vector3Int(-x+generate.width/2, -y+generate.height/2, 0), generate.autumnTile);
                    }
                }
                //light.color=new Vector4(0.96f, 0.59f, 0.03f, 1);
                break;

            case 2:
                weather_chance=10;
                generate.rockList.ForEach(rock =>
                {
                    var spR = rock.GetComponent<SpriteRenderer>();

                    spR.sprite=UnityEngine.Resources.Load<Sprite>("Sprites/environment/Winter_Rock");

                });
                generate.treeList.ForEach(tree =>
                {
                    var spR = tree.GetComponentInChildren<SpriteRenderer>();

                    spR.sprite=UnityEngine.Resources.Load<Sprite>("Sprites/environment/Winter_Tree");

                });
                generate.bushList.ForEach(bush =>
                {
                    var spR = bush.GetComponent<SpriteRenderer>();

                    spR.sprite=UnityEngine.Resources.Load<Sprite>("Sprites/environment/Winter_Bush");

                });
                generate.houseList.ForEach(house =>
                {
                    var spR = house.GetComponent<SpriteRenderer>();
                    if (spR.tag=="Small House")
                        spR.sprite=UnityEngine.Resources.Load<Sprite>("Sprites/environment/Winter_Small_House");
                    else spR.sprite=UnityEngine.Resources.Load<Sprite>("Sprites/environment/Winter_Big_House");
                });
                for (int x = 0; x<generate.width; x++)
                {
                    for (int y = 0; y<generate.height; y++)
                    {

                        generate.topMap.SetTile(new Vector3Int(-x+generate.width/2, -y+generate.height/2, 0), generate.winterTile);
                    }
                }
                //light.color = new Vector4(0.07f, 0.94f, 0.94f, 1);
                break;

            case 3:
                weather_chance=5*precipitation;
                generate.rockList.ForEach(rock =>
                {
                    var spR = rock.GetComponent<SpriteRenderer>();

                    spR.sprite=UnityEngine.Resources.Load<Sprite>("Sprites/environment/ROCKKK");

                });
                generate.treeList.ForEach(tree =>
                {
                    var spR = tree.GetComponentInChildren<SpriteRenderer>();

                    spR.sprite=UnityEngine.Resources.Load<Sprite>("Sprites/environment/Spring_Tree");

                });
                generate.houseList.ForEach(house =>
                {
                    var spR = house.GetComponent<SpriteRenderer>();
                    if (spR.tag=="Small House")
                        spR.sprite=UnityEngine.Resources.Load<Sprite>("Sprites/environment/gray_house1");
                    else spR.sprite=UnityEngine.Resources.Load<Sprite>("Sprites/environment/Big_House");
                });
                generate.bushList.ForEach(bush =>
                {
                    var spR = bush.GetComponent<SpriteRenderer>();

                    spR.sprite=UnityEngine.Resources.Load<Sprite>("Sprites/environment/Bush");

                });
                for (int x = 0; x<generate.width; x++)
                {
                    for (int y = 0; y<generate.height; y++)
                    {

                        generate.topMap.SetTile(new Vector3Int(-x+generate.width/2, -y+generate.height/2, 0), generate.waterTile);
                    }
                }

                break;
        }
    }
}

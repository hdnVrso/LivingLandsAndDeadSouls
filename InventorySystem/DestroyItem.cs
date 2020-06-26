using UnityEngine;
using System.Collections;
using InventorySystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DestroyItem : MonoBehaviour
{
    public GameObject _destroyPanel;
    private float doubleClickTimeLimit = 0.25f;

    protected void Start()
    {
        StartCoroutine(InputListener());
    }

// Update is called once per frame
    private IEnumerator InputListener() 
    {
        while(enabled)
        { //Run as long as this is activ

            if(Input.GetMouseButtonDown(0))
                yield return ClickEvent();

            yield return null;
        }
    }

    private IEnumerator ClickEvent()
    {
        //pause a frame so you don't pick up the same mouse down event.
        yield return new WaitForEndOfFrame();

        float count = 0f;
        while(count < doubleClickTimeLimit)
        {
            if(Input.GetMouseButtonDown(0))
            {
                DoubleClick();
                yield break;
            }
            count += Time.deltaTime;// increment counter by change in time between frames
            yield return null; // wait for the next frame
        }
        SingleClick();
    }


    private void SingleClick()
    {
        GunSelect gunSelect;
        OutfitSelect outfitSelect;
        HealthBoost healthBoost;
        gunSelect = gameObject.GetComponent<GunSelect>();
        outfitSelect = gameObject.GetComponent<OutfitSelect>();
        healthBoost = gameObject.GetComponent<HealthBoost>();
        if (gunSelect != null)
        {
            Debug.Log("GunSelect use");
            gunSelect.Use();
        }
        else if (outfitSelect != null)
        {
            Debug.Log("OutFit select use");
            outfitSelect.Use();
        }
        else if (healthBoost != null)
        {
            Debug.Log("HealthBoos use");
            healthBoost.Use();
        }
    }

    private void DoubleClick()
    {
        _destroyPanel = GameObject.Find("DestroyPanel");
        Debug.Log("Set active destroy panel");
        _destroyPanel.SetActive(true);
        _destroyPanel.GetComponent<DestroyingItem>().destroyingItem = gameObject;
    }

}
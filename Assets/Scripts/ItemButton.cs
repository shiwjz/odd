using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemButton : MonoBehaviour
{

    public TMP_Text itemDisplayer;

    public TMP_Text PurchaseDisplayer;


    public TMP_Text itemNameDisplayer;

    public string itemName;

    public int level;

    //[HideInInspector]

    public int currentCost;

    public int startCurrentCost = 1;

    //[HideInInspector]

    public int goldPerSec;

    public int startGoldPerSec = 1;

    public float costPow = 3.14f;

    //[HideInInspector]

    public float upgradePow = 1.07f;
    
    public bool isPurchased = false;


    void Start()
    {
        DataController.GetInstance().LoadItemButton(this);
        StartCoroutine("AddGoldLoop");
        UpdateUI();
    }
    public void PurchaseItem()
    {
        if(DataController.GetInstance().GetGold() >= currentCost)
        {

            isPurchased = true;
            DataController.GetInstance().SubGold(currentCost);
            level++;

            UpdateItem();
            UpdateUI();
            DataController.GetInstance().SaveItemButton(this);
            
        }
    }

    IEnumerator AddGoldLoop()
    {
        while(true)
        {
            if(isPurchased)
            {
                DataController.GetInstance().AddGold(goldPerSec);
            }
            
            yield return new WaitForSeconds(1.0f);
            
        }

        
    }

    public void UpdateItem()
    {
        goldPerSec = goldPerSec + startGoldPerSec * (int)Mathf.Pow(upgradePow,level);
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow,level);
    }

    public void UpdateUI()
    {
        itemNameDisplayer.text = itemName;
        itemDisplayer.text = "Gold Per Sec: " + goldPerSec;
        if(isPurchased)
        {
            PurchaseDisplayer.text = "Purchased";
        }
        else
        {
            PurchaseDisplayer.text = "--";
        }
    }
    
}

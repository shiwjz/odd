using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    public AudioSource btnsource;

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

    private ItemData itemData;


    void Start()
    {
        itemData = GetComponent<ItemData>();
        DataController.GetInstance().LoadItemButton(this);
        StartCoroutine("AddGoldLoop");
        UpdateUI();
    }
    public void PurchaseItem()
    {
        if(DataController.GetInstance().GetGold() >= currentCost)
        {
            btnsource.Play();
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
        goldPerSec = itemData.goldPerSec;
        currentCost = itemData.currentCost;
        //goldPerSec = goldPerSec + startGoldPerSec * (int)Mathf.Pow(upgradePow,level);
        //currentCost = startCurrentCost * (int)Mathf.Pow(costPow,level);
    }

    public void UpdateUI()
    {
        itemNameDisplayer.text = itemName;
        itemDisplayer.text = "Gold Per Sec: " + goldPerSec + "\nCurrentCost: " + currentCost;
        if(isPurchased)
        {
            PurchaseDisplayer.text = "Lv." + level;
        }
        else
        {
            PurchaseDisplayer.text = "--";
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using System.Linq;

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

    //public float costPow = 3.14f;

    //[HideInInspector]

    //public float upgradePow = 1.07f;
    
    public bool isPurchased = false;

    public string FileName;

    private string[] dataRows;

    void Awake()
    {
        LoadGameData();
        DataController.GetInstance().LoadItemButton(this);
        UpdateItemData();
        //UpdateItem();
        UpdateUI();
        StartCoroutine("AddGoldLoop");
    }
    void LoadGameData()
    {
        TextAsset data = Resources.Load<TextAsset>(FileName);

        if (data != null)
        {
            dataRows = data.text.Split('\n');
            UpdateItemData();
        }
        else
        {
            Debug.LogError("Cannot find game data!");
        }
    }
    public void UpdateItemData()
    {
        string[] row = dataRows[level].Split(',');
        string[] nextrow = dataRows[level + 1].Split(',');

        if (!int.TryParse(row[2], out goldPerSec))
        {
            goldPerSec = 0;
        }
        else
        {
            goldPerSec = int.Parse(row[2]);
        }

        if (!int.TryParse(nextrow[1], out currentCost))
        {
            Debug.LogError("Failed to parse currentCost: " + row[1]);
        }
        else
        {
            currentCost = int.Parse(nextrow[1]);
        }

    }
    IEnumerator AddGoldLoop()
    {
        while (true)
        {
            if (isPurchased)
            {
                DataController.GetInstance().AddGold(goldPerSec);

            }

            yield return new WaitForSeconds(1.0f);            
        }
    }
    public void PurchaseItem()
    {
        if(DataController.GetInstance().GetGold() >= currentCost)
        {
            btnsource.Play();
            isPurchased = true;
            level++;

            DataController.GetInstance().SubGold(currentCost);
            UpdateItemData();
            UpdateUI();
            DataController.GetInstance().SaveItemButton(this);
            
        }
    }


    //public void UpdateItem()
    //{
    //    //goldPerSec = itemData.goldPerSec;
    //    //currentCost = itemData.currentCost;
    //    //goldPerSec = goldPerSec + startGoldPerSec * (int)Mathf.Pow(upgradePow,level);
    //    //currentCost = startCurrentCost * (int)Mathf.Pow(costPow,level);
    //}

    public void UpdateUI()
    {
        itemNameDisplayer.text = itemName;
        itemDisplayer.text = "Gold Per Sec: " + goldPerSec + "\nLv: " + level;
        PurchaseDisplayer.text = "Cost: " + currentCost;

    }
    
}

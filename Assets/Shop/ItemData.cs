using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using System.IO;
using System.Linq;

public class ItemData : MonoBehaviour
{

    public int level;

    //[HideInInspector]

    public int currentCost;

    //[HideInInspector]

    public int goldPerSec;

    public string FileName;

    private string[] dataRows;

    private ItemButton ItemButton;
    private void Awake()
    {
        ItemButton = GetComponent<ItemButton>();
        level = PlayerPrefs.GetInt(ItemButton.itemName + "_level");
        LoadGameData();
        UpdateItemData();
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
        string[] nextrow = dataRows[level+1].Split(',');

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
}

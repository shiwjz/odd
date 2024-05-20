using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using System.IO;
using System.Linq;

public class ItemData : MonoBehaviour
{
    public int level = 0;

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
        level = ItemButton.level;
        LoadGameData();
    }
    void LoadGameData()
    {
        TextAsset data = Resources.Load<TextAsset>(FileName);

        if (data != null)
        {
            dataRows = data.text.Split('\n');


            if (dataRows.Length > 1)
            {
                dataRows = dataRows.Skip(1).ToArray();
                UpdateItemData();
            }
        }
        else
        {
            Debug.LogError("Cannot find game data!");
        }
    }

    void UpdateItemData()
    {
        string[] row = dataRows[level].Split(',');

        if (!int.TryParse(row[2], out goldPerSec))
        {
            Debug.LogError("Failed to parse goldPerSec: " + row[0]);
        }

        if (!int.TryParse(row[1], out currentCost))
        {
            Debug.LogError("Failed to parse currentCost: " + row[1]);
        }
    }
}

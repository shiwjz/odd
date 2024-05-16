using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using static UpgradeButton;

public class UpgradeButton : MonoBehaviour
{
    public TMP_Text upgradeDisplayer;

    public string upgradeName;

    [HideInInspector]

    public int goldByUpgrade;
    public int startGoldByUpgrade = 1;

    [HideInInspector]

    public int currentCost;
    public int startCurrentCost = 1;
    public class PlayerData
    {
        public int level;
        public int price;
        public int production_p;
    }

    public List<PlayerData> playerDataList = new List<PlayerData>();

    void Start()
    {
        LoadPlayerDataFromCSV();
    }

    void LoadPlayerDataFromCSV()
    {
        TextAsset data = Resources.Load<TextAsset>("playerDB");

        if (data != null)
        {
            string[] rows = data.text.Split('\n');

            for (int i = 1; i < rows.Length; i++)
            {
                string[] row = rows[i].Split(',');

                PlayerData playerData = new PlayerData();
                playerData.level = int.Parse(row[0]);
                playerData.price = int.Parse(row[1]);
                playerData.production_p = int.Parse(row[2]);

                playerDataList.Add(playerData);
            }
        }
        else
        {
            Debug.LogError("Cannot find file!");
        }
    }


    [HideInInspector]

    public int level = 1;


    public void OnButtonClick()
    {
        if(playerDataList.Count > 0 && DataController.GetInstance().GetGold()>=currentCost)
        {
            DataController.GetInstance().SubGold(currentCost);

            level = playerDataList[0].level;
            currentCost = playerDataList[0].price;
            goldByUpgrade = playerDataList[0].production_p;

            playerDataList.RemoveAt(0);
            
            UpdateUI();
            DataController.GetInstance().SaveUpgradeBotton(this);

        }
    }

    public void UpdateUI()
    {
        upgradeDisplayer.text = upgradeName + "\nCost: " + currentCost + "\nLevel: " + level + "\nNext New GoldPerClick: " + goldByUpgrade;
    }
}


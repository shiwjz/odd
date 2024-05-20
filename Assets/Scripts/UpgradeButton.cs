using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;

public class UpgradeButton : MonoBehaviour
{
    private DataController dataController;

    public string upgradeName;
    public int level;
    public int goldByUpgrade;
    public int startGoldByUpgrade = 1;
    public int currentCost;
    public int startCurrentCost = 1;

    //public int level = 1;
    public float upgradePow = 1.07f;
    public float costPow = 3.14f;

    public TMP_Text infoText;
    public TMP_Text upgradeDisplayer;

    private string[] dataRows;

    void Start()
    {
        PlayerPrefs.DeleteAll();
        DataController.GetInstance().LoadUpgradeButton(this);
        UpdateUI();
    }

    void Awake()
    {
        dataController = DataController.GetInstance();
        LoadGameData();
        LoadUpgradeButton();
        UpdateUI();
    }

    void LoadGameData()
    {
        TextAsset data = Resources.Load<TextAsset>("PlayerDB");

        if (data != null)
        {
            dataRows = data.text.Split('\n');

            
            if (dataRows.Length > 1)
            {
                dataRows = dataRows.Skip(1).ToArray();
                UpdateUpgradeData();
            }
        }
        else
        {
            Debug.LogError("Cannot find game data!");
        }
    }

    public void PurchaseUpgrade()
    {
        if (DataController.GetInstance().GetGold() >= currentCost)
        {
            DataController.GetInstance().SubGold(currentCost);
            level++;
            DataController.GetInstance().AddGoldPerClick(goldByUpgrade);
            UpdateUpgrade();
            UpdateUI();
            DataController.GetInstance().SaveUpgradeBotton(this);
        }

    }

    public void OnClick()
    {
        int currentCurrency = dataController.GetGold();

        if (currentCurrency >= currentCost)
        {
            dataController.AddGold(-currentCost);
           
            if (level < dataRows.Length-1)
            {
                level++;
                UpdateUpgradeData();
                dataController.SetGoldPerClick(goldByUpgrade);
                SaveUpgradeButton();
                
            }
            UpdateUI();
        }
    }

    void UpdateUpgradeData()
    {
        string[] row = dataRows[level].Split(',');

        if (!int.TryParse(row[0], out goldByUpgrade))
        {
            Debug.LogError("Failed to parse goldByUpgrade: " + row[0]);
        }

        if (!int.TryParse(row[1], out currentCost))
        {
            Debug.LogError("Failed to parse currentCost: " + row[1]);
        }
    }

    public void UpdateUpgrade()
    {
        goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow(upgradePow, level);
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
    }

    public void LoadUpgradeButton()
    {
        level = PlayerPrefs.GetInt(upgradeName + "_level", 1);
    }

    public void SaveUpgradeButton()
    {
        PlayerPrefs.SetInt(upgradeName + "_level", level);
    }

    public void UpdateUI()
    {
        infoText.text = "Level: " + (level+1).ToString() + "\n" +
                        "Price: " + currentCost.ToString() + "\n" +
                        "Production: " + goldByUpgrade.ToString();

        upgradeDisplayer.text = upgradeName + "\nCost: " + currentCost + "\nLevel: " + level + "\nNext New GoldPerClick: " + goldByUpgrade;
    }

    public void ResetUpgradeButton()
    {
        level = 0;
        LoadGameData();
        UpdateUI();
    }
}
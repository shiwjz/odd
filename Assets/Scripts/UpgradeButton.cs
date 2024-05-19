using UnityEngine;
using TMPro;
using System.IO;
using System.Linq;

public class UpgradeButton : MonoBehaviour
{
    private DataController dataController;

    public string upgradeName;
    public int level;
    public int goldByUpgrade;
    public int currentCost;

    public TMP_Text LevelText;
    public TMP_Text PriceText;

    private string[] dataRows;

    void Awake()
    {
        dataController = DataController.GetInstance();
        LoadGameData();
        LoadUpgradeButton();

        if (level == 0 && goldByUpgrade == 0 && currentCost == 0)
        {
            
            level = 1;
            LoadGameData();
        }

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

    public void OnClick()
    {
        int currentCurrency = dataController.GetGold();

        if (currentCurrency >= currentCost)
        {
            dataController.AddGold(-currentCost);

            if (level < dataRows.Length - 1)
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
    public void LoadUpgradeButton()
    {
        level = PlayerPrefs.GetInt(upgradeName + "_level", 1);
        goldByUpgrade = PlayerPrefs.GetInt(upgradeName + "_goldByUpgrade", 0);
        currentCost = PlayerPrefs.GetInt(upgradeName + "_currentCost", 0);
    }

    public void SaveUpgradeButton()
    {
        PlayerPrefs.SetInt(upgradeName + "_level", level);
        PlayerPrefs.SetInt(upgradeName + "_goldByUpgrade", goldByUpgrade);
        PlayerPrefs.SetInt(upgradeName + "_currentCost", currentCost);
    }

    public void UpdateUI()
    {
        LevelText.text = "레벨 : " + (level + 1).ToString();
        PriceText.text = "필요 인기도 : " + currentCost.ToString() + "\n" + "Level UP";

    }

    

    public void ResetUpgradeButton()
    {
        level = 0;
        LoadGameData();
        UpdateUI();
    }
}
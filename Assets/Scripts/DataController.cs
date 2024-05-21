using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    

    private static DataController instance;
    public static DataController GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<DataController>();
            if (instance == null)
            {
                GameObject container = new GameObject("DataController");
                instance = container.AddComponent<DataController>();
            }
        }
        return instance;
    }
    private ItemButton[] ItemButtons;

    private int m_gold = 0;
    private int m_goldPerClick = 1;
    private int m_goldPerSec = 0;

    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        m_gold = PlayerPrefs.GetInt("Gold");
        m_goldPerClick = PlayerPrefs.GetInt("GoldPerClick", 1);
        m_goldPerSec = PlayerPrefs.GetInt("GoldPerSec", 0);
        ItemButtons = FindObjectsOfType<ItemButton>();
    }


    public void SetGold(int newGold)
    {
        m_gold = newGold;
        PlayerPrefs.SetInt("Gold", m_gold);
    }

    public void AddGold(int newGold)
    {
        m_gold += newGold;
        PlayerPrefs.SetInt("Gold", m_gold);
    }

    public void SubGold(int newGold)
    {
        m_gold -= newGold;
        SetGold(m_gold);
    }

    public int GetGold()
    {
        return m_gold;
    }

    public int GetGoldPerClick()
    {
        return m_goldPerClick;
    }

    public void AddGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick += newGoldPerClick;
        SetGoldPerClick(m_goldPerClick);
    }

    public void LoadUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;

        upgradeButton.level = PlayerPrefs.GetInt(key + "_level", 1);
        upgradeButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade",
        upgradeButton.startGoldByUpgrade);
        upgradeButton.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradeButton.startCurrentCost);
    }

    public void SaveUpgradeBotton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;

        PlayerPrefs.SetInt(key + "_level", upgradeButton.level);
        PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradeButton.goldByUpgrade);
        PlayerPrefs.SetInt(key + "_cost", upgradeButton.currentCost);
    }

    public void LoadItemButton(ItemButton itemButton)
    {
        string key = itemButton.itemName;

        itemButton.level = PlayerPrefs.GetInt(key + "_level");
        itemButton.currentCost = PlayerPrefs.GetInt(key + "_cost", itemButton.startCurrentCost);

        itemButton.goldPerSec = PlayerPrefs.GetInt(key + "_goldPerSec");
        if (PlayerPrefs.GetInt(key + "_isPurchased") == 1)
        {
            itemButton.isPurchased = true;
        }
        else
        {
            itemButton.isPurchased = false;
        }
    }

    public void SaveItemButton(ItemButton itemButton)
    {
        string key = itemButton.itemName;
        PlayerPrefs.SetInt(key + "_level", itemButton.level);
        PlayerPrefs.SetInt(key + "_cost", itemButton.currentCost);
        PlayerPrefs.SetInt(key + "_goldPerSec", itemButton.goldPerSec);

        if (itemButton.isPurchased == true)
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 1);

        }
        else
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 0);
        }
    }

    public void LoadGiftButton(GiftButton giftButton)
    {
        string key = giftButton.itemName;

        //giftButton.level = PlayerPrefs.GetInt(key + "_level");
        giftButton.currentCost = PlayerPrefs.GetInt(key + "_cost", giftButton.currentCost);

        //giftButton.goldPerSec = PlayerPrefs.GetInt(key + "_goldPerSec");
        if (PlayerPrefs.GetInt(key + "_isPurchased") == 1)
        {
            giftButton.isPurchased = true;
        }
        else
        {
            giftButton.isPurchased = false;
        }
    }
    public void SaveGiftButton(GiftButton giftButton)
    {
        string key = giftButton.itemName;
        //PlayerPrefs.SetInt(key + "_level", itemButton.level);
        PlayerPrefs.SetInt(key + "_cost", giftButton.currentCost);
        //PlayerPrefs.SetInt(key + "_goldPerSec", itemButton.goldPerSec);

        if (giftButton.isPurchased == true)
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 1);

        }
        else
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 0);
        }
    }

    public int GetGoldPerSec()
    {
        int goldPerSec = 0;
        for (int i = 0; i < ItemButtons.Length; i++)
        {
            goldPerSec += ItemButtons[i].goldPerSec;
        }
        return goldPerSec;
    }
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        m_gold = 0;
        m_goldPerClick = 1;

        foreach (var upgradeButton in FindObjectsOfType<UpgradeButton>())
        {
            upgradeButton.ResetUpgradeButton();
        }
    }

    public void UpdateAllUpgradeButtons()
    {
        
        foreach (var upgradeButton in FindObjectsOfType<UpgradeButton>())
        {
            upgradeButton.UpdateUI();
        }
    }

    
    public void SetGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick = newGoldPerClick;
        PlayerPrefs.SetInt("GoldPerClick", m_goldPerClick);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;
using Unity.VisualScripting;

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

    //public float costPow = 3.14f;

    //[HideInInspector]

    //public float upgradePow = 1.07f;
    
    public bool isPurchased = false;

    public string FileName;

    private string[] dataRows;

    public Sprite Profile;

    private GameObject PopupPanel;

    Image PopupImage;

    TMP_Text TitleText;

    TMP_Text GameContentText;

    private TMP_Text DetailText;

    public GiftButton GiftData;

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
            FriendPopup();
            isPurchased = true;
            level++;

            GiftData.GetComponent<GiftButton>().UpdateUI();
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
        itemDisplayer.text = "초 당 인기도: " + goldPerSec + "\n레벨: " + level;
        PurchaseDisplayer.text = "가격: " + currentCost;

    }

    public void FriendPopup()
    {
        if (!isPurchased)
        {
            PopupPanel = GameObject.Find("Canvas").transform.Find("Popup").gameObject;
            PopupImage = PopupPanel.transform.Find("Image").GetComponent<Image>();
            DetailText = PopupPanel.transform.Find("DetailText").GetComponent<TMP_Text>();
            TitleText = PopupPanel.transform.Find("TitleText").GetComponent<TMP_Text>();
            GameContentText = PopupPanel.transform.Find("GameContentText").GetComponent<TMP_Text>();

            PopupPanel.SetActive(true);
            PopupImage.sprite = Profile;
            TitleText.text = "새로운 친구!";
        }
    }
    private void OnApplicationQuit()
    {
        DataController.GetInstance().SaveItemButton(this);
    }
}

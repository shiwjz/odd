using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class GiftButton : MonoBehaviour
{
    public AudioSource btnsource;

    public TMP_Text itemDisplayer;

    public TMP_Text PurchaseDisplayer;

    public TMP_Text itemNameDisplayer;

    public string itemName;

    public int currentCost;

    public bool isPurchased = false;

    public ItemButton FriendData;

    public Sprite Profile;

    private GameObject PopupPanel;

    Image PopupImage;

    TMP_Text TitleText;

    TMP_Text GameContentText;

    private TMP_Text DetailText;

    void Awake()
    {
        DataController.GetInstance().LoadGiftButton(this);
        UpdateItem();
        UpdateUI();
        //StartCoroutine("AddGoldLoop");
    }
    private void OnEnable()
    {
        UpdateUI();
    }
    public void UpdateItem()
    {

    }

    public void PurchaseItem()
    {
        if (DataController.GetInstance().GetGold() >= currentCost)
        {
            btnsource.Play();
            FriendPopup();
            isPurchased = true;

            DataController.GetInstance().SubGold(currentCost);
            UpdateItem();
            UpdateUI();
            DataController.GetInstance().SaveGiftButton(this);

        }
    }
    public void UpdateUI()
    {
        //itemDisplayer.text = "Gold Per Sec: " + goldPerSec + "\nLv: " + level;
        if (!FriendData.isPurchased)
        {
            PurchaseDisplayer.text = "준비 중";
            PurchaseDisplayer.GetComponentInParent<Button>().interactable = false;
        }
        else
        {
            if(isPurchased)
            {
                PurchaseDisplayer.text = "보유 중";
                PurchaseDisplayer.GetComponentInParent<Button>().interactable = false;
            }
            else
            {
                PurchaseDisplayer.GetComponentInParent<Button>().interactable = true;
                PurchaseDisplayer.text = "가격: " + currentCost;
            }
        }
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
            TitleText.text = "베스트 프렌드!";
        }
    }

    private void OnApplicationQuit()
    {
        DataController.GetInstance().SaveGiftButton(this);
        Application.Quit();
    }
}

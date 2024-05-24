using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhotoData : MonoBehaviour
{
    public AudioSource btnsource;

    public TMP_Text itemDisplayer;

    public TMP_Text PurchaseDisplayer;

    public TMP_Text itemNameDisplayer;

    public string itemName;

    public int currentCost;

    public bool isPurchased = false;

    private GiftButton[] giftButtons;

    public Image ProfileDisplayer;

    public Sprite Profile;

    private GameObject PopupPanel;

    public string ScriptText;

    Image PopupImage;

    TMP_Text TitleText;

    TMP_Text GameContentText;

    private TMP_Text DetailText;

    public GameObject FriendImage;

    public GameObject PhotoPoster;

    void Awake()
    {    
        giftButtons = FindObjectsOfType<GiftButton>();
        LoadData();
        UpdateUI();

        //StartCoroutine("AddGoldLoop");
    }
    private void OnEnable()
    {
        UpdateUI();
    }

    public void PurchaseItem()
    {
        if (DataController.GetInstance().GetGold() >= currentCost)
        {
            btnsource.Play();
            FriendPopup();
            isPurchased = true;

            DataController.GetInstance().SubGold(currentCost);
            PhotoPoster.SetActive(true);
            UpdateUI();
            SaveData();
        }
    }
    public void UpdateUI()
    {
        itemDisplayer.text = "...";
        //itemDisplayer.text = "Gold Per Sec: " + goldPerSec + "\nLv: " + level;
        for(int i = 0; i< giftButtons.Length; i++)
        {
            if (!giftButtons[i].isPurchased)
            {
                PurchaseDisplayer.text = "준비 중";
                PurchaseDisplayer.GetComponentInParent<Button>().interactable = false;
            }
            else
            {
                if(isPurchased)
                {
                    itemDisplayer.text = "";
                    PurchaseDisplayer.text = "보유 중";
                    ProfileDisplayer.sprite = Profile;
                    PurchaseDisplayer.GetComponentInParent<Button>().interactable = false;
                }
                else
                {
                    PurchaseDisplayer.GetComponentInParent<Button>().interactable = true;
                    PurchaseDisplayer.text = "  " + currentCost;
                }
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
            TitleText.text = "";
            DetailText.text = ScriptText;
            GameContentText.text = "";
        }
    }

    public void ResetGift()
    {
        isPurchased = false;
        UpdateUI();
    }

    private void SaveData()
    {
        if (isPurchased)
        {
            PlayerPrefs.SetInt("Photo_isPurchased", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Photo_isPurchased", 0);
        }
    }
    private void LoadData()
    {
        if (PlayerPrefs.GetInt("Photo_isPurchased") == 1)
        {
            isPurchased=true;
        }
        else
        {
            isPurchased = false;
        }
    }
    private void OnApplicationQuit()
    {
        SaveData();
    }
}

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

    public Image ProfileDisplayer;

    public Sprite Profile;

    private GameObject PopupPanel;

    public string ScriptText;

    public string FriendName;

    Image PopupImage;

    TMP_Text TitleText;

    TMP_Text GameContentText;

    private TMP_Text DetailText;

    public GameObject FriendImage;

    void Awake()
    {
        DataController.GetInstance().LoadGiftButton(this);
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
            UpdateUI();
            DataController.GetInstance().SaveGiftButton(this);
        }
    }
    public void UpdateUI()
    {
        itemDisplayer.text = "누군가에게 필요해 보이는 물건, 대체 어디에 사용할 생각인 걸까?";
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
                itemDisplayer.text = FriendName + "/초 +50%!";
                PurchaseDisplayer.text = "보유 중";
                ProfileDisplayer.sprite = Profile;
                PurchaseDisplayer.GetComponentInParent<Button>().interactable = false;
            }
            else
            {
                PurchaseDisplayer.GetComponentInParent<Button>().interactable = true;
                PurchaseDisplayer.text = "" + currentCost;
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
            TitleText.text = "Best Friend!";
            DetailText.text = ScriptText;
            GameContentText.text = FriendName + "/초 +50%!";
        }
    }

    public void ResetGift()
    {
        isPurchased = false;
        UpdateUI();
    }

    private void OnApplicationQuit()
    {
        DataController.GetInstance().SaveGiftButton(this);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public TMP_Text goldDisplayer;
    public TMP_Text goldPerClickDisplayer;
    public TMP_Text goldPerSecDisplayer;
    public DataController dataController;
    void Update()
    {
        goldDisplayer.text = "GOLD: " + DataController.GetInstance().GetGold();
        goldPerClickDisplayer.text = "GOLD PER CLICK: " + DataController.GetInstance().GetGoldPerClick();
        //goldPerSecDisplayer.text = "GOLD PER SEC: " + DataController.GetInstance().GetGoldPerSec();
        //goldPerSecDisplayer.text = "GOLD PER SEC: " + PlayerPrefs.GetInt("GoldPerSec");

    }
}

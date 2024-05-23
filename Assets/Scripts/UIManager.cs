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
        goldDisplayer.text = " " + DataController.GetInstance().GetGold();
        goldPerClickDisplayer.text = DataController.GetInstance().GetGoldPerClick() + "       /탭";
       // goldPerSecDisplayer.text = "초당 인기도 : " + DataController.GetInstance().GetGoldPerSec();
        goldPerSecDisplayer.text = PlayerPrefs.GetInt("GoldPerSec") + "       /초";

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public TMP_Text goldDisplayer;
    public TMP_Text goldPerClickDisplayer;
    public DataController dataController;
    void Update()
    {
        goldDisplayer.text = "GOLD: " + dataController.GetGold();
        goldPerClickDisplayer.text = "GOLD PER CLICK: " + dataController.GetGoldPerClick();
    }
}

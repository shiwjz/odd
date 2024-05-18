using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopUiManager : MonoBehaviour
{
    public TMP_Text CurrentPerSecDisplayer;

    public TMP_Text CurrentGoldDisplayer;

    void Update()
    {
        CurrentPerSecDisplayer.text = "GoldPerSec:" + DataController.GetInstance().GetGoldPerSec();
        CurrentGoldDisplayer.text = "Gold:" + DataController.GetInstance().GetGold();
    }
}

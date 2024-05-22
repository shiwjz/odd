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
        CurrentPerSecDisplayer.text = "�� �� �α⵵:" + DataController.GetInstance().GetGoldPerSec();
        CurrentGoldDisplayer.text = "Gold:" + DataController.GetInstance().GetGold();
    }
}

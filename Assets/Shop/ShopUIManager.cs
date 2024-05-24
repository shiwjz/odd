using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopUiManager : MonoBehaviour
{
    public TMP_Text CurrentPerSecDisplayer;
    void Update()
    {
        CurrentPerSecDisplayer.text = DataController.GetInstance().GetGoldPerSec() + " /√ ";
    }
}

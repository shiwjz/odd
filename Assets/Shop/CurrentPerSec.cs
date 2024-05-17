using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentPerSec : MonoBehaviour
{
    public TMP_Text CurrentPerSecDisplayer;

    void Update()
    {
        CurrentPerSecDisplayer.text = "GoldPerSec :" + DataController.GetInstance().GetGoldPerSec();
    }
}

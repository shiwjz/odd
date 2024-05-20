using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    private DataController dataController;

    void Start()
    {
        dataController = DataController.GetInstance();
    }

    public void OnClick()
    {
       // dataController.ResetData();
        dataController.UpdateAllUpgradeButtons();  
    }
}

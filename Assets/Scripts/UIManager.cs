using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text goldDisplayer;
    public TMP_Text goldPerClickDisplayer;
    public TMP_Text goldPerSecDisplayer;

    private DataController dataController;

    void Start()
    {
        dataController = DataController.GetInstance();
    }

    void Update()
    {
        goldDisplayer.text = "GOLD: " + dataController.GetGold();
        goldPerClickDisplayer.text = "GOLD PER CLICK: " + dataController.GetGoldPerClick();
        dataController.UpdateAllUpgradeButtons();
    }
}
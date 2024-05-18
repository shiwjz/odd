using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectExitShop : MonoBehaviour
{
    public void Exit()
    {
        PlayerPrefs.SetInt("GoldPerSec", DataController.GetInstance().GetGoldPerSec());
        SceneManager.LoadScene("Menu");
    }
}

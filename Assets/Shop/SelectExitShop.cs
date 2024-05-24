using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectExitShop : MonoBehaviour
{
    public AudioSource etcsource;
    public void Exit()
    {
        etcsource.Play();
        PlayerPrefs.SetInt("GoldPerSec",DataController.GetInstance().GetGoldPerSec());
        GameObject.Find("Shop").SetActive(false);
    }
}

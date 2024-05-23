using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("Shop").SetActive(false);
        GameObject.Find("Popup").SetActive(false);
        GameObject.Find("Setting").SetActive(false);
    }

}

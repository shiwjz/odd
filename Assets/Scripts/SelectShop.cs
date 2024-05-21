using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectShop : MonoBehaviour
{
    public void IntoShop()
    {
        PlayerPrefs.DeleteAll();
        GameObject.Find("Canvas").transform.Find("Shop").gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectShop : MonoBehaviour
{
    public AudioSource etcsource;
    public void IntoShop()
    {
        etcsource.Play();
        GameObject.Find("Canvas").transform.Find("Shop").gameObject.SetActive(true);
    }
}

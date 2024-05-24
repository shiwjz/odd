using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePopup : MonoBehaviour
{
    public AudioSource etcsource;
    public void CloseButton()
    {
        etcsource.Play();
        gameObject.SetActive(false);
    }
}

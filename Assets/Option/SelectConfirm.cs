using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectConfirm : MonoBehaviour

{
    public AudioSource musicsource;
    public AudioSource btsource;
    public void Confirm()
    {
        PlayerPrefs.SetFloat("MusicVoulume", musicsource.volume);
        PlayerPrefs.SetFloat("sfxVoulme", btsource.volume);
        SceneManager.LoadScene("Menu");
    }
}

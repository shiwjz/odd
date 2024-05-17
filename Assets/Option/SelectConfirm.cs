using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectConfirm : MonoBehaviour

{
    public AudioSource musicsource;

    public AudioSource btnsource;
    public void Confirm()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicsource.volume);
        PlayerPrefs.SetFloat("SfxVolume", btnsource.volume);
        SceneManager.LoadScene("SampleScene");
    }
}

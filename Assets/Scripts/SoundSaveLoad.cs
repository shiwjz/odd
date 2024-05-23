using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLoad : MonoBehaviour
{
    public AudioSource musicsource;

    public AudioSource btnsource;

    private void Awake()
    {
        musicsource.volume = PlayerPrefs.GetFloat("MusicVolume",1);
        btnsource.volume = PlayerPrefs.GetFloat("SfxVolume",1);
    }

    public void SoundSave()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicsource.volume);
        PlayerPrefs.SetFloat("SfxVolume", btnsource.volume);
    }

    private void OnApplicationQuit()
    {
        SoundSave();
    }
}

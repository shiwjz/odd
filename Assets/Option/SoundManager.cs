using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicsource;

    public AudioSource btnsource;

    public void SetMusicVolume(float volume)
    {
        musicsource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume",musicsource.volume);
    }

    public void SetButtonVolume(float volume)
    {
        btnsource.volume = volume;
        PlayerPrefs.SetFloat("SfxVolume", btnsource.volume);
    }
    public void OnSfx()
    {
        btnsource.Play();
    }
}

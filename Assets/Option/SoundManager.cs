using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicsource;

    public AudioSource btnsource;

    public AudioSource tapsource;

    public AudioSource etcsource;

    public AudioSource feversource;


    private void Awake()
    {
        GameObject.Find("MusicSlider").GetComponent<Slider>().value = musicsource.volume;
        GameObject.Find("SfxSlider").GetComponent<Slider>().value = btnsource.volume;

    }
    public void SetMusicVolume(float volume)
    {
        musicsource.volume = volume;
        feversource.volume = volume;
    }

    public void SetButtonVolume(float volume)
    {
        btnsource.volume = volume;
        tapsource.volume = volume;
        etcsource.volume = volume;

    }
    public void OnSfx()
    {
        btnsource.Play();
    }
    public void Confirm()
    {
        etcsource.Play();
        PlayerPrefs.SetFloat("MusicVolume", musicsource.volume);
        PlayerPrefs.SetFloat("SfxVolume", btnsource.volume);
        GameObject.Find("Setting").SetActive(false);
    }
}

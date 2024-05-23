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

    private void Awake()
    {
        GameObject.Find("MusicSlider").GetComponent<Slider>().value = musicsource.volume;
        GameObject.Find("SfxSlider").GetComponent<Slider>().value = btnsource.volume;

    }
    public void SetMusicVolume(float volume)
    {
        musicsource.volume = volume;
    }

    public void SetButtonVolume(float volume)
    {
        btnsource.volume = volume;
    }
    public void OnSfx()
    {
        btnsource.Play();
    }
    public void Confirm()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicsource.volume);
        PlayerPrefs.SetFloat("SfxVolume", btnsource.volume);
        GameObject.Find("Setting").SetActive(false);
    }
}

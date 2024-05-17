using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLoad : MonoBehaviour
{
    public AudioSource musicsource;

    public AudioSource btnsource;

    void Update()
    {
        musicsource.volume = PlayerPrefs.GetFloat("MusicVolume");
        btnsource.volume = PlayerPrefs.GetFloat("SfxVolume");
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SliderLoad : MonoBehaviour
{
    public AudioSource AudioSource;

    public Slider AudioSlider;

    private void Update()
    {
        AudioSlider.value = AudioSource.volume;
    }
}

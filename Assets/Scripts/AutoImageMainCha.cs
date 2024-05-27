using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoImageMainCha : MonoBehaviour
{
    private GameObject AfterImage;
    void Start()
    {
        AfterImage = transform.GetChild(0).gameObject;
        StartCoroutine(AutoImage());
    }

    private IEnumerator AutoImage()
    {
        while (true)
        {
            AfterImage.SetActive(false);
            yield return new WaitForSeconds(5f);
            AfterImage.SetActive(true);
            yield return new WaitForSeconds(1f);
        }



    }

}

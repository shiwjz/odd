using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoImageMainCha : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("AutoChangeImage");
    }

    private IEnumerator AutoChangeImage()
    {
        while (true)
        {
            gameObject.SetActive(false);
            yield return new WaitForSeconds(5.0f);
            gameObject.SetActive(true);
            yield return new WaitForSeconds(5.0f);
        }



    }

}

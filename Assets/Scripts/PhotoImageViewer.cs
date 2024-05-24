using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoImageViewer : MonoBehaviour
{
    public PhotoData photoData;
    void Start()
    {
        gameObject.SetActive(photoData.isPurchased);
    }
}

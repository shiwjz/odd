using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendImageViewer : MonoBehaviour
{
    public ItemButton FriendData;
    void Start()
    {
        gameObject.SetActive(FriendData.isPurchased);
    }

}

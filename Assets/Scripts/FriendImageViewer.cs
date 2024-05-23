using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendImageViewer : MonoBehaviour
{
    public ItemButton FriendData;

    public GiftButton GiftData;
    void Start()
    {
        gameObject.SetActive(FriendData.isPurchased);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    
    public string itemName;
    public int level;
    [HideInInspector]
    public int currentCost;
    public int startCurrentCost = 1;
    [HideInInspector]
    public int goldPerSec;
    public int startGoldPerSec = 1;
    public float costPow = 3.14f;
    public float upgradePow = 1.07f;
    [HideInInspector]
    public bool isPurchased = false;
    public void PurchaseItem()
    {
        
    }


}

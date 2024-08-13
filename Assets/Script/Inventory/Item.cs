using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Cheese,
    Mouse,
    Key,
    Etc
}
[System.Serializable]
public class Item
{
    public ItemType itemType;
    public string itemName;
    public GameObject itemObject;
    public Sprite itemImage;
    
    public bool Use()
    {
        return false;
    }
}

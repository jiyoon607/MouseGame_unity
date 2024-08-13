using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    public Item item;

    void OnMouseDown()
    {
        //item.itemObject = gameObject;
        if(Inventory.InputInventory(item))
            DestroyItem();
    }
    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}

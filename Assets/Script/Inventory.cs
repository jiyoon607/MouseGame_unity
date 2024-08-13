using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject exO;
    public GameObject exI;
    static public List<Item> inventoryList;
    static public GameObject inventoryUI;
    
    static public Slot[] slots;
    public Transform slotHolder;

    // Start is called before the first frame update
    void Start()
    {
        slots = new Slot[15];
        inventoryList = new List<Item>();
        inventoryUI = GameObject.FindWithTag("InventoryUI");
        slots = slotHolder.GetComponentsInChildren<Slot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public bool InputInventory(Item item)
    {
        if(inventoryList.Count >12)
        {
            Debug.Log("Inventory Full");
            return false;
        }
        inventoryList.Add(item);
        //이미지를 UI에 적용
        slots[inventoryList.Count-1].item = item;
        slots[inventoryList.Count-1].UpdateSlotUI();
        return true;
    }

    static public bool OutputInventory(Item item)
    {
        if(inventoryList.Count < 0)
        {
            Debug.Log("Inventory Empty");
            return false;
        }

        inventoryList.Remove(item);
        RedrawSlotUI();
        return true;
    }

    /*public Sprite Obj_To_Img(Item item)
    {
        for(int i=0; i<ItemDataBase.itemDB.Count; i++)
        {
            if(ItemDataBase.itemDB[i].itemName == itemName)
            {
                return ItemDataBase.itemDB[i].itemImage;
            } 
        }
        return null;
    }
    public GameObject Img_To_Obj(string itemName)
    {
        for(int i=0; i<ItemDataBase.itemDB.Count; i++)
        {
            if(ItemDataBase.itemDB[i].itemName == itemName)
            {
                return ItemDataBase.itemDB[i].itemObject;
            } 
        }
        return null;
    }*/

    static public void RedrawSlotUI()
    {
        for(int i=0; i<slots.Length; i++)
        {
            slots[i].RemoveSlot();
        }
        for(int i=0; i<inventoryList.Count; i++)
        {
            slots[i].item = inventoryList[i];
            slots[i].UpdateSlotUI();
        }
    }
}

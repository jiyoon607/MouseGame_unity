using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickIcon : MonoBehaviour
{
    GameObject Player;
    public GameObject Observe_Panel;
    bool isObserveOn = false;
    Item item;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    public void ClickPut_button()
    {
        item = this.transform.GetComponentInParent<Slot>().item;
        GameObject newObj = null;
        if(Player.transform.eulerAngles == new Vector3(0.0f,90.0f,0.0f))
        {
            newObj = Instantiate(item.itemObject, new Vector3(Player.transform.position.x+0.7f, 2.0f, Player.transform.position.z+0.0f), Quaternion.identity);
        }
        else if(Player.transform.eulerAngles == new Vector3(0.0f,180.0f,0.0f))
        {
            newObj = Instantiate(item.itemObject, new Vector3(Player.transform.position.x+0.0f, 2.0f, Player.transform.position.z-0.7f), Quaternion.identity);
        }
        else if(Player.transform.eulerAngles == new Vector3(0.0f,270.0f,0.0f))
        {
            newObj = Instantiate(item.itemObject, new Vector3(Player.transform.position.x-0.7f, 2.0f, Player.transform.position.z+0.0f), Quaternion.identity);
        }
        else if(Player.transform.eulerAngles == new Vector3(0.0f,0.0f,0.0f))
        {
            newObj = Instantiate(item.itemObject, new Vector3(Player.transform.position.x+.0f, 2.0f,Player.transform.position.z+0.7f), Quaternion.identity);
        }
        newObj.GetComponent<ClickObject>().item = item;
        bool InputCheck = Inventory.OutputInventory(item);
        if(InputCheck == true)
        {
            gameObject.SetActive(false);
        }
        if(isObserveOn == true)
        {
            Observe_Panel.SetActive(false);
            isObserveOn = false;
        }
    }
    public void ClickCancel_button()
    {
        gameObject.SetActive(false);
        if(isObserveOn == true)
        {
            Observe_Panel.SetActive(false);
            isObserveOn = false;
        }
    }
    public void ClickObserve_button()
    {
        item = this.transform.GetComponentInParent<Slot>().item;
        Observe_Panel.transform.GetComponent<Image>().sprite = item.itemImage;
        if(isObserveOn == false)
        {
            Observe_Panel.SetActive(true);
            isObserveOn = true;
        }
        else
        {
            Observe_Panel.SetActive(false);
            isObserveOn = false;
        }
    }
     
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject Explain_Panel;
    public GameObject Pause_Panel;
    public GameObject Observe_Panel;
    public Sprite[] Explain_Text;
    Animator UIanimator;
    int Explain_page;
    private bool Inventory_Panel_bool = false;
    // Start is called before the first frame update
    void Start()
    {
        UIanimator = Inventory.GetComponent<Animator>();
        Explain_page = 1;
    }

    public void Inventory_Button()
    {
        if(Inventory_Panel_bool == false)
        {
            UIanimator.SetBool("Inventory_In",true);
            Inventory_Panel_bool = true;
        }

        else if(Inventory_Panel_bool == true)
        {
            UIanimator.SetBool("Inventory_In",false);
            Inventory_Panel_bool = false;
        }
        if(Observe_Panel.activeSelf==true)
        {
            Observe_Panel.SetActive(false);
        }
    }
    public void Explain_Next_Button()
    {
        if(Explain_page == 1)
        {
            Explain_Panel.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Explain_Text[1];
            Explain_Panel.transform.GetChild(2).gameObject.SetActive(true); //back button
            Explain_page++; 
        }
        else if(Explain_page == 2)
        {
            Explain_Panel.SetActive(false);
            Explain_page++;
        }
    }
    public void Explain_Back_Button()
    {
        Explain_Panel.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Explain_Text[0];
        Explain_Panel.transform.GetChild(2).gameObject.SetActive(false);  //back button
        Explain_page--;
    }
    public void Pause_Button()
    {
        if(Pause_Panel.activeSelf == false)
        {
            Pause_Panel.SetActive(true);
        }
        else if(Pause_Panel.activeSelf == true)
        {
            Pause_Panel.SetActive(false);
        }
    }
    public void Home_Button()
    {
        SceneManager.LoadScene("Title");
    }
    public void Retry_Button()
    {
        SceneManager.LoadScene("1stLevel");
    }
}

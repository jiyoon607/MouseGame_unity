using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeView : MonoBehaviour
{
    public GameObject kitchen_Cam;
    public GameObject MouseHole_Cam;
    public GameObject Ekey_UI;
    static public bool isMove = true;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<=-2.5 && transform.position.x>=-3.7 && transform.position.z >= 3.3 && transform.position.z <= 3.4 && transform.rotation == Quaternion.Euler(new Vector3(0,180,0)))
        {
            Ekey_UI.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(kitchen_Cam.activeSelf == false)
                {
                    kitchen_Cam.SetActive(true);
                    isMove = false;
                }
                else if(kitchen_Cam.activeSelf == true)
                {
                    kitchen_Cam.SetActive(false);
                    isMove = true;
                }
            }
        }
        else if(transform.position.x<=0.58 && transform.position.x>=0.20 && transform.position.z >= -5.00 && transform.position.z <= -4.00 && transform.rotation == Quaternion.Euler(new Vector3(0,90,0)))
        {
            Ekey_UI.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(MouseHole_Cam.activeSelf == false)
                {
                    MouseHole_Cam.SetActive(true);
                    isMove = false;
                }
                else if(MouseHole_Cam.activeSelf == true)
                {
                    MouseHole_Cam.SetActive(false);
                    isMove = true;
                }
            }
        }
        else{
            Ekey_UI.SetActive(false);
        }
    }
}

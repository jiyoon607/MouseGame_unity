using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHole : MonoBehaviour
{
    public GameObject Mouse;
    Animator MouseAnimator;

    // Start is called before the first frame update
    void Start()
    {
        MouseAnimator = Mouse.GetComponent<Animator>();
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {   
        if(other.name == "Cheese(Clone)")
        {
            MouseAnimator.SetBool("Mouse_Out", true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCenser : MonoBehaviour
{   
    public GameObject Mouse;
    public GameObject EndingPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "MousePrefab(Clone)")
        {
            EndingPanel.SetActive(true);
        }
    }
}

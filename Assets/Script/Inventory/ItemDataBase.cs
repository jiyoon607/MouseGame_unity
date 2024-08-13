using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    //다른 클래스에서 접근할 수 있게
    public static ItemDataBase instance;
    private void Awake()
    {
        instance = this;
    }
    static public List<Item> itemDB = new List<Item>();
}

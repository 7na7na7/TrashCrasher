using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashMount : MonoBehaviour
{
    public static int Trash = 0;

    private void Update()
    {
        GetComponent<Text>().text = Trash.ToString() + " KG";
    }
}

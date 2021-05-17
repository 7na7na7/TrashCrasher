using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Trash : MonoBehaviour
{
    public int kilogram;
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        FindObjectOfType<TrashMount>().Trash += kilogram;
            Instantiate(effect, transform.position, quaternion.identity);
    }
}

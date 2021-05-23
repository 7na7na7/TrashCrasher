using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Trash : MonoBehaviour
{
    public float forceX=-0.5f;
    public int kilogram;
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
       
            if(other.gameObject.transform.parent!=null)
                other.gameObject.transform.parent.GetComponent<CarCtrl>().SetForce(forceX,transform.position);
            else
                other.gameObject.GetComponent<CarCtrl>().SetForce(forceX,transform.position);
            TrashMount.Trash += kilogram;
            Instantiate(effect, transform.position, quaternion.identity);
            Destroy(gameObject);
        }
    }
}

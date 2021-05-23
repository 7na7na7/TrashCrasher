using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    private float startDistance = -999;
    public float distance=0;
    private Vector3 crrentpos;
    public float multiplyX;
    // Start is called before the first frame update
    void Start()
    {
        crrentpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (startDistance == -999)
        {
            if (FindObjectOfType<CarCtrl>() != null) 
                startDistance = FindObjectOfType<CarCtrl>().transform.position.x;
        }
        if (transform.position.x <=1655)
        {
            if (FindObjectOfType<CarCtrl>() != null)
            {
                transform.position=new Vector3(crrentpos.x+multiplyX*FindObjectOfType<CarCtrl>().transform.position.x,crrentpos.y);
                distance = FindObjectOfType<CarCtrl>().transform.position.x-startDistance;
            }   
        }
    }
}

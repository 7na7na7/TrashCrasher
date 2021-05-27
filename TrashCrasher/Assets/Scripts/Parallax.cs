using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length, startpos;
    public GameObject cam;
    public float pareallaxeffect;


    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - pareallaxeffect));
        float dist = (cam.transform.position.x * pareallaxeffect);
        transform.position = new Vector2(startpos * dist, transform.position.y);
        
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;

        Debug.Log(temp);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDrain : MonoBehaviour
{
    public float radius = 1f;
    public float speed = 2f;
    void Update()
    { 
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.up, 0,LayerMask.GetMask("Trash"));
        if (hits.Length != 0)
        {
            foreach (RaycastHit2D h in hits)
            {
                Vector2 dir = transform.position - h.collider.transform.position;
                h.collider.GetComponent<Rigidbody2D>().velocity = dir*speed;
            }   
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer== 6)
        {
            Destroy(other.gameObject);
        }
    }
}

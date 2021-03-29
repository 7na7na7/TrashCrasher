using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireScript : MonoBehaviour
{
    public bool isback = true;
    public CarCtrl car;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Respawn"))
        {
            if (isback)
                car.isBack = true;
            else
                car.isFront = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Respawn"))
        {
            if (isback)
                car.isBack = false;
            else
                car.isFront = false;
        }
    }
}

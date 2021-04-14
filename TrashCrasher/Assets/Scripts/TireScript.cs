using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireScript : MonoBehaviour
{
    public bool isback = true;
    public CarCtrl car;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Respawn"))
        {
            if (isback)
                car.isBack = true;
            else
                car.isFront = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Respawn"))
        {
            if (isback)
                car.isBack = false;
            else
                car.isFront = false;
        }
    }
}

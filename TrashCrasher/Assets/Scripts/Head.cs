using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Head : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Respawn"))
      {
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }
   }
}

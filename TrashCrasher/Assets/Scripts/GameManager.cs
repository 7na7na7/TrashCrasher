using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject GameoverPanel;
    public GameObject Car;
    public void StartGame()
    {
        GameoverPanel.SetActive(false);
        Instantiate(Car, transform.position, quaternion.identity);
    }
}

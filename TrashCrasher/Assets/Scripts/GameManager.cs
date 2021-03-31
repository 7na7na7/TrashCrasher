using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private string tireKey = "tireKey";
    public Image tire;
    public Image[] tires;
    private string engineKey = "engineKey";
    public Image engine;
    public Image[] engines;
    private string oilKey = "oilKey";
    public Image oil;
    public Image[] oils;
    private string bumperKey = "bumperKey";
    public Image bumper;
    public Image[] bumpers;
    private string trashPullerKey = "trashPullerKey";
    public Image trashPuller;
    public Image[] trashPullers;
    private string timingBelKey = "timingBeltKey";
    public Image timingBelt;
    public Image[] timingBelts;
    
    
    public GameObject GameOverPannel;
    public GameObject Car;

    private GameObject PlayerCar;

    public static GameManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void StartGame()
    {
        if(PlayerCar)
        {
            Destroy(PlayerCar);
        }

        GameOverPannel.SetActive(false);
        PlayerCar = Instantiate(Car, transform.position, quaternion.identity);
    }

    public void GameOver()
    {
        GameOverPannel.SetActive(true);
    }
}

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
    
    
    public GameObject GameoverPanel;
    public GameObject Car;
    

    public void StartGame()
    {
        GameoverPanel.SetActive(false);
        Instantiate(Car, transform.position, quaternion.identity);
    }

    public void GameOver()
    {
        GameoverPanel.SetActive(true);
    }
}

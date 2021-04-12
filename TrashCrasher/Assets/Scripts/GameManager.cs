using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text goldText;
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

    public Animator UpgradePanelAnimator;
    
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

    private void Update()
    {
        goldText.text = "남은 돈 : " + GoldManager.instance.Gold + " G";

    }

    public void StartGame()
    {
        if(PlayerCar)
        {
            Destroy(PlayerCar);
        }

        UpgradePanelAnimator.SetBool("IsUp", true);
        PlayerCar = Instantiate(Car, transform.position, quaternion.identity);
        
    }

    public void GameOver()
    {
        UpgradePanelAnimator.SetBool("IsUp", false);
    }
}

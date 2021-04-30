using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Spr
{
    public Sprite[] sprs;
}
public class GameManager : MonoBehaviour
{
    public Text[] lvTexts;
    public Text goldText;
    private string tireKey = "0";
     
       private string engineKey = "1";
       private string oilKey = "2";
       private string bumperKey = "3";
       private string trashPullerKey = "4";
       private string timingBelKey = "5";
       public Spr[] sprites;
       private int[] upgradecount=new int[6];
       public Image[] images;
       public void Upgrade(int index)
       {
           if (upgradecount[index] + 1 < sprites[index].sprs.Length)
           {
               upgradecount[index]++;
               PlayerPrefs.SetInt(index.ToString(),upgradecount[index]);
               set();   
           }
       }
       void set()
       {
           for (int i = 0; i < upgradecount.Length; i++)
           {
               upgradecount[i] = PlayerPrefs.GetInt(i.ToString(), 0);
               images[i].sprite = sprites[i].sprs[upgradecount[i]];
               lvTexts[i].text = "Lv "+upgradecount[i]+1;
           }
       }

    public Animator UpgradePanelAnimator;
    
    public GameObject GameOverPannel;
    public GameObject ScorePannel;

    public GameObject Car;

    private GameObject PlayerCar;

    public static GameManager instance = null;

    float trashWeight = 0.0f;
    float moveDistance = 0.0f;

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
        set();
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

        GoldManager.instance.PrevGold = GoldManager.instance.Gold;
    }

    public void GameOver()
    {
        PlayerCar.GetComponent<CarCtrl>().StopMovement();

        UpgradePanelAnimator.SetBool("IsUp", false);
        ScorePannel.SetActive(true);
        GoldManager.instance.CheckScore(trashWeight, moveDistance);
    }

    public void AfterCheckScore()
    {
        ScorePannel.SetActive(false);
    }

}

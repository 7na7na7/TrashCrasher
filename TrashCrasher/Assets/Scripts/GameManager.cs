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
    public Text goldText;

    public GameObject playButton;

    #region
    public Text[] lvTexts;
    public Text[] upgradeCostText;

    public int tireKey = 0;
    public int timingbelt = 1;
    public int oilKey = 2;
    public int bumperKey = 3;
    public int boosterKey = 4;
    public Spr[] sprites;
    public int[] upgradecount = new int[5];
    private int[] upgradeCost = new int[3] {5000, 20000, 50000}; 

    public Image[] images;
    public Image[] carImage;

    public void Upgrade(int index)
    {
        if (upgradecount[index] + 1 < sprites[index].sprs.Length && upgradeCost[upgradecount[index]] < GoldManager.instance.Gold)
        {
            upgradecount[index]++;
            PlayerPrefs.SetInt(index.ToString(), upgradecount[index]);
            set();
        }
    }
    void set()
    {
        for (int i = 0; i < upgradecount.Length; i++)
        {
            upgradecount[i] = PlayerPrefs.GetInt(i.ToString(), 0);
            images[i].sprite = sprites[i].sprs[upgradecount[i]];
            lvTexts[i].text = "Lv " + ((int)upgradecount[i] + 1).ToString();
            upgradeCostText[i].text = ((int)upgradeCost[upgradecount[i]]).ToString() + "G";
        }

        carImage[0].sprite = images[tireKey].sprite;
        carImage[1].sprite = images[tireKey].sprite;

        carImage[2].sprite = images[boosterKey].sprite;

        carImage[3].sprite = images[bumperKey].sprite;
    }
    #endregion //upgrade service


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
        playButton.SetActive(false);
        if (PlayerCar)
        {
            Destroy(PlayerCar);
        }

        UpgradePanelAnimator.SetBool("IsUp", true);
        PlayerCar = Instantiate(Car, transform.position, quaternion.identity);

        GoldManager.instance.PrevGold = GoldManager.instance.Gold;
    }

    public void GameOver()
    {
        playButton.SetActive(true);
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public int PrevGold;
    public int Gold = 0;
    private string goldKey = "goldKey";
    public static GoldManager instance;

    public Text goldText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Gold = PlayerPrefs.GetInt(goldKey, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GetGold(int v)
    {
        Gold += v;
        PlayerPrefs.SetInt(goldKey,Gold);
    }

    public bool LoseGold(int v)
    {
        if (Gold - v >= 0)
        {
            Gold -= v;
            PlayerPrefs.SetInt(goldKey,Gold);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CheckScore()
    {
        StartCoroutine(PlusGold());   
    }

    public  IEnumerator PlusGold()
    {
        while (PrevGold < Gold)
        {
            PrevGold++;
            yield return new WaitForSeconds(0.02f);
        }
    }
}

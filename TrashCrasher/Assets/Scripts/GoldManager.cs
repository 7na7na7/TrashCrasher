using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public int Gold = 0;
    private string goldKey = "goldKey";
    public static GoldManager instance;

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
}

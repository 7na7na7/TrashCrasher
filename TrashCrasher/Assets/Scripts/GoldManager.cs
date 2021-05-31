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

    public Text weightText;
    public Text distanceText;
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

    public void CheckScore(float trashWeight, float moveDistance)
    {
        StartCoroutine(PlusGold(trashWeight, moveDistance));   
    }

    public  IEnumerator PlusGold(float trashWeight, float moveDistance)
    {
        float point = 0;

        float _trashWeight = 0;

        float _moveDistance = 0;

        yield return new WaitForSeconds(3.0f);

        while (_trashWeight < trashWeight)
        {
            _trashWeight+=1f;
            weightText.text = "처리한 쓰레기 량 : "+_trashWeight.ToString() + "KG";
            yield return new WaitForSeconds(0.02f);
        }

        while (_moveDistance < moveDistance)
        {
            _moveDistance+=1f;
            distanceText.text = "이동 거리 : "+_moveDistance.ToString() + "M";
            yield return new WaitForSeconds(0.02f);
        }

        GetGold(Convert.ToInt32(trashWeight * 10 + moveDistance));

        while (PrevGold < Gold)
        {
            PrevGold++;
            goldText.text = "골드 : "+PrevGold.ToString() + "G";
            yield return new WaitForSeconds(0.01f);
        }
    }
}

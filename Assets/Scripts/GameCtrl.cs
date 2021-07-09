using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System;
using TMPro;
using BreakInfinity;
using static BreakInfinity.BigDouble;

public class GameCtrl : MonoBehaviour
{
    public static Data data = new Data();

    public int i;

    public BigDouble moneyPerSec
    {
        get
        {
            return Ceiling(Enemy.healthMax / 14) / Enemy.healthMax * data.dps;
        }
    }
    
    public float timer;
    public float timerMax = 30;

    public Text killsText;
    public Text stageText;
    public Text moneyText;
    public Text timerText;
    public Text usernameText;

    public Image timerBar;


    public GameObject[] enemy = new GameObject[2];
    public GameObject[] boss = new GameObject[1];

    public void Start()
    {
        
    }
    
    public void Update()
    {
        if(Enemy.health <=0)
        {
            Kill();
            data.money += Ceiling(Enemy.healthMax / 14);
            data.kills++;
            if(data.kills>=data.killsMax)
            {
                data.kills = 0;
                data.stage++;
            }
            Spawn();
        }
        else Enemy.health -= data.dps * Time.deltaTime;

        killsText.text = "Kills: " + data.kills + "/" + data.killsMax;
        stageText.text = "Stage: " + data.stage;
        moneyText.text = "Gold: " + WordNotation(data.money, "F2");
        usernameText.text = data.username;
        IsBossChecker();
    }

    public void Spawn()
    {
        if(data.stage%5!=0)
        {
            int i = Random.Range(0,2);
            Instantiate(enemy[i],enemy[i].transform.position, Quaternion.identity);
        }
        else
        {
            int i = Random.Range(0,1);
            Instantiate(boss[i],boss[i].transform.position, Quaternion.identity);
        }
    }

    public void IsBossChecker()
    {
        if(GameCtrl.data.stage%5!=0)
        {
            data.isBoss = 1;
            stageText.text = "Stage " + GameCtrl.data.stage;
            timerText.text = "";
            timerBar.gameObject.SetActive(false);
            timer = 30;
            data.killsMax = 10;
            //bgBoss cahnge
        }
        else
        {
            data.isBoss = 10;
            stageText.text = "BOSS!";
            timer-=Time.deltaTime;
            if(timer<=0)Back();
            timerText.text = timer.ToString("F2")+"s";
            timerBar.gameObject.SetActive(true);
            timerBar.fillAmount = timer/timerMax;
            data.killsMax = 1;
            //bgBoss cahnge
        }
    }

    public void Kill()
    {
        Enemy.a = true;
    }



    public void Back()
    {
        data.stage--;
    }

    public void Forward()
    {
        data.stage++;
    }

    public static string WordNotation(BigDouble number, string digits)
    {
        var prefixes = new Dictionary<BigDouble, string>
        {
            {3.0,"K"},
            {6.0,"M"},
            {9.0,"B"},
            {12.0,"T"},
            {15.0,"Qa"},
            {18.0,"Qi"},
            {21.0,"Se"},
            {24.0,"Sep"}
        };

        var exponent = Floor(Log10(number));
        var thirdExponent = 3 * Floor(exponent / 3);
        var mantissa = (number / Pow(10, thirdExponent));

        if (number <= 1000) return number.ToString(digits);
        return mantissa.ToString(digits) + prefixes[thirdExponent];
    }
}

    
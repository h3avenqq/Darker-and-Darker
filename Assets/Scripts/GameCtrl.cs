using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using TMPro;
using BreakInfinity;
using static BreakInfinity.BigDouble;

public class GameCtrl : MonoBehaviour
{
    public static Data data = new Data();
    
    public BigDouble moneyPerSec
    {
        get
        {
            return Ceiling(Enemy.healthMax / 14) / Enemy.healthMax * data.dph*data.MoneyPerSecMultiply;
        }
    }

    public int multiplierTimer = 0;
    
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
    public GameObject multiplier;
    
    //double attack for hero
    public static bool doubleAttackHero;
    public static int doubleAttackTimeHero = 0;

    
    
    //save system
    public DateTime currentTime;
    public DateTime oldTime;
    public float IdleTime;
    public Text offlineTimeText;
    public float saveTime;
    public GameObject offlineBox;
    public int offlineLoadCount;
    
    private const string dataFileName = "Darker&Darker";
    
    public void Start()
    {
        data = SaveSystem.SaveExists("Darker&Darker")
            ? SaveSystem.LoadData<Data>("Darker&Darker")
            : new Data();
StartCoroutine("ActionPerSecond");
    }
    
    public void Update()
    {
        if (Enemy.health <= 0)
        {
            Kill();
            data.money += Ceiling(Enemy.healthMax / 14)*data.MoneyForKillMultiply;
            data.kills++;
            if (data.kills >= data.killsMax)
            {
                data.kills = 0;
                data.stage++;
            }

            Spawn();
        }

        killsText.text = "Kills: " + data.kills + "/" + data.killsMax;
        stageText.text = "Stage: " + data.stage;
        moneyText.text = "Gold: " + WordNotation(data.money, "F2");
        // usernameText.text = data.username;
        // offlineBox.gameObject.SetActive(false);
        //multBox.gameObject.SetActive(false);
        // LoadOfflineProduction();
        // if (data.username == "<Username>")
        //     usernameBox.gameObject.SetActive(true);
        // else
        //     usernameBox.gameObject.SetActive(false);
        IsBossChecker();
        saveTime += Time.deltaTime * (1 / Time.timeScale);
        if (saveTime >= 15)
        {
            SaveSystem.SaveData(data, dataFileName);
            saveTime = 0;
            SaveOfflineTime();
        }
    }
    
    public void SaveOfflineTime()
    {
        PlayerPrefs.SetString("OfflineTime", DateTime.Now.ToBinary().ToString());
        data.OfflineProgressCheck = 1;
    }

    private IEnumerator ActionPerSecond()
    {
        for(;;)
        {
            data.money += moneyPerSec;
            //double attack 
            if (data.DoubleAttack && !Enemy.doubleAttack)
            {
                Enemy.doubleAttackTime++;
            }

            if (Enemy.doubleAttackTime == data.DoubleAttackTime)
            {
                Enemy.doubleAttack = true;
            }
            //critical damage ane double attack for hero
            if (data.DoubleAttackHero && !doubleAttackHero)
            {
                doubleAttackTimeHero++;
            }

            if (doubleAttackTimeHero == data.DoubleAttackTimeHero)
            {
                doubleAttackHero = true;
            }
            
            double criticalCheckHero = UnityEngine.Random.Range(0,101);
            if (criticalCheckHero > (100 - GameCtrl.data.CriticalChanceHero))
            {
                Enemy.health -= GameCtrl.data.CriticalDamageHero * GameCtrl.data.dps;
            }
            else
            {
                Enemy.health -= GameCtrl.data.dps;
            }

            if (doubleAttackHero)
            {
                criticalCheckHero = UnityEngine.Random.Range(0,101);
                if (criticalCheckHero > (100 - GameCtrl.data.CriticalChanceHero))
                {
                    Enemy.health -= GameCtrl.data.CriticalDamageHero * GameCtrl.data.dps;
                    Debug.Log("hero crit double attack");
                }
                else
                {
                    Enemy.health -= GameCtrl.data.dps;
                }

                doubleAttackHero = false;
                doubleAttackTimeHero = 0;
                Debug.Log("hero Double attack");
            }
            
            //Multiplier
            if (!data.MoneyMultiplyCondition)
            {
                multiplierTimer++;
            }
            
            if(multiplierTimer==data.MoneyMultiplyTimer)
            {
                data.MoneyMultiplyCondition = true;
                double check = UnityEngine.Random.Range(0,101);
                if(check > (100 - GameCtrl.data.MoneyMultiplyChance))
                {
                    multiplier.gameObject.SetActive(true);
                }
                multiplierTimer = 0;
            }
            
            
            yield return new WaitForSeconds(1);
        }
    }

    public void Spawn()
    {
        if(data.stage%5!=0)
        {
            int i = UnityEngine.Random.Range(0,2);
            Instantiate(enemy[i],enemy[i].transform.position, Quaternion.identity);
        }
        else
        {
            int i = UnityEngine.Random.Range(0,1);
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

    public void LoadOfflineProduction()
    {
        if (data.OfflineProgressCheck == 1)
        {
            offlineBox.gameObject.SetActive(true);
            long previousTime = Convert.ToInt64(PlayerPrefs.GetString("OfflineTime"));
            oldTime = DateTime.FromBinary(previousTime);
            currentTime = DateTime.Now;
            TimeSpan difference = currentTime.Subtract(oldTime);
            IdleTime = (float)difference.TotalSeconds;

            var moneyToEarn = Ceiling(Enemy.healthMax / 14) / Enemy.healthMax * (data.dps / 5) * IdleTime;
            data.money += moneyToEarn;
            TimeSpan timer = TimeSpan.FromSeconds(IdleTime);

            offlineTimeText.text = "You were gone for: " + timer.ToString(@"hh\:mm\:ss") + "\nand earned " + moneyToEarn.ToString("F2") + " coins";
        }
    }

    public void CloseOfflineBox()
    {
        offlineBox.gameObject.SetActive(false);
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
            {24.0,"Sep"},
            {27.0,"Oct"},
            {30.0,"Non"},
            {33.0,"Dec"},
            {36.0,"Und"},
            {39.0,"Duo"},
            {42.0,"Tre"},
            {45.0,"Qua"},
            {48.0,"Qui"},
            {51.0,"Sex"},
            {54.0,"Sept"},
            {57.0,"Octo"},
            {60.0,"Nov"},
        };

        var exponent = Floor(Log10(number));
        var thirdExponent = 3 * Floor(exponent / 3);
        var mantissa = (number / Pow(10, thirdExponent));

        if (number <= 1000) return number.ToString(digits);
        return mantissa.ToString(digits) + prefixes[thirdExponent];
    }

}

    

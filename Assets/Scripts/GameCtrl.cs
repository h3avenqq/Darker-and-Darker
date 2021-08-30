using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
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
    
    //double attack for hero
    public static bool doubleAttackHero;
    public static int doubleAttackTimeHero = 0;

    public void Start()
    {
        StartCoroutine("DpsDealerAndDoubleAttack");
    }
    
    public void Update()
    {
        if (Enemy.health <= 0)
        {
            Kill();
            data.money += Ceiling(Enemy.healthMax / 14);
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
        usernameText.text = data.username;
        IsBossChecker();
    }

    private IEnumerator DpsDealerAndDoubleAttack()
    {
        for(;;) {
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
            
            double criticalCheckHero = Random.Range(0,101);
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
                criticalCheckHero = Random.Range(0,101);
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
            
            yield return new WaitForSeconds(1);
        }
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

    

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;
using static BreakInfinity.BigDouble;

public class Enemy : MonoBehaviour
{
    public static BigDouble health;
    public static BigDouble healthMax
    {
        get
        {
            return 10*Pow(2,GameCtrl.data.stage-1)*GameCtrl.data.isBoss;
        }
    }


    public static bool a = false;//пофикси эту хуйню уебище на максиме
    public static bool doubleAttack;
    
    public Image healthBar;

    public Text healthText;
    
    public static int doubleAttackTime = 0;
    
    private void Start()
    {
        health = healthMax;
    }

    private void Update()
    {
        healthText.text = WordNotation(health, "F2") + "/" + WordNotation(healthMax, "F2") + " HP";
        healthBar.fillAmount = (float)(health / healthMax).ToDouble();
        if(a)
        {
            Kill();
            a = false;
        }
    }

    private void OnMouseUpAsButton()
    {
        double criticalCheck = Random.Range(0,101);
        if (criticalCheck > (100 - GameCtrl.data.CriticalChance))
        {
            health -= GameCtrl.data.CriticalDamage * GameCtrl.data.dph;
        }
        else
        {
            health -= GameCtrl.data.dph;
        }

        if (doubleAttack)
        {
            criticalCheck = Random.Range(0,101);
            if (criticalCheck > (100 - GameCtrl.data.CriticalChance))
            {
                health -= GameCtrl.data.CriticalDamage * GameCtrl.data.dph;
                Debug.Log("crit double attack");
            }
            else
            {
                health -= GameCtrl.data.dph;
            }

            doubleAttack = false;
            doubleAttackTime = 0;
            Debug.Log("Double attack");
        }
    }

    private void Kill()
    {
        Destroy(this.gameObject);
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

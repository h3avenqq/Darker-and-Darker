using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
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


    public static bool a = false;

    public Image healthBar;

    public Text healthText;

    private void Start()
    {
        health = healthMax;
    }

    private void Update()
    {
        healthText.text = health + "/" + healthMax;
        healthBar.fillAmount = (float)(health / healthMax).ToDouble();
        if(a)
        {
            Kill();
            a = false;
        }
    }

    private void OnMouseUpAsButton()
    {
        health-=GameCtrl.data.dph;
    }

    private void Kill()
    {
        Destroy(this.gameObject);
    }

}

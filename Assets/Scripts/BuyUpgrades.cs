using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System;
using TMPro;
using BreakInfinity;
using static BreakInfinity.BigDouble;

public class BuyUpgrades : MonoBehaviour
{
    public Text PowerText;
    public Text LevelText;
    public Text CostText;
    public Text dphText;

    public string id;

    public BigDouble playerCost
    {
        get
        {
            return 10 * Pow(1.07, GameCtrl.data.playerLevel);
        }
    }
    public BigDouble playerPower
    {
        get
        {
            return 2 * GameCtrl.data.playerLevel;
        }
    }
    public BigDouble heroCost
    {
        get
        {
            switch (id)
            {
            case "hero1":
                return 10 * Pow(1.07, GameCtrl.data.heroLevel1);
                break;
            case "hero2":
                return 10 * Pow(1.07, GameCtrl.data.heroLevel2);
                break;
            case "hero3":
                return 10 * Pow(1.07, GameCtrl.data.heroLevel3);
                break;
            default:
                return 0;
                break;
            }
        }
    }
    public BigDouble heroPower
    {
        get
        {
            switch (id)
            {
            case "hero1":
                return 5 * GameCtrl.data.heroLevel1;
                break;
            case "hero2":
                return 5 * GameCtrl.data.heroLevel2;
                break;
            case "hero3":
                return 5 * GameCtrl.data.heroLevel3;
                break;
            default:
                return 0;
                break;
            }
        }
    }

    public void Update()
    {
        Upgrades();
    }

    public BigDouble getHeroPower(string id)
    {
        switch (id)
            {
            case "hero1":
                return 5 * GameCtrl.data.heroLevel1;
                break;
            case "hero2":
                return 5 * GameCtrl.data.heroLevel2;
                break;
            case "hero3":
                return 5 * GameCtrl.data.heroLevel3;
                break;
            default:
                return 0;
                break;
            }
    }

    public void OnMouseUpAsButton()
    {
        switch (id)
        {
            case "player1":
                if (GameCtrl.data.money >= playerCost) UpgradeDefaults(ref GameCtrl.data.playerLevel, playerCost);
                break;
            case "hero1":
                if (GameCtrl.data.money >= heroCost) UpgradeDefaults(ref GameCtrl.data.heroLevel1, heroCost);
                break;
            case "hero2":
                if (GameCtrl.data.money >= heroCost) UpgradeDefaults(ref GameCtrl.data.heroLevel2, heroCost);
                break;
            case "hero3":
                if (GameCtrl.data.money >= heroCost) UpgradeDefaults(ref GameCtrl.data.heroLevel3, heroCost);
                break;
        }
    }

    public void Upgrades()
    {
        switch(id)
        {
            case "player1":
                CostText.text = WordNotation(playerCost, "F2") + " coins";
                LevelText.text = "Level: " + GameCtrl.data.playerLevel;
                PowerText.text = 2 * (GameCtrl.data.playerLevel+1) + " per hit";//тут и в других свитчах убран плюс сколько урона получишь 
                dphText.text = "DPH: " + WordNotation(GameCtrl.data.dph, "F2");//за апгрейд тк не правильно выводило. позже надо сделать.
                break;
            case "hero1":
                CostText.text = WordNotation(heroCost, "F2") + " coins";
                LevelText.text = "Level: " + GameCtrl.data.heroLevel1;
                PowerText.text = 5 * (GameCtrl.data.heroLevel1+1) + " per hit";
                dphText.text = "DPH: " + WordNotation(heroPower, "F2");
                break;
            case "hero2":
                CostText.text = WordNotation(heroCost, "F2") + " coins";
                LevelText.text = "Level: " + GameCtrl.data.heroLevel2;
                PowerText.text = 5 * (GameCtrl.data.heroLevel2+1) + " per hit";
                dphText.text = "DPH: " + WordNotation(heroPower, "F2");
                break;
            case "hero3":
                CostText.text = WordNotation(heroCost, "F2") + " coins";
                LevelText.text = "Level: " + GameCtrl.data.heroLevel3;
                PowerText.text = 5 * (GameCtrl.data.heroLevel3+1) + " per hit";
                dphText.text = "DPH: " + WordNotation(heroPower, "F2");
                break;
        }
        GameCtrl.data.dph = 1 + playerPower;
        GameCtrl.data.dps = getHeroPower("hero1")+getHeroPower("hero2")+getHeroPower("hero3");
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

    public void UpgradeDefaults(ref int level, BigDouble cost)
    {
        GameCtrl.data.money -= cost;
        level++;
        //GameCtrl.data.dps+=5;
    }
}

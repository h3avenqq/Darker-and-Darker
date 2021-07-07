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
            return 10 * Pow(1.07, GameCtrl.data.heroLevel);
        }
    }
    public BigDouble heroPower
    {
        get
        {
            return 5 * GameCtrl.data.heroLevel;
        }
    }

    public void Update()
    {
        Upgrades();
    }

    public void OnMouseUpAsButton()
    {
        switch (id)
        {
            case "hero1":
                if (GameCtrl.data.money >= heroCost) UpgradeDefaults(ref GameCtrl.data.heroLevel, heroCost);
                break;
            case "player1":
                if (GameCtrl.data.money >= playerCost) UpgradeDefaults(ref GameCtrl.data.playerLevel, playerCost);
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
                PowerText.text = "+" + 2 * (GameCtrl.data.playerLevel+1) + " per hit";
                break;
            case "hero1":
                CostText.text = WordNotation(heroCost, "F2") + " coins";
                LevelText.text = "Level: " + GameCtrl.data.heroLevel;
                PowerText.text = "+" + 2 * (GameCtrl.data.heroLevel+1) + " per sec";
                break;
        }
        GameCtrl.data.dps = heroPower;
        GameCtrl.data.dph = 1 + playerPower;
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
    }
}

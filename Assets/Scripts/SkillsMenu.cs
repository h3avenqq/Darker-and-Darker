using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;
using static BreakInfinity.BigDouble;

public class SkillsMenu : MonoBehaviour
{
    public BigDouble gemsToGet;
    public BigDouble prestigeCost = 1000;
    
    public Text gemsText;
    public Text gemsToGetText;
    public Text prestigeCostText;

    public Sprite layer_off;
    public Sprite layer_on;

    public GameObject BuyButton;
    
    private void Update()
    {
        gemsToGet = Floor(150 * Sqrt(GameCtrl.data.money / 1e7) + 1);
        gemsToGetText.text = "+" + WordNotation(gemsToGet,"F0") + " Gems";
        gemsText.text = "Gems: " + WordNotation(GameCtrl.data.gems,"F0");
        prestigeCostText.text = WordNotation(prestigeCost, "F0") + " Gems";
        
        if (GameCtrl.data.money >= prestigeCost) BuyButton.GetComponent<SpriteRenderer>().sprite = layer_on;
        else BuyButton.GetComponent<SpriteRenderer>().sprite = layer_off;
    }

    public void OnMouseUpAsButton()
    {
        Prestige();
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
    
    public void Prestige()
    {
        if(GameCtrl.data.money > prestigeCost)
        {
            Enemy.health = 0;
            GameCtrl.data.money = 0.0;
            GameCtrl.data.dph = 1.1;
            GameCtrl.data.dps = 0.0;
            GameCtrl.data.stage = 1;
            GameCtrl.data.stageMax = 1;
            GameCtrl.data.kills = 0;
            GameCtrl.data.killsMax = 10;
            GameCtrl.data.isBoss = 1;
            GameCtrl.data.heroLevel1 = 0;
            GameCtrl.data.heroLevel2 = 0;
            GameCtrl.data.heroLevel3 = 0;
            GameCtrl.data.playerLevel = 0;
            GameCtrl.data.gems += gemsToGet;
        }
    }
}

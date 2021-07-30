using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;
using static BreakInfinity.BigDouble;

public class BuyUpgrades : MonoBehaviour
{
    public Text PowerText;
    public Text LevelText;
    public Text CostText;
    public Text dphText;

    public Sprite layer_off;
    public Sprite layer_on;

    public string id;

    public BigDouble currentMoney;
    public BigDouble playerCost
    {
        get
        {
            BigDouble x = 0;
            if(xNumBuy.xButton==-1)
            {
                xNumBuy.xButton=1;
                x+=10 * Pow(1.07, GameCtrl.data.playerLevel+xNumBuy.xButton);
                currentMoney-=x;
                while(currentMoney-10 * Pow(1.07, GameCtrl.data.playerLevel+xNumBuy.xButton+1)>=0)
                {
                    xNumBuy.xButton++;
                    currentMoney-=10 * Pow(1.07, GameCtrl.data.playerLevel+xNumBuy.xButton);
                    x+=10 * Pow(1.07, GameCtrl.data.playerLevel+1);
                }
            }
            else
            {
                for(int i = 1;i<=xNumBuy.xButton;i++)
                {
                    x+=10 * Pow(1.07, GameCtrl.data.playerLevel+i);
                }
            }
            return x;
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
            BigDouble x = 0;
            switch (id)
            {
            case "hero1": 
                if(xNumBuy.xButtonHero1==-1)
                {
                    xNumBuy.xButtonHero1=1;
                    x+=10 * Pow(1.07, GameCtrl.data.heroLevel1+xNumBuy.xButtonHero1);
                    currentMoney-=x;
                    while(currentMoney-10 * Pow(1.07, GameCtrl.data.heroLevel1+xNumBuy.xButtonHero1+1)>=0)
                    {
                        xNumBuy.xButtonHero1++;
                        currentMoney-=10 * Pow(1.07, GameCtrl.data.heroLevel1+xNumBuy.xButtonHero1);
                        x+=10 * Pow(1.07, GameCtrl.data.heroLevel1+1);
                    }
                }
                else
                {
                    for(int i = 1;i<=xNumBuy.xButtonHero1;i++)
                    {
                        x+=10 * Pow(1.07, GameCtrl.data.heroLevel1+i);
                    }
                }
                return x;
                break;
            case "hero2":
                if(xNumBuy.xButtonHero2==-1)
                {
                    xNumBuy.xButtonHero2=1;
                    x+=10 * Pow(1.07, GameCtrl.data.heroLevel2+xNumBuy.xButtonHero2);
                    currentMoney-=x;
                    while(currentMoney-10 * Pow(1.07, GameCtrl.data.heroLevel2+xNumBuy.xButtonHero2+1)>=0)
                    {
                        xNumBuy.xButtonHero2++;
                        currentMoney-=10 * Pow(1.07, GameCtrl.data.heroLevel2+xNumBuy.xButtonHero2);
                        x+=10 * Pow(1.07, GameCtrl.data.heroLevel2+1);
                    }
                }
                else
                {
                    for(int i = 1;i<=xNumBuy.xButtonHero2;i++)
                    {
                        x+=10 * Pow(1.07, GameCtrl.data.heroLevel2+i);
                    }
                }
                return x;
                break;
            case "hero3":
                if(xNumBuy.xButtonHero3==-1)
                {
                    xNumBuy.xButtonHero3=1;
                    x+=10 * Pow(1.07, GameCtrl.data.heroLevel3+xNumBuy.xButtonHero3);
                    currentMoney-=x;
                    while(currentMoney-10 * Pow(1.07, GameCtrl.data.heroLevel3+xNumBuy.xButtonHero3+1)>=0)
                    {
                        xNumBuy.xButtonHero3++;
                        currentMoney-=10 * Pow(1.07, GameCtrl.data.heroLevel3+xNumBuy.xButtonHero3);
                        x+=10 * Pow(1.07, GameCtrl.data.heroLevel3+1);
                    }
                }
                else
                {
                    for(int i = 1;i<=xNumBuy.xButtonHero3;i++)
                    {
                        x+=10 * Pow(1.07, GameCtrl.data.heroLevel3+i);
                    }
                }
                return x;
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
        currentMoney = GameCtrl.data.money;
        Upgrades();
        switch (id)
        {
            case "player1":
                if (GameCtrl.data.money >= playerCost) GetComponent<SpriteRenderer>().sprite = layer_on;
                else GetComponent<SpriteRenderer>().sprite = layer_off;
                break;
            default:
                if (GameCtrl.data.money >= heroCost) GetComponent<SpriteRenderer>().sprite = layer_on;
                else GetComponent<SpriteRenderer>().sprite = layer_off;
                break;
        }
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
                if (GameCtrl.data.money >= playerCost) UpgradeDefaults(ref GameCtrl.data.playerLevel, playerCost, xNumBuy.xButton);
                break;
            case "hero1":
                if (GameCtrl.data.money >= heroCost) UpgradeDefaults(ref GameCtrl.data.heroLevel1, heroCost, xNumBuy.xButtonHero1);
                break;
            case "hero2":
                if (GameCtrl.data.money >= heroCost) UpgradeDefaults(ref GameCtrl.data.heroLevel2, heroCost, xNumBuy.xButtonHero2);
                break;
            case "hero3":
                if (GameCtrl.data.money >= heroCost) UpgradeDefaults(ref GameCtrl.data.heroLevel3, heroCost, xNumBuy.xButtonHero3);
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
                PowerText.text = 2 * (GameCtrl.data.playerLevel+xNumBuy.xButton)+1 + " per hit";//тут и в других свитчах убран плюс сколько урона получишь 
                dphText.text = "DPH: " + WordNotation(GameCtrl.data.dph, "F2");//за апгрейд тк не правильно выводило. позже надо сделать.
                break;
            case "hero1":
                CostText.text = WordNotation(heroCost, "F2") + " coins";
                LevelText.text = "Level: " + GameCtrl.data.heroLevel1;
                PowerText.text = 5 * (GameCtrl.data.heroLevel1+xNumBuy.xButtonHero1) + " per hit";
                dphText.text = "DPH: " + WordNotation(heroPower, "F2");
                break;
            case "hero2":
                CostText.text = WordNotation(heroCost, "F2") + " coins";
                LevelText.text = "Level: " + GameCtrl.data.heroLevel2;
                PowerText.text = 5 * (GameCtrl.data.heroLevel2+xNumBuy.xButtonHero2) + " per hit";
                dphText.text = "DPH: " + WordNotation(heroPower, "F2");
                break;
            case "hero3":
                CostText.text = WordNotation(heroCost, "F2") + " coins";
                LevelText.text = "Level: " + GameCtrl.data.heroLevel3;
                PowerText.text = 5 * (GameCtrl.data.heroLevel3+xNumBuy.xButtonHero3) + " per hit";
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

    public void UpgradeDefaults(ref int level, BigDouble cost, int amount)
    {
        GameCtrl.data.money -= cost;
        level+=amount;
        if(xNumBuy.xMax)
        {
            xNumBuy.Switcher("x1");
            xNumBuy.xButton=1;
        }
    }
}

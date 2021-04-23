using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class GameController : MonoBehaviour
{
    public double money;
    public double moneyPerSec
    {
        get
        {
            return Math.Ceiling(healthMax / 14) / healthMax * dps;
        }
    }
    public double dph;
    public double dps;
    public double health;
    public double healthMax
    {
        get
        {
            return 10 * System.Math.Pow(2, stage - 1) * isBoss;
        }
    }

    public float timer;

    public int stage;
    public int stageMax;
    public int kills;
    public int killsMax;
    public int isBoss;
    public int timerMax;

    public Text moneyText;
    public Text dPHText;
    public Text dPSText;
    public Text healthText;
    public Text stageText;
    public Text killsText;
    public Text timerText;

    public GameObject back;
    public GameObject forward;

    public Image healthBar;
    public Image timerBar;

    //OFFLINE
    public DateTime currentTime;
    public DateTime oldTime;
    public int OfflineProgressCheck;
    public float IdleTime;
    public Text offlineTimeText;                             
    public float saveTime;                                   
    public GameObject offlineBox;                            
    public int offlineLoadCount;                             
                                                             
    //Multiplier                                             
    public Text multText;                                    
    public double multValue;                                 
    public float timerMult;                                  
    public float TimerMultMax;                               
    public double multValueMoney;                            
    public GameObject multBox;                               
                                                             
    //Username                                               
    public TMP_InputField usernameInput;                     
    public string username;                                  
    public Text usernameText;                                
    public GameObject usernameBox;                           

    //Upgrades
    public Text heroCostText;
    public Text heroLevelText;
    public Text heroPowerText;
    public double heroCost
    {
        get
        {
            return 10 * Math.Pow(1.07, heroLevel);
        }
    }
    public int heroLevel;
    public double heroPower
    {
        get
        {
            return 5 * heroLevel;
        }
    }
    public Text playerCostText;
    public Text playerLevelText;
    public Text playerPowerText;
    public double playerCost
    {
        get
        {
            return 10 * Math.Pow(1.07, playerLevel);
        }
    }
    public int playerLevel;
    public double playerPower
    {
        get
        {
            return 2 * playerLevel;
        }
    }

    //BG
    public Image bgBoss;

    public void Start()
    {
        offlineBox.gameObject.SetActive(false);
        multBox.gameObject.SetActive(false);
        Load();
        if (username == "<Username>")
            usernameBox.gameObject.SetActive(true);
        else
            usernameBox.gameObject.SetActive(false);
        IsBossChecker();
        health = healthMax;
        timerMax = 30;        
        multValue = new System.Random().Next(20,100);
        TimerMultMax = new System.Random().Next(5, 10);
        timerMult = TimerMultMax;
    }

    public void Update()
    {
        if (health <= 0) Kill();
        else
            health -= dps * Time.deltaTime;

        //Multiplier
        multValueMoney = multValue * moneyPerSec;
        multText.text = WordNotation(multValueMoney, "F2");
        if (timerMult <= 0) multBox.gameObject.SetActive(true);
        else
            timerMult -= Time.deltaTime;

        moneyText.text = "Gold: " + WordNotation(money, "F2");
        dPHText.text = "Damage Per Hit: " + WordNotation(dph, "F2");
        dPSText.text = "Damage Per Second: " + WordNotation(dps, "F2");
        stageText.text = "Stage " + stage;
        killsText.text = kills + "/" + killsMax + " kills";
        healthText.text = WordNotation(health, "F2") + "/" + WordNotation(healthMax, "F2") + " HP";

        healthBar.fillAmount = (float)(health / healthMax);

        if (stage > 1) back.gameObject.SetActive(true);
        else
            back.gameObject.SetActive(false);

        if (stage != stageMax) forward.gameObject.SetActive(true);
        else
            forward.gameObject.SetActive(false);

        IsBossChecker();
        usernameText.text = username;
        Upgrades();

        saveTime += Time.deltaTime;
        if (saveTime >= 5)
        {
            saveTime = 0;
            Save();
        }
    }

    public void Upgrades()
    {
        playerCostText.text = WordNotation(playerCost, "F2") + " coins" ;
        playerLevelText.text = "Level: " + playerLevel;
        playerPowerText.text = "+" + playerPower + " per hit";

        heroCostText.text = WordNotation(heroCost, "F2") + " coins";
        heroLevelText.text = "Level: " + heroLevel;
        heroPowerText.text = "+" + heroPower + " per sec";
        dps = heroPower;
        dph = 1 + playerPower;
    }

    public void UsernameChange()
    {
        username = usernameInput.text;
    }
    public void CloseUsernameBox()
    {
        usernameBox.gameObject.SetActive(false);
    }

    public void IsBossChecker()
    {

        if (stage % 5 == 0)
        {
            isBoss = 10;
            stageText.text = "BOSS!";
            timer -= Time.deltaTime;
            if (timer <= 0) Back();

            timerText.text = timer.ToString("F2") + "s";
            timerBar.gameObject.SetActive(true);
            timerBar.fillAmount = timer / timerMax;
            killsMax = 1;
            bgBoss.gameObject.SetActive(true);
        }
        else
        {
            isBoss = 1;
            stageText.text = "Stage " + stage;
            timerText.text = "";
            timerBar.gameObject.SetActive(false);
            timer = 30;
            killsMax = 10;
            bgBoss.gameObject.SetActive(false);
        }
    }

    public void Hit()
    {
        health -= dph;
        if (health <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
            money += System.Math.Ceiling(healthMax / 14);
            if (stage == stageMax)
            {
                kills += 1;
                if (kills >= killsMax)
                {
                    kills = 0;
                    stage += 1;
                    stageMax += 1;
                }
            }
            IsBossChecker();
            health = healthMax;
            if (isBoss > 1) timer = timerMax;
            killsMax = 10;
    }

    public void Back()
    {
       stage -= 1;
       IsBossChecker();
       health = healthMax;
    }
    public void Forward()                      
    {                                          
       stage += 1;                             
       IsBossChecker();                        
           health = healthMax;                     
    }
    
    public void BuyUpgrade(string id)
    {
        switch (id)
        {
            case "hero1":
                if (money >= heroCost) UpgradeDefaults(ref heroLevel, heroCost);
                break;
            case "player1":
                if (money >= playerCost) UpgradeDefaults(ref playerLevel, playerCost);
                break;
        }
    }
    
    public void UpgradeDefaults(ref int level, double cost)
    {
        money -= cost;
        level++;
    }

    public string WordNotation(double number, string digits)
    {
        double digitsTemp = Math.Floor(Math.Log10(number));
        IDictionary<double, string> prefixes = new Dictionary<double, string>()
        {
            {3,"K"},
            {6,"M"},
            {9,"B"},
            {12,"T"},
            {15,"Qa"},
            {18,"Qi"},
            {21,"Se"},
            {24,"Sep"}
        };
        double digitsEvery3 = 3 * Math.Floor(digitsTemp / 3);
        if (number >= 1000)
            return (number / Math.Pow(10, digitsEvery3)).ToString(digits) + prefixes[digitsEvery3];
        return number.ToString(digits);
    }
    
    public void Save()
     {
        OfflineProgressCheck = 1;
        PlayerPrefs.SetString("money", money.ToString());
        PlayerPrefs.SetString("dph", dph.ToString());
        PlayerPrefs.SetString("dps", dps.ToString());
        PlayerPrefs.SetString("username", username.ToString());
        PlayerPrefs.SetInt("stage", stage);
        PlayerPrefs.SetInt("stageMax", stageMax);
        PlayerPrefs.SetInt("kills", kills);
        PlayerPrefs.SetInt("killsMax", killsMax);
        PlayerPrefs.SetInt("isBoss", isBoss);
        PlayerPrefs.SetInt("heroLevel", heroLevel);
        PlayerPrefs.SetInt("playerLevel", playerLevel);
        PlayerPrefs.SetInt("OfflineProgressCheck", OfflineProgressCheck);
        
        PlayerPrefs.SetString("OfflineTime", DateTime.Now.ToBinary().ToString());OfflineProgressCheck = 1;
     }
    
    public void Load()
    {              
        money = double.Parse(PlayerPrefs.GetString("money", "0"));
        dph = double.Parse(PlayerPrefs.GetString("dph", "1"));
        dps = double.Parse(PlayerPrefs.GetString("dps", "0"));
        stage = PlayerPrefs.GetInt("stage", 1);
        stageMax = PlayerPrefs.GetInt("stageMax", 1);
        kills = PlayerPrefs.GetInt("kills", 0);
        killsMax = PlayerPrefs.GetInt("killsMax", 10);
        isBoss = PlayerPrefs.GetInt("isBoss", 1);
        heroLevel = PlayerPrefs.GetInt("heroLevel", 0);
        playerLevel = PlayerPrefs.GetInt("playerLevel", 0);
        OfflineProgressCheck = PlayerPrefs.GetInt("OfflineProgressCheck", 0);
        username = PlayerPrefs.GetString("username", "<Username>");
        LoadOfflineProduction();
    } 


    public void LoadOfflineProduction()
    {
        if (OfflineProgressCheck == 1)
        {
            offlineBox.gameObject.SetActive(true);
            long previousTime = Convert.ToInt64(PlayerPrefs.GetString("OfflineTime"));
            oldTime = DateTime.FromBinary(previousTime);
            currentTime = DateTime.Now;
            TimeSpan difference = currentTime.Subtract(oldTime);
            IdleTime = (float)difference.TotalSeconds;

            var moneyToEarn = Math.Ceiling(healthMax / 14) / healthMax *(dps / 5) * IdleTime;
            money += moneyToEarn;
            TimeSpan timer = TimeSpan.FromSeconds(IdleTime);

            offlineTimeText.text = "You were gone for: " + timer.ToString(@"hh\:mm\:ss") + "\nand earned " + moneyToEarn.ToString("F2") + " coins";
        }
    }

    public void CloseOfflineBox()
    {
        offlineBox.gameObject.SetActive(false);
    }

    public void OpenMult()
    {
        multBox.gameObject.SetActive(false);
        money += multValueMoney;
        TimerMultMax = new System.Random().Next(5, 10);
        timerMult = TimerMultMax;
        multValue = new System.Random().Next(20, 100);
    }
}

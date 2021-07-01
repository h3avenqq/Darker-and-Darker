using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using BreakInfinity;
using static BreakInfinity.BigDouble;

public class GameController : MonoBehaviour
{
    public Data data;

    public BigDouble moneyPerSec
    {
        get
        {
            return Ceiling(healthMax / 14) / healthMax * data.dps;
        }
    }
    public BigDouble health;
    public BigDouble healthMax
    {
        get
        {
            return 10 * Pow(2, data.stage - 1) * data.isBoss;
        }
    }

    public float timer;

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
    public float IdleTime;
    public Text offlineTimeText;
    public float saveTime;
    public GameObject offlineBox;
    public int offlineLoadCount;

    //Multiplier                                             
    public Text multText;
    public BigDouble multValue;
    public float timerMult;
    public float TimerMultMax;
    public BigDouble multValueMoney;
    public GameObject multBox;

    //Username                                               
    public TMP_InputField usernameInput;
    public Text usernameText;
    public GameObject usernameBox;

    //Upgrades
    public Text heroCostText;
    public Text heroLevelText;
    public Text heroPowerText;
    public BigDouble heroCost
    {
        get
        {
            return 10 * Pow(1.07, data.heroLevel);
        }
    }
    public BigDouble heroPower
    {
        get
        {
            return 5 * data.heroLevel;
        }
    }
    public Text playerCostText;
    public Text playerLevelText;
    public Text playerPowerText;
    public BigDouble playerCost
    {
        get
        {
            return 10 * Pow(1.07, data.playerLevel);
        }
    }
    public BigDouble playerPower
    {
        get
        {
            return 2 * data.playerLevel;
        }
    }

    //Prestige
    public Text gemsText;
    public Text gemsToGetText;

    public BigDouble gemsToGet;

    //BG
    public Image bgBoss;

    private const string dataFileName = "Darker&Darker";
    public void Start()
    {
        data = SaveSystem.SaveExists("Darker&Darker")
            ? SaveSystem.LoadData<Data>("Darker&Darker")
            : new Data();
        offlineBox.gameObject.SetActive(false);
        multBox.gameObject.SetActive(false);
        LoadOfflineProduction();
        if (data.username == "<Username>")
            usernameBox.gameObject.SetActive(true);
        else
            usernameBox.gameObject.SetActive(false);
        IsBossChecker();
        health = healthMax;
        timerMax = 30;
        multValue = new System.Random().Next(20, 100);
        TimerMultMax = new System.Random().Next(5, 10);
        timerMult = TimerMultMax;
    }

    public float SaveTime;

    public void Update()
    {
        gemsToGet = (150 * Sqrt(data.money / 1e7)) + 1;
        
        gemsToGetText.text = "Prestige:\n+" + WordNotation(gemsToGet,"F0") + " Gems";
        gemsText.text = "Gems: " + WordNotation(data.gems,"F0");
        
        if (health <= 0) Kill();
        else
            health -= data.dps * Time.deltaTime;

        //Multiplier
        multValueMoney = multValue * moneyPerSec;
        multText.text = WordNotation(multValueMoney, "F2");
        if (timerMult <= 0) multBox.gameObject.SetActive(true);
        else
            timerMult -= Time.deltaTime;

        moneyText.text = "Gold: " + WordNotation(data.money, "F2");
        dPHText.text = "Damage Per Hit: " + WordNotation(data.dph, "F2");
        dPSText.text = "Damage Per Second: " + WordNotation(data.dps, "F2");
        stageText.text = "Stage " + data.stage;
        killsText.text = data.kills + "/" + data.killsMax + " kills";
        healthText.text = WordNotation(health, "F2") + "/" + WordNotation(healthMax, "F2") + " HP";

        healthBar.fillAmount = (float)(health / healthMax).ToDouble();

        if (data.stage > 1) back.gameObject.SetActive(true);
        else
            back.gameObject.SetActive(false);

        if (data.stage != data.stageMax) forward.gameObject.SetActive(true);
        else
            forward.gameObject.SetActive(false);

        IsBossChecker();
        usernameText.text = data.username;
        Upgrades();

        SaveTime += Time.deltaTime * (1 / Time.timeScale);
        if (SaveTime >= 15)
        {
            SaveSystem.SaveData(data, dataFileName);
            saveTime = 0;
            SaveOfflineTime();
        }
    }

    //Prestige
    public void Prestige()
    {
        if(data.money > 1000)
        {
            data.money = 0.0;
            data.dph = 1.1;
            data.dps = 0.0;
            data.stage = 1;
            data.stageMax = 1;
            data.kills = 0;
            data.killsMax = 10;
            data.isBoss = 1;
            data.heroLevel = 0;
            data.playerLevel = 0;

            data.gems += gemsToGet;
        }
    }

    public void Upgrades()
    {
        playerCostText.text = WordNotation(playerCost, "F2") + " coins";
        playerLevelText.text = "Level: " + data.playerLevel;
        playerPowerText.text = "+" + playerPower + " per hit";

        heroCostText.text = WordNotation(heroCost, "F2") + " coins";
        heroLevelText.text = "Level: " + data.heroLevel;
        heroPowerText.text = "+" + heroPower + " per sec";
        data.dps = heroPower;
        data.dph = 1 + playerPower;
    }

    public void UsernameChange()
    {
        data.username = usernameInput.text;
    }
    public void CloseUsernameBox()
    {
        usernameBox.gameObject.SetActive(false);
    }

    public void IsBossChecker()
    {

        if (data.stage % 5 == 0)
        {
            data.isBoss = 10;
            stageText.text = "BOSS!";
            timer -= Time.deltaTime;
            if (timer <= 0) Back();

            timerText.text = timer.ToString("F2") + "s";
            timerBar.gameObject.SetActive(true);
            timerBar.fillAmount = timer / timerMax;
            data.killsMax = 1;
            bgBoss.gameObject.SetActive(true);
        }
        else
        {
            data.isBoss = 1;
            stageText.text = "Stage " + data.stage;
            timerText.text = "";
            timerBar.gameObject.SetActive(false);
            timer = 30;
            data.killsMax = 10;
            bgBoss.gameObject.SetActive(false);
        }
    }

    public void Hit()
    {
        health -= data.dph;
        if (health <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        data.money += Ceiling(healthMax / 14);
        if (data.stage == data.stageMax)
        {
            data.kills += 1;
            if (data.kills >= data.killsMax)
            {
                data.kills = 0;
                data.stage += 1;
                data.stageMax += 1;
            }
        }
        IsBossChecker();
        health = healthMax;
        if (data.isBoss > 1) timer = timerMax;
        data.killsMax = 10;
    }

    public void Back()
    {
        data.stage -= 1;
        IsBossChecker();
        health = healthMax;
    }
    public void Forward()
    {
        data.stage += 1;
        IsBossChecker();
        health = healthMax;
    }

    public void BuyUpgrade(string id)
    {
        switch (id)
        {
            case "hero1":
                if (data.money >= heroCost) UpgradeDefaults(ref data.heroLevel, heroCost);
                break;
            case "player1":
                if (data.money >= playerCost) UpgradeDefaults(ref data.playerLevel, playerCost);
                break;
        }
    }

    public void UpgradeDefaults(ref int level, BigDouble cost)
    {
        data.money -= cost;
        level++;
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

    public void SaveOfflineTime()
    {
        PlayerPrefs.SetString("OfflineTime", DateTime.Now.ToBinary().ToString());
        data.OfflineProgressCheck = 1;
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

            var moneyToEarn = Ceiling(healthMax / 14) / healthMax * (data.dps / 5) * IdleTime;
            data.money += moneyToEarn;
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
        data.money += multValueMoney;
        TimerMultMax = new System.Random().Next(5, 10);
        timerMult = TimerMultMax;
        multValue = new System.Random().Next(20, 100);
    }
}

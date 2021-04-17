using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public double money;
    public double dph;
    public double health;
    public double healthMax
    {
        get
        {
            return 10 * System.Math.Pow(2, stage - 1) * isBoss;
        }
    }
    public double reward;

    public float timer;

    public int stage;
    public int stageMax;
    public int kills;
    public int killsMax;
    public int isBoss;
    public int timerMax;

    public Text moneyText;
    public Text dPHText;
    public Text healthText;
    public Text stageText;
    public Text killsText;
    public Text timerText;

    public GameObject back;
    public GameObject forward;

    public Image healthBar;
    public Image timerBar;

    public void Start()
    {
        dph = 1;
        stage = 1;
        stageMax = 1;
        killsMax = 10;
        health = 10;
        isBoss = 1;
        timerMax = 30;
    }

    public void Update()
    {
        moneyText.text = "Gold: " + money.ToString("F2");
        dPHText.text = "Damage Per Hit: " + dph;
        stageText.text = "Stage " + stage;
        killsText.text = kills + "/" + killsMax + " kills";
        healthText.text = health + "/" + healthMax + " HP";

        healthBar.fillAmount = (float)(health / healthMax);

        if (stage > 1) back.gameObject.SetActive(true);
        else
            back.gameObject.SetActive(false);

        if (stage != stageMax) forward.gameObject.SetActive(true);
        else
            forward.gameObject.SetActive(false);

        IsBossChecker();
    }

    public void IsBossChecker()
    {

        if (stage % 5 == 0)
        {
            isBoss = 10;
            stageText.text = "BOSS!";
            killsMax = 1;
            timer = timerMax;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                stage -= 1;
                health = healthMax;
            }
            timerText.text = timer + "/" + timerMax;
            timerBar.gameObject.SetActive(true);
            timerBar.fillAmount = timer / timerMax;
        }
        else
        {
            isBoss = 1;
            stageText.text = "Stage " + stage;
            timerText.text = "";
            timerBar.gameObject.SetActive(false);
        }
    }

    public void Hit()
    {
        health -= dph;
        if (health <= 0)
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
            killsMax = 10;
        }
    }

     public void Back()
     {
         if (stage > 1) stage -= 1;
     }
     public void Forward()
     {
         if (stage != stageMax) stage += 1;
     }
}

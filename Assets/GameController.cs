using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public double money;
    public double dph;
    public double health;
    public double healthMax;
    public int stage;
    public int stageMax;
    public int kills;
    public int killsMax;

    public Text moneyText;
    public Text dPHText;
    public Text healthText;
    public Text stageText;
    public Text killsText;

    public GameObject back;
    public GameObject forward;

    public Image healthBar;

    public void Start()
    {
        dph = 1;
        stage = 1;
        stageMax = 1;
        killsMax = 10;
        healthMax = 10;
        health = healthMax;
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
    }

    public void Hit()
    {
        health -= dph;
        if (health <= 0)
        {
            money += 1;
            health = healthMax;
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
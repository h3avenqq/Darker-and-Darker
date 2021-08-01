using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using BreakInfinity;
using static BreakInfinity.BigDouble;

public class Skill : MonoBehaviour
{
    public string id;

    public BigDouble skillCost;

    public Sprite layerOn;
    public Sprite layerPathOn;

    public GameObject previousSkill;
    public GameObject pathObject;
    public GameObject buyButton;

    public Text costText;
    
    public bool activated;
    public bool isSelected = false;
    public bool isFirst = false;

    private void Start()
    {
        skillCost = SkillList.SkillCost(id);
    }

    private void OnMouseUpAsButton()
    {
        if (!activated)
        {
            costText.text = WordNotation(skillCost,"F0") + " Gems";
            buyButton.GetComponent<BuySkill>().id = id;
        }
    }

    private void Update()
    {
        activated = SkillList.GetSkillCondition(id);
        if (activated)
        {
            GetComponent<SpriteRenderer>().sprite = layerOn;
            SkillList.SkillProperty(id);
            if (!isFirst && previousSkill.GetComponent<Skill>().activated)
            {
                pathObject.GetComponent<SpriteRenderer>().sprite = layerPathOn;
            }
        }
        
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
}

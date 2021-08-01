using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuySkill : MonoBehaviour
{
    public string id;

    private void OnMouseUpAsButton()
    {
        if (GameCtrl.data.gems >= SkillList.SkillCost(id))
        {
            SkillList.SetSkillCondition(id,true);
        }
    }
}

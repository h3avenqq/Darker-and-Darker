using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillList : MonoBehaviour
{
    public string id;

    public void Start()
    {
        id = GetComponent<Skill>().id;
    }

    public void SkillProperty()
    {
        switch (id)
        {
            case "11":
                GameCtrl.data.CriticalChance = 0.15;
                break;
            default:
                Debug.Log("Wrong id");
                break;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using BreakInfinity;
using UnityEngine;

public class SkillList : MonoBehaviour
{
    public static bool skill0 = false;
    public static bool skill11 = false;
    public static bool skill12 = false;
    public static bool skill13 = false;
    public static bool skill21 = false;
    public static bool skill22 = false;
    public static bool skill23 = false;
    public static bool skill31 = false;
    public static bool skill32 = false;
    public static bool skill33 = false;
    
    public static void SkillProperty(string id)
    {
        switch (id)
        {
            case "0":
                break;
            case "11":
                GameCtrl.data.CriticalChance = 15;
                break;
            case "12":
                break;
            case "13":
                break;
            case "21":
                break;
            case "22":
                break;
            case "23":
                break;
            case "31":
                break;
            case "32":
                break;
            case "33":
                break;
            default:
                Debug.Log("Wrong id");
                break;
        }
    }

    public static BigDouble SkillCost(string id)
    {
        switch (id)
        {
            case "0":
                return 2;
            case "11":
                return 2;
            case "12":
                return 2;
            case "13":
                return 2;
            case "21":
                return 2;
            case "22":
                return 2;
            case "23":
                return 2;
            case "31":
                return 2;
            case "32":
                return 2;
            case "33":
                return 2;
            default:
                return 0;
        }
    }

    public static bool GetSkillCondition(string id)
    {
        switch (id)
            {
                case "0":
                    return skill0;
                case "11":
                    return skill11;
                case "12":
                    return skill12;
                case "13":
                    return skill13;
                case "21":
                    return skill21;
                case "22":
                    return skill22;
                case "23":
                    return skill23;
                case "31":
                    return skill31;
                case "32":
                    return skill32;
                case "33":
                    return skill33;
                default:
                    return false;
        }
    }
    
    public static void SetSkillCondition(string id, bool condition)
    {
        switch (id)
        {
            case "0":
                skill0 = condition;
                break;
            case "11":
                skill11 = condition;
                break;
            case "12":
                skill12 = condition;
                break;
            case "13":
                skill13  = condition;
                break;
            case "21":
                skill21 = condition;
                break;
            case "22":
                skill22 = condition;
                break;
            case "23":
                skill23 = condition;
                break;
            case "31":
                skill31 = condition;
                break;
            case "32":
                skill32 = condition;
                break;
            case "33":
                skill33 = condition;
                break;
        }
    }
}

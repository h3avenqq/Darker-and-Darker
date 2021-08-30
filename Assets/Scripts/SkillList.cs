using System;
using System.Collections;
using System.Collections.Generic;
using BreakInfinity;
using UnityEngine;

public class SkillList : MonoBehaviour
{
    //Condition of skill
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
    
    //Skill selected or not
    public static bool skillSelected0 = false;
    public static bool skillSelected11 = false;
    public static bool skillSelected12 = false;
    public static bool skillSelected13 = false;
    public static bool skillSelected21 = false;
    public static bool skillSelected22 = false;
    public static bool skillSelected23 = false;
    public static bool skillSelected31 = false;
    public static bool skillSelected32 = false;
    public static bool skillSelected33 = false;

    //Info about skill
    public static string skillInfo0 = "For a couple of gems, the Gods will give you " +
                                      "the opportunity to strengthen yourself to an incredible level";
    public static string skillInfo11 = "Pay and the Gods will guide your blade to make it stronger\nCritical Chance: 15%";
    public static string skillInfo12 = "Prove your benefits to the Gods and they will give your muscles unprecedented strength" +
                                       "\nCritical Damage: x2";
    public static string skillInfo13 = "Give the Gods what is dear to you and they will help you in battle" +
                                       "\n Double attack every 7 seconds";
    public static string skillInfo21 = "For a couple of gems, the Gods will give you " +
                                       "the opportunity to strengthen your aliies to an incredible level";
    public static string skillInfo22 = "Pay and the Gods will guide your allied blades to make it stronger\nCritical Chance: 15%";
    public static string skillInfo23 = "Give the Gods what is dear to you and they will help your allies in battle";
    public static string skillInfo31 = "Info about this skill";
    public static string skillInfo32 = "Info about this skill";
    public static string skillInfo33 = "Info about this skill";
    
    
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
                GameCtrl.data.CriticalDamage = 2;
                break;
            case "13":
                GameCtrl.data.DoubleAttack = true;
                break;
            case "21":
                GameCtrl.data.CriticalChanceHero = 15;
                break;
            case "22":
                GameCtrl.data.CriticalDamageHero = 2;
                break;
            case "23":
                GameCtrl.data.DoubleAttackHero = true;
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

    public static void SelectedSwitcher(string id)
    {
        switch (id)
        {
            case "0":
                skillSelected0 = true;
                skillSelected11 = false;
                skillSelected12 = false;
                skillSelected13 = false;
                skillSelected21 = false;
                skillSelected22 = false;
                skillSelected23 = false;
                skillSelected31 = false;
                skillSelected32 = false;
                skillSelected33 = false;
                break;
            case "11":
                skillSelected0 = false;
                skillSelected11 = true;
                skillSelected12 = false;
                skillSelected13 = false;
                skillSelected21 = false;
                skillSelected22 = false;
                skillSelected23 = false;
                skillSelected31 = false;
                skillSelected32 = false;
                skillSelected33 = false;
                break;
            case "12":
                skillSelected0 = false;
                skillSelected11 = false;
                skillSelected12 = true;
                skillSelected13 = false;
                skillSelected21 = false;
                skillSelected22 = false;
                skillSelected23 = false;
                skillSelected31 = false;
                skillSelected32 = false;
                skillSelected33 = false;
                break;
            case "13":
                skillSelected0 = false;
                skillSelected11 = false;
                skillSelected12 = false;
                skillSelected13 = true;
                skillSelected21 = false;
                skillSelected22 = false;
                skillSelected23 = false;
                skillSelected31 = false;
                skillSelected32 = false;
                skillSelected33 = false;
                break;
            case "21":
                skillSelected0 = false;
                skillSelected11 = false;
                skillSelected12 = false;
                skillSelected13 = false;
                skillSelected21 = true;
                skillSelected22 = false;
                skillSelected23 = false;
                skillSelected31 = false;
                skillSelected32 = false;
                skillSelected33 = false;
                break;
            case "22":
                skillSelected0 = false;
                skillSelected11 = false;
                skillSelected12 = false;
                skillSelected13 = false;
                skillSelected21 = false;
                skillSelected22 = true;
                skillSelected23 = false;
                skillSelected31 = false;
                skillSelected32 = false;
                skillSelected33 = false;
                break;
            case "23":
                skillSelected0 = false;
                skillSelected11 = false;
                skillSelected12 = false;
                skillSelected13 = false;
                skillSelected21 = false;
                skillSelected22 = false;
                skillSelected23 = true;
                skillSelected31 = false;
                skillSelected32 = false;
                skillSelected33 = false;
                break;
            case "31":
                skillSelected0 = false;
                skillSelected11 = false;
                skillSelected12 = false;
                skillSelected13 = false;
                skillSelected21 = false;
                skillSelected22 = false;
                skillSelected23 = false;
                skillSelected31 = true;
                skillSelected32 = false;
                skillSelected33 = false;
                break;
            case "32":
                skillSelected0 = false;
                skillSelected11 = false;
                skillSelected12 = false;
                skillSelected13 = false;
                skillSelected21 = false;
                skillSelected22 = false;
                skillSelected23 = false;
                skillSelected31 = false;
                skillSelected32 = true;
                skillSelected33 = false;
                break;
            case "33":
                skillSelected0 = false;
                skillSelected11 = false;
                skillSelected12 = false;
                skillSelected13 = false;
                skillSelected21 = false;
                skillSelected22 = false;
                skillSelected23 = false;
                skillSelected31 = false;
                skillSelected32 = false;
                skillSelected33 = true;
                break;
        }
    }

    public static bool GetSkillSelected(string id)
    {
        switch (id)
        {
            case "0":
                return skillSelected0;
            case "11":
                return skillSelected11;
            case "12":
                return skillSelected12;
            case "13":
                return skillSelected13;
            case "21":
                return skillSelected21;
            case "22":
                return skillSelected22;
            case "23":
                return skillSelected23;
            case "31":
                return skillSelected31;
            case "32":
                return skillSelected32;
            case "33":
                return skillSelected33;
            default:
                return false;
        }
    }

    public static string GetInfoSkill(string id)
    {
        switch (id)
        {
            case "0":
                return skillInfo0;
            case "11":
                return skillInfo11;
            case "12":
                return skillInfo12;
            case "13":
                return skillInfo13;
            case "21":
                return skillInfo21;
            case "22":
                return skillInfo22;
            case "23":
                return skillInfo23;
            case "31":
                return skillInfo31;
            case "32":
                return skillInfo32;
            case "33":
                return skillInfo33;
            default:
                return "wrong id";
        }
    }
}

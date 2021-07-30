using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPosition : MonoBehaviour
{
    public static bool pos1 = false;
    public static bool pos2 = false;
    public static bool pos3 = false;

    public static void Switcher(string id)
    {
        switch (id)
        {//надо бы придумать нормальные названия для кнопок
            case "sword":
                pos1 = true;
                pos2 = false;
                pos3 = false;
                break;
            case "book":
                pos1 = false;
                pos2 = true;
                pos3 = false;
                break;
            case "dick":
                pos1 = false;
                pos2 = false;
                pos3 = true;
                break;
            default:
                pos1 = false;
                pos2 = false;
                pos3 = false;
                break;
        }
    }
}

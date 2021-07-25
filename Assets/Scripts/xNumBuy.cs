using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class xNumBuy : MonoBehaviour
{
    public string id;
    public static int xButton = 1;
    public static int xButtonHero1 = 1;
    public static int xButtonHero2 = 1;
    public static int xButtonHero3 = 1;
    public static bool x1 = true;
    public static bool x10 = false;
    public static bool x100 = false;
    public static bool xMax = false;


    public void OnMouseUpAsButton()
    {
        switch(id)
        {
            case "x1":
                Switcher(id);
                xButton = 1;
                break;
            case "x10":
                Switcher(id);
                xButton = 10;
                break;
            case "x100":
                Switcher(id);
                xButton = 100;
                break;
            case "Max":
                Switcher(id);
                xButton = -1;
                break;
        }
    }

    public static void Switcher(string id)
    {
        switch(id)
        {
            case "x1":
                x1 = true;
                x10 = false;
                x100 = false;
                xMax = false;
                break;
            case "x10":
                x1 = false;
                x10 = true;
                x100 = false;
                xMax = false;
                break;
            case "x100":
                x1 = false;
                x10 = false;
                x100 = true;
                xMax = false;
                break;
            case "Max":
                x1 = false;
                x10 = false;
                x100 = false;
                xMax = true;
                break;
        }
    }
}



using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using BreakInfinity;
using static BreakInfinity.BigDouble;

public class SettingsList : MonoBehaviour
{
    public static TMP_InputField usernameInput;
    public Text usernameText;
    public GameObject usernameBox;
    public static void UsernameChange()
    {
        GameCtrl.data.username = usernameInput.text;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public string id;
    public GameObject close;
    public void OnMouseUpAsButton()
    {
        switch (id)
        {
            case "username":
                SettingsList.UsernameChange();
                break;
        }
    }
    
}

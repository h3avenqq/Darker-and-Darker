using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public GameObject close;

    public void OnMouseUpAsButton()
    {
        close.SetActive(false);
    }
}

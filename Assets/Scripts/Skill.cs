using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public string id;
    
    public GameObject previousSkill;

    public bool activated;
    public bool isFirst = false;

    private void OnMouseUpAsButton()
    {
        if (isFirst)
        {
            activated = true;
            Debug.Log(id + " activated");
        }
        else if (previousSkill.GetComponent<Skill>().activated)
        {
            activated = true;
            Debug.Log(id + " activated");
        }
        else
        {
            Debug.Log(previousSkill.name + " not activated");
        }
    }
}

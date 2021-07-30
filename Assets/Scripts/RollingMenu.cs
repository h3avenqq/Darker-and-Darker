using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingMenu : MonoBehaviour
{
    public string id;
    public float speed;
    public GameObject rollingMenu;
    public Vector3 target;//-3.012618
    public Vector3 start;//-7.9653

    private bool pos
    {
        get
        {
            switch (id)
            {
                case "sword":
                    return MenuPosition.pos1;
                    break;
                case "book":
                    return MenuPosition.pos2;
                    break;
                case "dick":
                    return MenuPosition.pos3;
                default:
                    return false;
            }
        }
    }

    public void OnMouseUpAsButton()
    {
        if (!pos)
        {
            MenuPosition.Switcher(id);
        }
        else
        {
            MenuPosition.Switcher("false");
        }
    }

    public void Update()
    {
         if(pos)
         {
            rollingMenu.transform.position = Vector3.Lerp(rollingMenu.transform.position, target, speed*Time.deltaTime);
         }
         else
         {
             rollingMenu.transform.position = Vector3.Lerp(rollingMenu.transform.position, start, speed*Time.deltaTime);
         }
    }
       
}

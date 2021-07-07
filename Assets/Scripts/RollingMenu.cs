using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingMenu : MonoBehaviour
{
    public float speed;
    public GameObject rollingMenu;
    public Vector3 target;//-3.012618
    public Vector3 start;//-7.9653
    
    private bool pos = false;

    public void OnMouseUpAsButton()
    {
        pos=!pos;
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

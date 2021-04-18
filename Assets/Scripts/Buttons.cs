using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public string action;
    public Sprite layer_on, layer_off;

    private void OnMouseDown() {
        GetComponent <SpriteRenderer>().sprite = layer_on;
    }

    private void OnMouseUp() {
        GetComponent <SpriteRenderer>().sprite = layer_off;
    }
    private void OnMouseUpAsButton()
    {
        switch(action){
            case "Play":
            
            break;
            case "Ads":

            break;
            case "Settings":

            break;
        }
    }
}

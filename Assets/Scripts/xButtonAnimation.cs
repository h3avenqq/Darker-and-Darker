using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xButtonAnimation : MonoBehaviour
{
    public GameObject x1Button;
    public GameObject x10Button;
    public GameObject x100Button;
    public GameObject xMaxButton;

    public Sprite layer_on; 
    public Sprite layer_off;

    public void Update()
    {
        if(xNumBuy.x1)
        {
            x1Button.GetComponent <SpriteRenderer>().sprite = layer_on;
            x10Button.GetComponent <SpriteRenderer>().sprite = layer_off;
            x100Button.GetComponent <SpriteRenderer>().sprite = layer_off;
            xMaxButton.GetComponent <SpriteRenderer>().sprite = layer_off;
        }
        else if(xNumBuy.x10)
        {
            x1Button.GetComponent <SpriteRenderer>().sprite = layer_off;
            x10Button.GetComponent <SpriteRenderer>().sprite = layer_on;
            x100Button.GetComponent <SpriteRenderer>().sprite = layer_off;
            xMaxButton.GetComponent <SpriteRenderer>().sprite = layer_off;
        }
        else if(xNumBuy.x100)
        {
            x1Button.GetComponent <SpriteRenderer>().sprite = layer_off;
            x10Button.GetComponent <SpriteRenderer>().sprite = layer_off;
            x100Button.GetComponent <SpriteRenderer>().sprite = layer_on;
            xMaxButton.GetComponent <SpriteRenderer>().sprite = layer_off;
        }
        else
        {
            x1Button.GetComponent <SpriteRenderer>().sprite = layer_off;
            x10Button.GetComponent <SpriteRenderer>().sprite = layer_off;
            x100Button.GetComponent <SpriteRenderer>().sprite = layer_off;
            xMaxButton.GetComponent <SpriteRenderer>().sprite = layer_on;
        }
    }
}

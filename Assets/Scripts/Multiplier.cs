using UnityEngine;
using System.Collections;

public class Multiplier : MonoBehaviour
{
    public void Update()
    {
        if(!GameCtrl.data.MoneyMultiplyCondition)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnMouseUpAsButton()
    {
        GameCtrl.data.money += 1000*GameCtrl.data.stage*GameCtrl.data.MoneyMultiply;
        GameCtrl.data.MoneyMultiplyCondition = false;
    }
    
}

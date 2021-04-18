using UnityEngine;
using System.Collections;

public class MoonMove : MonoBehaviour
{
    public float speed = 0.4f;
    private Vector3 target = new Vector3(0.247363f, 3f, 0);
    //0.247363f, 3f, 7.31f
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
		if(transform.position == target && target.y == 3f)target.y = 3.107063f;
        else if (transform.position == target && target.y != 3f)target.y = 3f;
    }

}


using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System;
using TMPro;
using BreakInfinity;
using static BreakInfinity.BigDouble;

public class GameCtrl : MonoBehaviour
{
    public int stage;
    public int stageMax;
    public int i;//хз почему паблик, но эта херь для выборки моба которого нужно заспавнить
    
    public static BigDouble dph = 1;

    public GameObject[] enemy = new GameObject[2];
    public GameObject EnemyToSpawn;

    private void Start()
    {
        Spawn();
    }
    
    private void Update()
    {
        if(Enemy.health <=0)
        {
            Kill();
            Spawn();
        }
    }

    public void Spawn()
    {
        EnemySelector();
        Instantiate(EnemyToSpawn,EnemyToSpawn.transform.position, Quaternion.identity);
    }

    public void Kill()
    {
        //Destroy(EnemyToSpawn);
        Enemy.wtf();
    }

    public void EnemySelector()
    {
        int i = Random.Range(0,2);//сделай нормально а не так по хуйне
        EnemyToSpawn = enemy[i];
    }

}

    
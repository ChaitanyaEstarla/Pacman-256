﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private const int EnemyNumbers = 5;
    
    private List<GameObject> _enemies = new List<GameObject>();
    
    private GameObject[] _enemyResource;

    public PacmanMovement pacMan;
    
    private void Start()
    {
        _enemyResource = new GameObject[EnemyNumbers];
        
        var inky    = (GameObject) Instantiate(Resources.Load("Inky"));
        _enemyResource[0] = inky;
        var blinky  = (GameObject) Instantiate(Resources.Load("Blinky"));
        _enemyResource[1] = blinky;
        var pinky   = (GameObject) Instantiate(Resources.Load("Pinky"));
        _enemyResource[2] = pinky;
        var clyde   = (GameObject) Instantiate(Resources.Load("Clyde"));
        _enemyResource[3] = clyde;
        var sue     = (GameObject) Instantiate(Resources.Load("Sue"));
        _enemyResource[4] = sue;

        foreach (var enemy in _enemyResource)
        {
            InstantiateEnemies(enemy);
        }
        
        foreach (var enemy in _enemyResource)
        {
            Destroy(enemy);
        }
    }

    private void InstantiateEnemies(GameObject enemyResource)
    {
        var enemy = Instantiate(enemyResource, transform);
        
        _enemies.Add(enemy);
        //enemy.SetActive(false);
    }
}

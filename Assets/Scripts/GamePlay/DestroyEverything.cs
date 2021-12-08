﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DestroyEverything : MonoBehaviour
{
    public float speed;
    public float waitBeforeDestroyingEverything;
    public GridManager gridManager;
    public PacmanMovement pacManMovement;

    private int _position = 10;

    private void Start()
    {
    }

    private void Update()
    {
        StartCoroutine(StartMoving());
        if (transform.position.y >= _position)
        {
            _position += 10;
            gridManager.MoveTileChunk();
            pacManMovement.UpdateDictionary();
        }

        //Don't want the destroyer to go backwards
        if (speed < 1)
        {
            speed = 1;
        }
        //This prevents the huge gap made between player and the destroyer
        if (pacManMovement.transform.position.y - gameObject.transform.position.y >= 30)
        {
            speed = 5;
        }//If it's too close then get it back to normal speed
        if (pacManMovement.transform.position.y - gameObject.transform.position.y <= 20)
        {
            speed = 1;
        }
    }
    
    //Starts moving after a short period.
    private IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(waitBeforeDestroyingEverything);
        
        GetComponentInChildren<ParticleSystem>().Play();
        transform.Translate(0,1 * Time.deltaTime * speed,0);
    }
}

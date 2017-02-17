﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBehavior : MonoBehaviour {

    private bool open = false;
    private int index = 0;
    private List<GameObject> checkPoints;
    private GameObject compass;

    private void OnTriggerEnter(Collider other)
    {
        //Player collided with the checkpoint and it is open
        if (open == true && other.CompareTag("Player"))
        {
            print("Checkpoint gained: " + index);

            //TODO some animation

            //close this checkpoint
            SetOpen(false);
            
            //if there are more checkpoints
            if(index + 1 < checkPoints.Count)
            {
                //open the next checkpoint
                checkPoints[index + 1].GetComponent<CheckPointBehavior>().SetOpen(true);
                compass.GetComponent<Compass>().SetTarget(checkPoints[index + 1]);
            }

            else
            {
                //TODO FINISHED GAME
                print("Game complete!");
            }
        }
    }

    public void SetOpen(bool open)
    {
        this.open = open;
    }

    public void SetIndex(int index)
    {
        this.index = index;
    }

    public void SetCheckPointList(List<GameObject> checkPoints)
    {
        this.checkPoints = checkPoints;
    }

    public void SetCompass(GameObject compass)
    {
        this.compass = compass;
    }
}
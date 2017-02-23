using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBehavior : MonoBehaviour {

    private bool open = false;
    private int index = 0;
    private List<GameObject> checkPoints;
    private GameObject compass;
    private GameObject compass_mini;

    private AudioSource audio;

    private void OnTriggerEnter(Collider other)
    {
        //Player collided with the checkpoint and it is open
        if (open == true && other.CompareTag("Player"))
        {

            audio = GetComponent<AudioSource>();
            audio.Play();

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
                compass_mini.GetComponent<Compass>().SetTarget(checkPoints[index + 1]);
            }

            else
            {
                //TODO FINISHED GAME
                print("Game complete!");
                GameObject.Find("Timer").GetComponent<Timer>().EndGame();
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

    public void SetCompassMini(GameObject compass_mini)
    {
        this.compass_mini = compass_mini;
    }
}

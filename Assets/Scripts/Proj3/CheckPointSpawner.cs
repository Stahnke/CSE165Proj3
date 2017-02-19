using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSpawner : MonoBehaviour {

    public GameObject XYZParser;

    public GameObject checkPoint_prefab;

    public List<GameObject> checkPoints = new List<GameObject>();

    public GameObject compass;
    public GameObject compass_mini;

    //INIT
	void Start () {

        //Get positions from our file
		List<Vector3> positions = XYZParser.GetComponent<XYZParser>().Parse("Sample-track.txt");
        //Spawn our positions
        Spawn(positions);
	}

    void Spawn(List<Vector3> positions)
    {
        for(int i = 0; i < positions.Count; i++)
        {
            //Spawn the current checkpoint
            GameObject checkPoint = Instantiate(checkPoint_prefab, positions[i], Quaternion.identity) as GameObject;
            //add to our list of checkpoints
            checkPoints.Add(checkPoint);
            checkPoint.GetComponent<CheckPointBehavior>().SetIndex(i);
            checkPoint.GetComponent<CheckPointBehavior>().SetOpen(false);
        }

        //Set up the checkpoint parameters for the game's initial settings
        SetUpCheckPointParameters();
    }

    void SetUpCheckPointParameters()
    {
        //If we have at least 2 checkpoints, begin
        if(checkPoints.Count >= 2)
        {
            //Set our second checkpoint to "on" (or open)
            checkPoints[1].GetComponent<CheckPointBehavior>().SetOpen(true);
            compass.GetComponent<Compass>().SetTarget(checkPoints[1]);
            compass_mini.GetComponent<Compass>().SetTarget(checkPoints[1]);
        }

        //Else throw an exception
        else
        {
            print("Not enough checkpoints to play.");
        }

        for(int i = 0; i < checkPoints.Count; i++)
        {
            checkPoints[i].GetComponent<CheckPointBehavior>().SetCheckPointList(checkPoints);
            checkPoints[i].GetComponent<CheckPointBehavior>().SetCompass(compass);
            checkPoints[i].GetComponent<CheckPointBehavior>().SetCompassMini(compass_mini);
        }
    }
}

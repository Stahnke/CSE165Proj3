using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainWorldRotation2 : MonoBehaviour {

    private float x;
    private float y;
    private float z;

    public float xRot = 0;
    public float yRot = 0;
    public float zRot = 0;

    public bool xLock = false;
    public bool yLock = false;
    public bool zLock = false;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        x = gameObject.transform.eulerAngles.x;
        y = gameObject.transform.eulerAngles.y;
        z = gameObject.transform.eulerAngles.z;

        if (xLock) x = xRot;
        if (yLock) y = yRot;
        if (zLock) z = zRot;

        gameObject.transform.rotation = Quaternion.Euler(new Vector3(x,y,z));
	}
}

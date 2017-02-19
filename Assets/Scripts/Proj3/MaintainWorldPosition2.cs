using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainLocalPosition2 : MonoBehaviour {

    private float x;
    private float y;
    private float z;

    public float xPos = 0;
    public float yPos = 0;
    public float zPos = 0;

    public bool xLock = false;
    public bool yLock = false;
    public bool zLock = false;

    private bool selected = false;

    private void Start()
    {
        xPos = gameObject.transform.localPosition.x;
        yPos = gameObject.transform.localPosition.y;
        zPos = gameObject.transform.localPosition.z;
    }
	
	// Update is called once per frame
	void Update () {

        x = gameObject.transform.localPosition.x;
        y = gameObject.transform.localPosition.y;
        z = gameObject.transform.localPosition.z;

        if (xLock) x = xPos;
        if (yLock) y = yPos;
        if (zLock) z = zPos;

        gameObject.transform.localPosition = new Vector3(x, y, z);

	}

    public void SendSelected(bool selected)
    {
        this.selected = selected;
    }
}

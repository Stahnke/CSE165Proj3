using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour {

    private GameObject target;
    public GameObject source;
    private int dist;
    public Text dist_text;

    public float scaleFactor = 1.0f;
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.LookAt(target.transform);
        dist = (int)((Vector3.Distance(target.transform.position, source.transform.position) / 12) / scaleFactor);
        dist_text.text = dist + "ft";
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
}

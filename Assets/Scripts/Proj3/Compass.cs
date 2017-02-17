using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour {

    private GameObject target;
    private int dist;
    public Text dist_text;
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.LookAt(target.transform);
        dist = (int)(Vector3.Distance(target.transform.position, gameObject.transform.position) / 12);
        dist_text.text = dist + "ft";
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
}

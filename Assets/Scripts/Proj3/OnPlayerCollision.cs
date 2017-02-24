using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerCollision : MonoBehaviour {

    public GameObject timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("campusBuilding"))
        {
            print("PLAYER COLLIDED");
            timer.GetComponent<Timer>().CountDownBegin(3, false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private bool moving;

    public void StartMoving()
    {

        print("Start Moving");
        moving = true;
    }

    public void StopMoving()
    {
        print("Stopped Moving");
        moving = false;
    }

    public void Update()
    {
        if (moving)
        {
            float speed = 5.0f;

            float x = 0.0f;
            float y = 0.0f;
            float z = Time.deltaTime * 3.0f * speed;

            Vector3 movement = new Vector3(x, y, z);
            transform.Translate(movement);
        }
    }
}

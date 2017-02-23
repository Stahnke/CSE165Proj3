using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private bool moving;

    private bool movement_unlock = false;

    public float speed;

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
        if (moving && movement_unlock)
        {

            float x = 0.0f;
            float y = 0.0f;
            float z = Time.deltaTime * 3.0f * speed;

            Vector3 movement = new Vector3(x, y, z);
            transform.Translate(movement);
        }
    }

    public void LockUnlockMovement(bool movement_unlock)
    {
       this.movement_unlock = movement_unlock;
    }
}

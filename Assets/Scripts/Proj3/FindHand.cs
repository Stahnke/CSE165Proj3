using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap;

public class FindHand : MonoBehaviour {

    public LeapProvider provider;

    public Hand hand;

    public float speed;

    private bool rotateOn = false;

    public void TurnOn()
    {
        rotateOn = true;
    }

    public void TurnOff()
    {
        rotateOn = false;
    }

    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
    }
    void Update()
    {
        Frame frame = provider.CurrentFrame;
        foreach (Hand hand in frame.Hands)
        {
            if (hand.IsLeft && rotateOn == true)
            {
                this.hand = hand;
                float x = hand.Direction.x;
                float y = hand.Direction.y;
                float z = hand.Direction.z;

                Vector3 targetDir = new Vector3(x, y, z);
                float step = speed * Time.deltaTime;

                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
                Debug.DrawRay(transform.position, newDir, Color.red);
                transform.rotation = Quaternion.LookRotation(newDir);
            }
        }
    }
}

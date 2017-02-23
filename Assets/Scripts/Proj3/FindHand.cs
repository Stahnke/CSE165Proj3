using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap;

public class FindHand : MonoBehaviour {

    public LeapProvider provider;

    public Hand hand;

    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
    }
    void Update()
    {
        Frame frame = provider.CurrentFrame;
        foreach (Hand hand in frame.Hands)
        {
            if (hand.IsLeft)
            {
                //this.hand = hand;
                transform.position = hand.PalmPosition.ToVector3()
               +
                hand.PalmNormal.ToVector3() *
                (transform.localScale.y * .5f + .02f);
                //transform.rotation = hand.Basis.Rotation();
            }
        }
    }
}

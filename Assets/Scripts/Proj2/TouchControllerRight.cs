﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControllerRight : MonoBehaviour
{

    public OVRInput.Controller controller;
    public GameObject rayCaster2;
    public GameObject virtualHand;

    // Update is called once per frame
    void Update()
    {

        transform.localPosition = OVRInput.GetLocalControllerPosition(controller);
        transform.localRotation = OVRInput.GetLocalControllerRotation(controller);

        if (controller == OVRInput.Controller.RTouch)
        {
            if (OVRInput.GetDown(OVRInput.Button.One, controller))
            {
                print(controller.ToString() + ": One");
                rayCaster2.GetComponent<RayCaster2>().Launch();
            }

            if (OVRInput.GetDown(OVRInput.Button.Two, controller))
            {
                print(controller.ToString() + ": Two");
                virtualHand.GetComponent<VirtualHand>().Launch();
            }

            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller) > 0)
            {
                
            }

            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller) <= 0)
            {
                
                //print(controller.ToString() + ": Trigger off");
            }

            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller) > 0)
            {
                rayCaster2.GetComponent<RayCaster2>().GroupingOnOff(true);
                //print(controller.ToString() + ": Grip on");
            }

            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller) <= 0)
            {
                rayCaster2.GetComponent<RayCaster2>().GroupingOnOff(false);
                //print(controller.ToString() + ": Grip off");
            }
        }
    }
}

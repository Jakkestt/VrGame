using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomGrab : MonoBehaviour
{
    // This script should be attached to both controller objects in the scene
    // Make sure to define the input in the editor (LeftHand/Grip and RightHand/Grip recommended respectively)
    private List<Collider> nearObjects = new List<Collider>();
    private Transform grabbedObject = null;
    private Rigidbody rb = null;
    private bool ball = false;
    public Transform hand_offset;
    public RacketScript racket;

    ActionBasedController controller;
    bool grabbing = false;

    private void Start()
    {
        controller = GetComponent<ActionBasedController>();
    }

    void Update()
    {
        grabbing = (controller.selectAction.action.ReadValue<float>() == 1f && controller.activateAction.action.ReadValue<float>() == 1f) || grabbedObject != null;
        if (grabbing)
        {
            // Grab nearby object or the object in the other hand
            if (!grabbedObject && nearObjects.Count > 0)
            {
                Collider t = nearObjects[0];
                rb = t.attachedRigidbody;
                grabbedObject = t.transform;
                rb.useGravity = false;
                if (t.tag.ToLower() == "ball")
                {
                    ball = true;
                }
                racket.SetGrabbed(true);
            }

            if (grabbedObject)
            {
                // Change these to add the delta position and rotation instead
                // Save the position and rotation at the end of Update function, so you can compare previous pos/rot to current here
                //Quaternion rot;
                //rot = (transform.rotation * Quaternion.Inverse(rotation));
                //grabbedObject.rotation = rot * grabbedObject.rotation;
                //grabbedObject.position += (transform.position - position);
                //Vector3 vector3 = grabbedObject.position - transform.position;
                //grabbedObject.position = transform.position;
                //grabbedObject.position += (transform.rotation * Quaternion.Inverse(rotation)) * vector3;
                Transform offset = grabbedObject.GetChild(0).transform;
                grabbedObject.rotation = Quaternion.LookRotation(hand_offset.forward, hand_offset.up);
                grabbedObject.position = transform.position + (grabbedObject.position - offset.position);
            }
        }
        // If let go of button, release object
        else if (grabbedObject) {
            if (!ball)
            {
                rb.useGravity = true;
                grabbedObject = null;
                rb = null;
            } else
            {
                grabbedObject = null;
                rb = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Make sure to tag grabbable objects with the "grabbable" tag
        // You also need to make sure to have colliders for the grabbable objects and the controllers
        // Make sure to set the controller colliders as triggers or they will get misplaced
        // You also need to add Rigidbody to the controllers for these functions to be triggered
        // Make sure gravity is disabled though, or your controllers will (virtually) fall to the ground

        if (other && (other.tag.ToLower() == "grabbable" || other.tag.ToLower() == "ball"))
            nearObjects.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other && other.tag.ToLower() == "grabbable")
            nearObjects.Remove(other);
    }
}
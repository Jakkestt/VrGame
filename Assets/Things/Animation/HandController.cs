using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]
public class HandController : MonoBehaviour
{
    // Start is called before the first frame update
    ActionBasedController controller;
    public Hand hand;

    void Start()
    {
        controller = GetComponent<ActionBasedController>();
    }

    // Update is called once per frame
    void Update()
    {
        hand.SetGrip(controller.selectActionValue.action.ReadValue<float>());
        hand.SetTrigger(controller.activateActionValue.action.ReadValue<float>());
    }
}

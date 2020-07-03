using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class DeviceAssignmentControls : MonoBehaviour
{
    [SerializeField] PlayerInput input;
    [SerializeField] TextMeshProUGUI text;
    DeviceAssignment assignment;
    public bool ready { get; private set; }
    public PlayerInput Input { get => input; }

    public void SetDeviceAssignment(DeviceAssignment ass)
    {
        assignment = ass;
    }
    
    public void OnReady(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            text.text = "ready";
            ready = true;
            assignment.CheckReadiness();
        }
    }
}

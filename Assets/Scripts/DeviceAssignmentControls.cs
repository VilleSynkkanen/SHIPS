using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class DeviceAssignmentControls : MonoBehaviour
{
    [SerializeField] PlayerInput input;
    [SerializeField] ShipSelection selection;
    DeviceAssignment assignment;

    public int plrIndex { get; private set; }
    public bool ready { get; private set; }
    public PlayerInput Input { get => input; }
    public ShipSelection Selection { get => selection; }

    public void SetDeviceAssignment(DeviceAssignment ass, int playerIndex)
    {
        assignment = ass;
        plrIndex = playerIndex;
        selection.SetUI(playerIndex);
    }
    
    public void OnReady(InputAction.CallbackContext context)
    {
        if(context.started && !ready)
        {
            selection.SetPlayerText("P" + (plrIndex + 1).ToString() + " READY");
            ready = true;
            assignment.CheckReadiness();
        }
    }
    public void OnNext(InputAction.CallbackContext context)
    {
        if (context.started && !ready)
        {
            Selection.NextShip();
        }
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
        if (context.started && !ready)
        {
            Selection.PreviousShip();
        }
    }

    public void OnUnready(InputAction.CallbackContext context)
    {
        if (context.started && ready)
        {
            selection.SetPlayerText("P" + (plrIndex + 1).ToString() + " JOINED");
            ready = false;
        }
        else if(context.started && !ready)
        {
            input.user.UnpairDevices();
            assignment.RemoveDevice(this);
        }
    }
}

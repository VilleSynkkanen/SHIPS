using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class DeviceAssignmentControls : MonoBehaviour
{
    [SerializeField] PlayerInput input;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] RectTransform rectTrans;
    DeviceAssignment assignment;
    ShipSelection selection;
    public int plrIndex { get; private set; }
    public bool ready { get; private set; }
    public PlayerInput Input { get => input; }
    public ShipSelection Selection { get => selection; }

    private void Awake()
    {
        selection = GetComponent<ShipSelection>();
    }

    public void SetDeviceAssignment(DeviceAssignment ass, int playerIndex)
    {
        assignment = ass;
        plrIndex = playerIndex;
        SetUIPosition(playerIndex);
    }
    
    public void OnReady(InputAction.CallbackContext context)
    {
        if(context.started && !ready)
        {
            text.text = "P" + (plrIndex + 1).ToString() + " READY";
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
            text.text = "P" + (plrIndex + 1).ToString() + " JOINED";
            ready = false;
        }
        else if(context.started && !ready)
        {
            input.user.UnpairDevices();
            assignment.RemoveDevice(this);
        }
    }

    void SetUIPosition(int i)       // clean up
    {
        Vector2 pivot;
        Vector3 position = Vector3.zero;
        Vector2 anchorMin;
        Vector2 anchorMax;
        
        if(i == 0)
        {
            pivot = Vector2.zero;
            anchorMin = Vector2.zero;
            anchorMax = Vector2.zero;
        }
        else if(i == 1)
        {
            pivot = Vector2.right;
            anchorMin = Vector2.right;
            anchorMax = Vector2.right;
        }
        else if (i == 2)
        {
            pivot = Vector2.up;
            anchorMin = Vector2.up;
            anchorMax = Vector2.up;
        }
        else
        {
            pivot = Vector2.right + Vector2.up;
            anchorMin = Vector2.right + Vector2.up;
            anchorMax = Vector2.right + Vector2.up;
        }

        rectTrans.pivot = pivot;
        rectTrans.position = position;
        rectTrans.anchorMin = anchorMin;
        rectTrans.anchorMax = anchorMax;

        text.text = "P" + (plrIndex + 1).ToString() + " JOINED";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DeviceAssignmentControls : MonoBehaviour
{
    [SerializeField] PlayerInput input;
    [SerializeField] ShipSelection selection;
    [SerializeField] GameObject player2Prefab;
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
        if (context.started && !ready)
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
        else if (context.started && !ready)
        {
            if(input.currentControlScheme == "Keyboard" && assignment.plr2Joined && assignment.plr2 != this)
            {
                if(assignment.plr2.ready)
                    assignment.plr2.OnUnready(context);
                assignment.plr2.OnUnready(context);
            }
            
            input.user.UnpairDevices();
            assignment.RemoveDevice(this);
        }
    }

    public void OnPlayer2Join(InputAction.CallbackContext context)
    {
        if (context.started && !assignment.plr2Joined)
        {
            PlayerInput player = PlayerInput.Instantiate(player2Prefab, -1, null, -1, Keyboard.current);
            player.SwitchCurrentControlScheme("KeyboardSecondary");
            assignment.plr2Joined = true;
            assignment.plr2 = player.GetComponent<DeviceAssignmentControls>();
        }
    }

    public void OnQuit(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void Player2Disconnected()
    {
        assignment.plr2Joined = false;
    }

    public void SetIndex(int i)
    {
        plrIndex = i;
    }
}

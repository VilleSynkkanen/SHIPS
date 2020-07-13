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
    public static bool plr2Joined;

    public int plrIndex { get; private set; }
    public bool ready { get; private set; }
    public PlayerInput Input { get => input; }
    public ShipSelection Selection { get => selection; }

    private void Awake()
    {
        plr2Joined = false;
    }

    public void SetDeviceAssignment(DeviceAssignment ass, int playerIndex)
    {
        assignment = ass;
        plrIndex = playerIndex;
        selection.SetUI(playerIndex);
    }
    
    public void OnThrottle(InputAction.CallbackContext context)
    {
        if(context.ReadValue<float>() > 0)
        {
            if (context.started && !ready)
            {
                selection.SetPlayerText("P" + (plrIndex + 1).ToString() + " READY");
                ready = true;
                assignment.CheckReadiness();
            }
        }
        else
        {
            if (context.started && ready)
            {
                selection.SetPlayerText("P" + (plrIndex + 1).ToString() + " JOINED");
                ready = false;
            }
            else if (context.started && !ready)
            {
                input.user.UnpairDevices();
                assignment.RemoveDevice(this);
            }
        }
    }
    public void OnSteering(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() > 0)
        {
            if (context.started && !ready)
            {
                Selection.NextShip();
            }
        }
        else
        {
            if (context.started && !ready)
            {
                Selection.PreviousShip();
            }
        }   
    }

    public void OnPlayer2Join(InputAction.CallbackContext context)
    {
        if (context.started && !plr2Joined)
        {
            PlayerInput player = PlayerInput.Instantiate(player2Prefab, -1, null, -1, Keyboard.current);
            player.SwitchCurrentControlScheme("KeyboardSecondary");
            plr2Joined = true;
        }
    }

    public void OnQuit(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void Player2Disconnected()
    {
        plr2Joined = false;
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlInput : MonoBehaviour
{
    //PlayerControls controls;
    public float horizontal { get; private set; }
    public float vertical { get; private set; }
    public bool shootLeft { get; private set; }
    public bool shootRight { get; private set; }
    public bool shootForward { get; private set; }
    public bool mine { get; private set; }
    public float aim { get; private set; }

    bool quitting;

    void Awake()
    {
        quitting = false;
    }

    public void OnThrottle(InputAction.CallbackContext context)
    {
        vertical = context.ReadValue<float>();
    }

    public void OnSteering(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<float>();
    }

    public void OnShootLeft(InputAction.CallbackContext context)
    {
        if(context.performed)
            shootLeft = true;
        else if (context.canceled)
            shootLeft = false;
    }

    public void OnShootRight(InputAction.CallbackContext context)
    {
        if (context.performed)
            shootRight = true;
        else if (context.canceled)
            shootRight = false;
    }

    public void OnShootForward(InputAction.CallbackContext context)
    {
        if (context.performed)
            shootForward = true;
        else if (context.canceled)
            shootForward = false;
    }

    public void OnLayMine(InputAction.CallbackContext context)
    {
        if (context.performed)
            mine = true;
        else if (context.canceled)
            mine = false;
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        aim = context.ReadValue<float>();
    }

    public void OnQuit(InputAction.CallbackContext context)
    {
        if(!quitting)
        {
            quitting = true;
            FindObjectOfType<GameController>().Quit();
        }
        
        
    }
}
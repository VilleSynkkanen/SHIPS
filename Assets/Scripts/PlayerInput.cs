using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    //PlayerControls controls;
    public float horizontal { get; private set; }
    public float vertical { get; private set; }
    public bool shootLeft { get; private set; }
    public bool shootRight { get; private set; }
    public bool shootForward { get; private set; }
    public bool mine { get; private set; }
    public float aim { get; private set; }

    void Awake()
    {
        /*controls = new PlayerControls();
        
        controls.Actions.Steering.performed += ctx => horizontal = ctx.ReadValue<float>();
        controls.Actions.Steering.canceled += ctx => horizontal = 0;

        controls.Actions.Throttle.performed += ctx => vertical = ctx.ReadValue<float>();
        controls.Actions.Throttle.canceled += ctx => vertical = 0;

        controls.Actions.ShootLeft.performed += ctx => shootLeft = true;
        controls.Actions.ShootLeft.canceled += ctx => shootLeft = false;

        controls.Actions.ShootRight.performed += ctx => shootRight = true;
        controls.Actions.ShootRight.canceled += ctx => shootRight = false;

        controls.Actions.ShootForward.performed += ctx => shootForward = true;
        controls.Actions.ShootForward.canceled += ctx => shootForward = false;

        controls.Actions.LayMine.performed += ctx => mine = true;
        controls.Actions.LayMine.canceled += ctx => mine = false;

        controls.Actions.AimCannon.performed += ctx => aim = ctx.ReadValue<float>();
        controls.Actions.AimCannon.canceled += ctx => aim = 0;*/
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

    /*void OnEnable()
    {
        controls.Actions.Enable();
    }
    void OnDisable()
    {
        controls.Actions.Disable();
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerControls controls;
    public float horizontal { get; private set; }
    public float vertical { get; private set; }
    public bool shootLeft { get; private set; }
    public bool shootRight { get; private set; }

    void Awake()
    {
        controls = new PlayerControls();

        controls.Actions.Steering.performed += ctx => horizontal = ctx.ReadValue<float>();
        controls.Actions.Steering.canceled += ctx => horizontal = 0;

        controls.Actions.Throttle.performed += ctx => vertical = ctx.ReadValue<float>();
        controls.Actions.Throttle.canceled += ctx => vertical = 0;

        controls.Actions.ShootLeft.performed += ctx => shootLeft = true;
        controls.Actions.ShootLeft.canceled += ctx => shootLeft = false;

        controls.Actions.ShootRight.performed += ctx => shootRight = true;
        controls.Actions.ShootRight.canceled += ctx => shootRight = false;
    }

    void OnEnable()
    {
        controls.Actions.Enable();
    }
    void OnDisable()
    {
        controls.Actions.Disable();
    }
}

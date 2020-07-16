using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlInput : MonoBehaviour
{
    bool quitting;
    int lastHorizontalPerformed;
    int lastVerticalPerformed;
    int lastAimPerformed;

    public float horizontal { get; private set; }
    public float vertical { get; private set; }
    public bool shoot1 { get; private set; }
    public bool shoot3 { get; private set; }
    public bool shoot2 { get; private set; }
    public bool shoot4 { get; private set; }
    public float aim { get; private set; }

    void Awake()
    {
        quitting = false;
    }

    public void OnThrottlePlus(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            lastVerticalPerformed = 0;
        }

        if (lastVerticalPerformed == 1)
            return;

        if (context.performed)
        {
            vertical = context.ReadValue<float>();
        }
        else if (context.canceled)
        {
            vertical = 0;
        }
    }

    public void OnThrottleMinus(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            lastVerticalPerformed = 1;
        }

        if (lastVerticalPerformed == 0)
            return;

        if (context.performed)
        {
            vertical = -context.ReadValue<float>();
        }
        else if (context.canceled)
        {
            vertical = 0;
        }
    }

    public void OnSteeringPlus(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            lastHorizontalPerformed = 0;
        }

        if (lastHorizontalPerformed == 1)
            return;

        if (context.performed)
        {
            horizontal = context.ReadValue<float>();
        }
        else if (context.canceled)
        {
            horizontal = 0;
        }
            
    }

    public void OnSteeringMinus(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            lastHorizontalPerformed = 1;
        }

        if (lastHorizontalPerformed == 0)
            return;
        
        if (context.performed)
        {
            horizontal = -context.ReadValue<float>();
        }   
        else if (context.canceled)
        {
            horizontal = 0;
        }
            
    }

    public void OnShoot1(InputAction.CallbackContext context)
    {
        if(context.performed)
            shoot1 = true;
        else if (context.canceled)
            shoot1 = false;
    }

    public void OnShoot2(InputAction.CallbackContext context)
    {
        if (context.performed)
            shoot2 = true;
        else if (context.canceled)
            shoot2 = false;
    }

    public void OnShoot3(InputAction.CallbackContext context)
    {
        if (context.performed)
            shoot3 = true;
        else if (context.canceled)
            shoot3 = false;
    }

    
    public void OnShoot4(InputAction.CallbackContext context)
    {
        if (context.performed)
            shoot4 = true;
        else if (context.canceled)
            shoot4 = false;
    }

    public void OnAimPlus(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            lastAimPerformed = 0;
        }

        if (lastAimPerformed == 1)
            return;

        if (context.performed)
        {
            aim = context.ReadValue<float>();
        }
        else if (context.canceled)
        {
            aim = 0;
        }
    }

    public void OnAimMinus(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            lastAimPerformed = 1;
        }

        if (lastAimPerformed == 0)
            return;

        if (context.performed)
        {
            aim = -context.ReadValue<float>();
        }
        else if (context.canceled)
        {
            aim = 0;
        }
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
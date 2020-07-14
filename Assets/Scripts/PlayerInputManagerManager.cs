using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManagerManager : MonoBehaviour
{
    [SerializeField] PlayerInputManager manager;

    private void Start()
    {
        //manager.joinAction = new InputActionProperty(new InputAction("Join", binding: "<Keyboard>/x"));
        
    }
}

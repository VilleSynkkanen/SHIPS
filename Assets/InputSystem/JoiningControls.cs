// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/JoiningControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @JoiningControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @JoiningControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""JoiningControls"",
    ""maps"": [
        {
            ""name"": ""Joining"",
            ""id"": ""327fa364-f9d1-4a42-9f4e-673da94db6fb"",
            ""actions"": [
                {
                    ""name"": ""Join"",
                    ""type"": ""Button"",
                    ""id"": ""b6d3c274-582d-43f2-99f0-356b709e0301"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""68e5cf8c-829f-452b-aa84-2095b26e1835"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Join"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ecb1a56-1417-4b33-bc07-17655a1b1fb7"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Join"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Joining
        m_Joining = asset.FindActionMap("Joining", throwIfNotFound: true);
        m_Joining_Join = m_Joining.FindAction("Join", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Joining
    private readonly InputActionMap m_Joining;
    private IJoiningActions m_JoiningActionsCallbackInterface;
    private readonly InputAction m_Joining_Join;
    public struct JoiningActions
    {
        private @JoiningControls m_Wrapper;
        public JoiningActions(@JoiningControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Join => m_Wrapper.m_Joining_Join;
        public InputActionMap Get() { return m_Wrapper.m_Joining; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(JoiningActions set) { return set.Get(); }
        public void SetCallbacks(IJoiningActions instance)
        {
            if (m_Wrapper.m_JoiningActionsCallbackInterface != null)
            {
                @Join.started -= m_Wrapper.m_JoiningActionsCallbackInterface.OnJoin;
                @Join.performed -= m_Wrapper.m_JoiningActionsCallbackInterface.OnJoin;
                @Join.canceled -= m_Wrapper.m_JoiningActionsCallbackInterface.OnJoin;
            }
            m_Wrapper.m_JoiningActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Join.started += instance.OnJoin;
                @Join.performed += instance.OnJoin;
                @Join.canceled += instance.OnJoin;
            }
        }
    }
    public JoiningActions @Joining => new JoiningActions(this);
    public interface IJoiningActions
    {
        void OnJoin(InputAction.CallbackContext context);
    }
}

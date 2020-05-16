// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Actions"",
            ""id"": ""0f2dc023-1694-464f-9c61-cda43719cd05"",
            ""actions"": [
                {
                    ""name"": ""Throttle"",
                    ""type"": ""Button"",
                    ""id"": ""e90d533a-d517-4f3f-8d13-830fcbeab16c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Steering"",
                    ""type"": ""Button"",
                    ""id"": ""0673adbc-82c0-409d-9ed4-7ff6f1255eb2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootLeft"",
                    ""type"": ""Button"",
                    ""id"": ""634901cb-2e54-47b0-99be-0927811dc16b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootRight"",
                    ""type"": ""Button"",
                    ""id"": ""acdac7b9-28f8-4e38-b569-9590a1652cc7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootForward"",
                    ""type"": ""Button"",
                    ""id"": ""e07a6f5c-8517-4201-9337-28f8ef150f89"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimCannon"",
                    ""type"": ""Value"",
                    ""id"": ""d573135f-2459-46c1-a47c-0ca2930c912a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""df38961e-f878-42e1-8f11-93978cc4e926"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Throttle"",
                    ""id"": ""ff7b259c-9d26-429e-a812-b1eaaf9e5663"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""76cec267-38e7-4b0c-abb7-330a3639145b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0462ddd6-58d1-452f-b76e-a7b3535ec56a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f71a2490-3224-4c2d-b154-2ed435c302d4"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""dc75b37e-3e73-4fbf-b162-e4faa30cfae0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""9c7cd7e0-af36-4254-bb55-5422a90dcaa5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a1c27433-3363-4476-9ab3-90b8685ae278"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""32f4bbd0-904d-4701-b06f-22d13d1e773a"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e6483ba-07ca-43de-8700-9ca959130db6"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d31b4251-5663-4146-8585-418feacc1d87"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa3d082e-4c65-4782-a339-b52b3cfa833e"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimCannon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Aim"",
                    ""id"": ""6b571660-5c85-4a90-9869-c104ceabcdbc"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimCannon"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""36977748-f16a-4a06-8019-98942fe85b2b"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimCannon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bf4a2a41-e8e4-4c1f-a38d-affd9feef4e8"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimCannon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Actions
        m_Actions = asset.FindActionMap("Actions", throwIfNotFound: true);
        m_Actions_Throttle = m_Actions.FindAction("Throttle", throwIfNotFound: true);
        m_Actions_Steering = m_Actions.FindAction("Steering", throwIfNotFound: true);
        m_Actions_ShootLeft = m_Actions.FindAction("ShootLeft", throwIfNotFound: true);
        m_Actions_ShootRight = m_Actions.FindAction("ShootRight", throwIfNotFound: true);
        m_Actions_ShootForward = m_Actions.FindAction("ShootForward", throwIfNotFound: true);
        m_Actions_AimCannon = m_Actions.FindAction("AimCannon", throwIfNotFound: true);
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

    // Actions
    private readonly InputActionMap m_Actions;
    private IActionsActions m_ActionsActionsCallbackInterface;
    private readonly InputAction m_Actions_Throttle;
    private readonly InputAction m_Actions_Steering;
    private readonly InputAction m_Actions_ShootLeft;
    private readonly InputAction m_Actions_ShootRight;
    private readonly InputAction m_Actions_ShootForward;
    private readonly InputAction m_Actions_AimCannon;
    public struct ActionsActions
    {
        private @PlayerControls m_Wrapper;
        public ActionsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Throttle => m_Wrapper.m_Actions_Throttle;
        public InputAction @Steering => m_Wrapper.m_Actions_Steering;
        public InputAction @ShootLeft => m_Wrapper.m_Actions_ShootLeft;
        public InputAction @ShootRight => m_Wrapper.m_Actions_ShootRight;
        public InputAction @ShootForward => m_Wrapper.m_Actions_ShootForward;
        public InputAction @AimCannon => m_Wrapper.m_Actions_AimCannon;
        public InputActionMap Get() { return m_Wrapper.m_Actions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionsActions set) { return set.Get(); }
        public void SetCallbacks(IActionsActions instance)
        {
            if (m_Wrapper.m_ActionsActionsCallbackInterface != null)
            {
                @Throttle.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnThrottle;
                @Throttle.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnThrottle;
                @Throttle.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnThrottle;
                @Steering.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSteering;
                @Steering.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSteering;
                @Steering.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSteering;
                @ShootLeft.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShootLeft;
                @ShootLeft.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShootLeft;
                @ShootLeft.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShootLeft;
                @ShootRight.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShootRight;
                @ShootRight.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShootRight;
                @ShootRight.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShootRight;
                @ShootForward.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShootForward;
                @ShootForward.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShootForward;
                @ShootForward.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShootForward;
                @AimCannon.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnAimCannon;
                @AimCannon.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnAimCannon;
                @AimCannon.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnAimCannon;
            }
            m_Wrapper.m_ActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Throttle.started += instance.OnThrottle;
                @Throttle.performed += instance.OnThrottle;
                @Throttle.canceled += instance.OnThrottle;
                @Steering.started += instance.OnSteering;
                @Steering.performed += instance.OnSteering;
                @Steering.canceled += instance.OnSteering;
                @ShootLeft.started += instance.OnShootLeft;
                @ShootLeft.performed += instance.OnShootLeft;
                @ShootLeft.canceled += instance.OnShootLeft;
                @ShootRight.started += instance.OnShootRight;
                @ShootRight.performed += instance.OnShootRight;
                @ShootRight.canceled += instance.OnShootRight;
                @ShootForward.started += instance.OnShootForward;
                @ShootForward.performed += instance.OnShootForward;
                @ShootForward.canceled += instance.OnShootForward;
                @AimCannon.started += instance.OnAimCannon;
                @AimCannon.performed += instance.OnAimCannon;
                @AimCannon.canceled += instance.OnAimCannon;
            }
        }
    }
    public ActionsActions @Actions => new ActionsActions(this);
    public interface IActionsActions
    {
        void OnThrottle(InputAction.CallbackContext context);
        void OnSteering(InputAction.CallbackContext context);
        void OnShootLeft(InputAction.CallbackContext context);
        void OnShootRight(InputAction.CallbackContext context);
        void OnShootForward(InputAction.CallbackContext context);
        void OnAimCannon(InputAction.CallbackContext context);
    }
}

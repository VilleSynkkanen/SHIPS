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
                    ""type"": ""Value"",
                    ""id"": ""e90d533a-d517-4f3f-8d13-830fcbeab16c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Steering"",
                    ""type"": ""Value"",
                    ""id"": ""0673adbc-82c0-409d-9ed4-7ff6f1255eb2"",
                    ""expectedControlType"": ""Axis"",
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
                },
                {
                    ""name"": ""LayMine"",
                    ""type"": ""Button"",
                    ""id"": ""22943604-ef19-4574-acee-b5795db8f631"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""8747c435-1878-4ced-8785-5742ffb1d23b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""df38961e-f878-42e1-8f11-93978cc4e926"",
                    ""path"": ""<Gamepad>/dpad/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
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
                    ""groups"": ""Keyboard"",
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
                    ""groups"": ""Keyboard"",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f71a2490-3224-4c2d-b154-2ed435c302d4"",
                    ""path"": ""<Gamepad>/dpad/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
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
                    ""groups"": ""Keyboard"",
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
                    ""groups"": ""Keyboard"",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""32f4bbd0-904d-4701-b06f-22d13d1e773a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ShootLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a82cc642-eb0d-482e-b95b-76776c63f9ea"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ShootLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e6483ba-07ca-43de-8700-9ca959130db6"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ShootRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecb4cdea-2194-47a1-943f-aa4f031b792f"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ShootRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d31b4251-5663-4146-8585-418feacc1d87"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ShootForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8bf8c900-6768-4a3f-9ac4-f6c94ff7b471"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ShootForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Controller"",
                    ""id"": ""cb4473c7-5172-4074-81e5-942823e12df6"",
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
                    ""id"": ""6480300a-50bd-400c-8fe2-a7ee558d13fa"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""AimCannon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d9e2b183-be7c-4cad-9f66-f074dd5fb590"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""AimCannon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""AimCannon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bf4a2a41-e8e4-4c1f-a38d-affd9feef4e8"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""AimCannon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fa0e4d98-55e4-4bce-aba3-99d8780cde75"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""LayMine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""daaeda59-a61c-4352-931e-6beb0aa1321b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""LayMine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e27247ad-acab-4c4e-b1d0-6e57267a61bb"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d355eb2f-cbd6-4458-a199-30f211c68758"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Actions
        m_Actions = asset.FindActionMap("Actions", throwIfNotFound: true);
        m_Actions_Throttle = m_Actions.FindAction("Throttle", throwIfNotFound: true);
        m_Actions_Steering = m_Actions.FindAction("Steering", throwIfNotFound: true);
        m_Actions_ShootLeft = m_Actions.FindAction("ShootLeft", throwIfNotFound: true);
        m_Actions_ShootRight = m_Actions.FindAction("ShootRight", throwIfNotFound: true);
        m_Actions_ShootForward = m_Actions.FindAction("ShootForward", throwIfNotFound: true);
        m_Actions_AimCannon = m_Actions.FindAction("AimCannon", throwIfNotFound: true);
        m_Actions_LayMine = m_Actions.FindAction("LayMine", throwIfNotFound: true);
        m_Actions_Quit = m_Actions.FindAction("Quit", throwIfNotFound: true);
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
    private readonly InputAction m_Actions_LayMine;
    private readonly InputAction m_Actions_Quit;
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
        public InputAction @LayMine => m_Wrapper.m_Actions_LayMine;
        public InputAction @Quit => m_Wrapper.m_Actions_Quit;
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
                @LayMine.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnLayMine;
                @LayMine.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnLayMine;
                @LayMine.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnLayMine;
                @Quit.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnQuit;
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
                @LayMine.started += instance.OnLayMine;
                @LayMine.performed += instance.OnLayMine;
                @LayMine.canceled += instance.OnLayMine;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
            }
        }
    }
    public ActionsActions @Actions => new ActionsActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IActionsActions
    {
        void OnThrottle(InputAction.CallbackContext context);
        void OnSteering(InputAction.CallbackContext context);
        void OnShootLeft(InputAction.CallbackContext context);
        void OnShootRight(InputAction.CallbackContext context);
        void OnShootForward(InputAction.CallbackContext context);
        void OnAimCannon(InputAction.CallbackContext context);
        void OnLayMine(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
    }
}

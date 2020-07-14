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
                    ""name"": ""ThrottlePlus"",
                    ""type"": ""Button"",
                    ""id"": ""e90d533a-d517-4f3f-8d13-830fcbeab16c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ThrottleMinus"",
                    ""type"": ""Button"",
                    ""id"": ""b6800d06-bafe-437a-bd45-f364ebfb180f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SteeringPlus"",
                    ""type"": ""Button"",
                    ""id"": ""90bccbaf-0c5c-4d68-a8ff-66734af95c8c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SteeringMinus"",
                    ""type"": ""Button"",
                    ""id"": ""61dc8838-e088-441a-9cc0-8492a9da59de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot1"",
                    ""type"": ""Button"",
                    ""id"": ""634901cb-2e54-47b0-99be-0927811dc16b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot2"",
                    ""type"": ""Button"",
                    ""id"": ""e07a6f5c-8517-4201-9337-28f8ef150f89"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot3"",
                    ""type"": ""Button"",
                    ""id"": ""acdac7b9-28f8-4e38-b569-9590a1652cc7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot4"",
                    ""type"": ""Button"",
                    ""id"": ""22943604-ef19-4574-acee-b5795db8f631"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimPlus"",
                    ""type"": ""Value"",
                    ""id"": ""d573135f-2459-46c1-a47c-0ca2930c912a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimMinus"",
                    ""type"": ""Value"",
                    ""id"": ""3b2ff1e9-8ecb-46df-8c9a-403d0cc5af1e"",
                    ""expectedControlType"": ""Axis"",
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
                    ""id"": ""a8f7eb5a-b0e4-4d14-9d28-bc78a725e557"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ThrottlePlus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08e7d2cf-47aa-4919-a2ed-18e2e4f476c2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardPrimary"",
                    ""action"": ""ThrottlePlus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c61e7b8-3167-4a62-9b3a-dec877af90dc"",
                    ""path"": ""<Keyboard>/leftBracket"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardSecondary"",
                    ""action"": ""ThrottlePlus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df38961e-f878-42e1-8f11-93978cc4e926"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ThrottlePlus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32f4bbd0-904d-4701-b06f-22d13d1e773a"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Shoot1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69b91ddd-0b65-4cbc-9ef8-b2eaee69b3d0"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardPrimary"",
                    ""action"": ""Shoot1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc64fef0-39ed-4206-b02a-260c60a2ef70"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardSecondary"",
                    ""action"": ""Shoot1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a82cc642-eb0d-482e-b95b-76776c63f9ea"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Shoot1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e6483ba-07ca-43de-8700-9ca959130db6"",
                    ""path"": ""<Keyboard>/quote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Shoot3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f08ec01-994b-4c57-bd8f-f46c36dbdfdf"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardPrimary"",
                    ""action"": ""Shoot3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51f83f42-a599-487c-8c63-8d3a8d82d761"",
                    ""path"": ""<Keyboard>/numpad6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardSecondary"",
                    ""action"": ""Shoot3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecb4cdea-2194-47a1-943f-aa4f031b792f"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Shoot3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e27247ad-acab-4c4e-b1d0-6e57267a61bb"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""671fafb8-7333-4bad-a207-594bd718aacc"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard;KeyboardPrimary"",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""985dfe4b-2216-4db8-b882-a3665f09dd79"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardSecondary"",
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
                    ""groups"": ""Controller"",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa0e4d98-55e4-4bce-aba3-99d8780cde75"",
                    ""path"": ""<Keyboard>/backslash"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Shoot4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cbdac11-fedc-4911-ab7e-94533464c62f"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardPrimary"",
                    ""action"": ""Shoot4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c74bff50-9ea4-4ac8-956a-c0d6a85e7b75"",
                    ""path"": ""<Keyboard>/numpadPlus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardSecondary"",
                    ""action"": ""Shoot4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""daaeda59-a61c-4352-931e-6beb0aa1321b"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Shoot4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d31b4251-5663-4146-8585-418feacc1d87"",
                    ""path"": ""<Keyboard>/semicolon"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Shoot2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72f641f6-4bcb-434f-8ab7-19ce7186ea22"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardPrimary"",
                    ""action"": ""Shoot2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c93be600-e7a9-4773-8a39-8d22e358bf1c"",
                    ""path"": ""<Keyboard>/numpad5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardSecondary"",
                    ""action"": ""Shoot2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8bf8c900-6768-4a3f-9ac4-f6c94ff7b471"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Shoot2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8298044-a3d7-4412-a5b4-da6b47a62e0f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ThrottleMinus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a580ccc1-a64e-4f02-8d4b-c5d083e3f45c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardPrimary"",
                    ""action"": ""ThrottleMinus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d314911-2170-4ea5-8ddb-b45140546267"",
                    ""path"": ""<Keyboard>/quote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardSecondary"",
                    ""action"": ""ThrottleMinus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e0caf2b-ebd4-4764-9231-420585b2fe5c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SteeringMinus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ec889cf-7875-41d8-8421-a492259bfecd"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardPrimary"",
                    ""action"": ""SteeringMinus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""961e6682-f8b5-49ad-b6aa-f2cb159c597b"",
                    ""path"": ""<Keyboard>/semicolon"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardSecondary"",
                    ""action"": ""SteeringMinus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""506e2f18-22d7-4d7e-83d5-23d7ec456126"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SteeringPlus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e55fdcde-be7e-438d-94ee-10eaf31fff5c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardPrimary"",
                    ""action"": ""SteeringPlus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""070cc359-633e-4e98-8b8d-1fb88c2c193d"",
                    ""path"": ""<Keyboard>/backslash"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardSecondary"",
                    ""action"": ""SteeringPlus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dab16adc-1c2d-4e06-8544-cb836e39cfb0"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""SteeringPlus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3353fdac-5931-4325-913c-0ba57ca9a6d0"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ThrottleMinus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0844cd39-4e55-4bb4-a967-983e004345b5"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""SteeringMinus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5f798f5-0dd5-4fed-8007-5e7aa1900293"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""AimPlus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2674818-541e-4fb2-a309-a4fc57b5fe1f"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardPrimary"",
                    ""action"": ""AimPlus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9babfa37-25ad-4dd3-8186-1e2d95d7dcf6"",
                    ""path"": ""<Keyboard>/rightBracket"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardSecondary"",
                    ""action"": ""AimPlus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5db4d255-a716-4680-8eb6-2260b265002b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""AimPlus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""78f08afb-bdef-436f-8f92-4740b8191d82"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""AimMinus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e716b74-f981-42b1-a9bd-49f6ce2fd994"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardPrimary"",
                    ""action"": ""AimMinus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b1a18ff-2bfb-4658-8c1d-d6aad5546307"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardSecondary"",
                    ""action"": ""AimMinus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2217432d-585c-498c-9de7-2b1c667d6d2a"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""AimMinus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MainMenu"",
            ""id"": ""859a399f-6f1c-4e41-ad78-03e3db5cc3d1"",
            ""actions"": [
                {
                    ""name"": ""Ready"",
                    ""type"": ""Button"",
                    ""id"": ""13478067-39d8-4228-af96-e2b1903e3436"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Next"",
                    ""type"": ""Button"",
                    ""id"": ""50756015-06bd-4eae-9c47-51cb4c8e4c8e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Previous"",
                    ""type"": ""Button"",
                    ""id"": ""14cbce9a-bdeb-4e87-92a8-01b24e0c991a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Unready"",
                    ""type"": ""Button"",
                    ""id"": ""2dc0247c-c031-4741-91f7-f6b28049ffc7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Player2Join"",
                    ""type"": ""Button"",
                    ""id"": ""0f77a480-0975-481f-b9ea-c9df386cdb7e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""43d294a6-5ce8-4abe-8dbd-6cf14ebd100c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c1eb0cd7-2ce9-4a09-89d4-8ac25fa6b6ba"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Ready"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d5c6bd7-61c1-425c-969d-17b7aceb9c11"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardPrimary"",
                    ""action"": ""Ready"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a3f2e9e-3653-4ff3-a350-347a9d1b68a1"",
                    ""path"": ""<Keyboard>/leftBracket"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardSecondary"",
                    ""action"": ""Ready"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7fa4d0c1-b519-4b10-bfda-e3229fd13017"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Ready"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8bd2942-0a3f-4500-b1d7-c5e7ef089e3f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7587cae-4504-44a6-bb4a-7fc48b82bab1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardPrimary"",
                    ""action"": ""Next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""583985a7-da4f-45f9-9cec-cf38af717aa2"",
                    ""path"": ""<Keyboard>/backslash"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardSecondary"",
                    ""action"": ""Next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b8c7245-48be-4385-82cf-a658dc6f4f0d"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94241a7b-e3d3-4135-bfa3-6a876ff022d8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Previous"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cfb8234b-8c19-4082-9e37-43ba4eca86ee"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardPrimary"",
                    ""action"": ""Previous"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e155e0d-8786-4a13-a0b6-62944dc9be04"",
                    ""path"": ""<Keyboard>/semicolon"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardSecondary"",
                    ""action"": ""Previous"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd3056bb-9738-471c-a77e-2039e1ec9a9d"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Previous"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d23c2134-7405-4754-a9f1-63451d7ce4a8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Unready"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c69db4b6-72a9-4be0-82a5-33d71ce3d72f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardPrimary"",
                    ""action"": ""Unready"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f581454b-e861-4b60-9c1e-edbad8483f88"",
                    ""path"": ""<Keyboard>/quote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardSecondary"",
                    ""action"": ""Unready"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f48aff7a-0489-48b7-8910-03edb0c33a4e"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Unready"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bf7039a9-f157-4fa9-a01c-eb442caafc47"",
                    ""path"": ""<Keyboard>/leftBracket"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Player2Join"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6bfeb2c-e323-4168-98fa-06ff3df32859"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c01079e8-1419-469b-b574-bc5e7d46139b"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard;KeyboardPrimary"",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3512c274-a3d3-416d-98a1-35d89ccc7c95"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardSecondary"",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""faa900cd-9f21-4998-94be-1fbe3d65b037"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
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
        },
        {
            ""name"": ""KeyboardSecondary"",
            ""bindingGroup"": ""KeyboardSecondary"",
            ""devices"": []
        },
        {
            ""name"": ""KeyboardPrimary"",
            ""bindingGroup"": ""KeyboardPrimary"",
            ""devices"": []
        }
    ]
}");
        // Actions
        m_Actions = asset.FindActionMap("Actions", throwIfNotFound: true);
        m_Actions_ThrottlePlus = m_Actions.FindAction("ThrottlePlus", throwIfNotFound: true);
        m_Actions_ThrottleMinus = m_Actions.FindAction("ThrottleMinus", throwIfNotFound: true);
        m_Actions_SteeringPlus = m_Actions.FindAction("SteeringPlus", throwIfNotFound: true);
        m_Actions_SteeringMinus = m_Actions.FindAction("SteeringMinus", throwIfNotFound: true);
        m_Actions_Shoot1 = m_Actions.FindAction("Shoot1", throwIfNotFound: true);
        m_Actions_Shoot2 = m_Actions.FindAction("Shoot2", throwIfNotFound: true);
        m_Actions_Shoot3 = m_Actions.FindAction("Shoot3", throwIfNotFound: true);
        m_Actions_Shoot4 = m_Actions.FindAction("Shoot4", throwIfNotFound: true);
        m_Actions_AimPlus = m_Actions.FindAction("AimPlus", throwIfNotFound: true);
        m_Actions_AimMinus = m_Actions.FindAction("AimMinus", throwIfNotFound: true);
        m_Actions_Quit = m_Actions.FindAction("Quit", throwIfNotFound: true);
        // MainMenu
        m_MainMenu = asset.FindActionMap("MainMenu", throwIfNotFound: true);
        m_MainMenu_Ready = m_MainMenu.FindAction("Ready", throwIfNotFound: true);
        m_MainMenu_Next = m_MainMenu.FindAction("Next", throwIfNotFound: true);
        m_MainMenu_Previous = m_MainMenu.FindAction("Previous", throwIfNotFound: true);
        m_MainMenu_Unready = m_MainMenu.FindAction("Unready", throwIfNotFound: true);
        m_MainMenu_Player2Join = m_MainMenu.FindAction("Player2Join", throwIfNotFound: true);
        m_MainMenu_Quit = m_MainMenu.FindAction("Quit", throwIfNotFound: true);
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
    private readonly InputAction m_Actions_ThrottlePlus;
    private readonly InputAction m_Actions_ThrottleMinus;
    private readonly InputAction m_Actions_SteeringPlus;
    private readonly InputAction m_Actions_SteeringMinus;
    private readonly InputAction m_Actions_Shoot1;
    private readonly InputAction m_Actions_Shoot2;
    private readonly InputAction m_Actions_Shoot3;
    private readonly InputAction m_Actions_Shoot4;
    private readonly InputAction m_Actions_AimPlus;
    private readonly InputAction m_Actions_AimMinus;
    private readonly InputAction m_Actions_Quit;
    public struct ActionsActions
    {
        private @PlayerControls m_Wrapper;
        public ActionsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ThrottlePlus => m_Wrapper.m_Actions_ThrottlePlus;
        public InputAction @ThrottleMinus => m_Wrapper.m_Actions_ThrottleMinus;
        public InputAction @SteeringPlus => m_Wrapper.m_Actions_SteeringPlus;
        public InputAction @SteeringMinus => m_Wrapper.m_Actions_SteeringMinus;
        public InputAction @Shoot1 => m_Wrapper.m_Actions_Shoot1;
        public InputAction @Shoot2 => m_Wrapper.m_Actions_Shoot2;
        public InputAction @Shoot3 => m_Wrapper.m_Actions_Shoot3;
        public InputAction @Shoot4 => m_Wrapper.m_Actions_Shoot4;
        public InputAction @AimPlus => m_Wrapper.m_Actions_AimPlus;
        public InputAction @AimMinus => m_Wrapper.m_Actions_AimMinus;
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
                @ThrottlePlus.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnThrottlePlus;
                @ThrottlePlus.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnThrottlePlus;
                @ThrottlePlus.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnThrottlePlus;
                @ThrottleMinus.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnThrottleMinus;
                @ThrottleMinus.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnThrottleMinus;
                @ThrottleMinus.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnThrottleMinus;
                @SteeringPlus.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSteeringPlus;
                @SteeringPlus.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSteeringPlus;
                @SteeringPlus.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSteeringPlus;
                @SteeringMinus.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSteeringMinus;
                @SteeringMinus.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSteeringMinus;
                @SteeringMinus.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSteeringMinus;
                @Shoot1.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShoot1;
                @Shoot1.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShoot1;
                @Shoot1.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShoot1;
                @Shoot2.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShoot2;
                @Shoot2.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShoot2;
                @Shoot2.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShoot2;
                @Shoot3.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShoot3;
                @Shoot3.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShoot3;
                @Shoot3.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShoot3;
                @Shoot4.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShoot4;
                @Shoot4.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShoot4;
                @Shoot4.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShoot4;
                @AimPlus.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnAimPlus;
                @AimPlus.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnAimPlus;
                @AimPlus.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnAimPlus;
                @AimMinus.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnAimMinus;
                @AimMinus.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnAimMinus;
                @AimMinus.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnAimMinus;
                @Quit.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnQuit;
            }
            m_Wrapper.m_ActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ThrottlePlus.started += instance.OnThrottlePlus;
                @ThrottlePlus.performed += instance.OnThrottlePlus;
                @ThrottlePlus.canceled += instance.OnThrottlePlus;
                @ThrottleMinus.started += instance.OnThrottleMinus;
                @ThrottleMinus.performed += instance.OnThrottleMinus;
                @ThrottleMinus.canceled += instance.OnThrottleMinus;
                @SteeringPlus.started += instance.OnSteeringPlus;
                @SteeringPlus.performed += instance.OnSteeringPlus;
                @SteeringPlus.canceled += instance.OnSteeringPlus;
                @SteeringMinus.started += instance.OnSteeringMinus;
                @SteeringMinus.performed += instance.OnSteeringMinus;
                @SteeringMinus.canceled += instance.OnSteeringMinus;
                @Shoot1.started += instance.OnShoot1;
                @Shoot1.performed += instance.OnShoot1;
                @Shoot1.canceled += instance.OnShoot1;
                @Shoot2.started += instance.OnShoot2;
                @Shoot2.performed += instance.OnShoot2;
                @Shoot2.canceled += instance.OnShoot2;
                @Shoot3.started += instance.OnShoot3;
                @Shoot3.performed += instance.OnShoot3;
                @Shoot3.canceled += instance.OnShoot3;
                @Shoot4.started += instance.OnShoot4;
                @Shoot4.performed += instance.OnShoot4;
                @Shoot4.canceled += instance.OnShoot4;
                @AimPlus.started += instance.OnAimPlus;
                @AimPlus.performed += instance.OnAimPlus;
                @AimPlus.canceled += instance.OnAimPlus;
                @AimMinus.started += instance.OnAimMinus;
                @AimMinus.performed += instance.OnAimMinus;
                @AimMinus.canceled += instance.OnAimMinus;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
            }
        }
    }
    public ActionsActions @Actions => new ActionsActions(this);

    // MainMenu
    private readonly InputActionMap m_MainMenu;
    private IMainMenuActions m_MainMenuActionsCallbackInterface;
    private readonly InputAction m_MainMenu_Ready;
    private readonly InputAction m_MainMenu_Next;
    private readonly InputAction m_MainMenu_Previous;
    private readonly InputAction m_MainMenu_Unready;
    private readonly InputAction m_MainMenu_Player2Join;
    private readonly InputAction m_MainMenu_Quit;
    public struct MainMenuActions
    {
        private @PlayerControls m_Wrapper;
        public MainMenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Ready => m_Wrapper.m_MainMenu_Ready;
        public InputAction @Next => m_Wrapper.m_MainMenu_Next;
        public InputAction @Previous => m_Wrapper.m_MainMenu_Previous;
        public InputAction @Unready => m_Wrapper.m_MainMenu_Unready;
        public InputAction @Player2Join => m_Wrapper.m_MainMenu_Player2Join;
        public InputAction @Quit => m_Wrapper.m_MainMenu_Quit;
        public InputActionMap Get() { return m_Wrapper.m_MainMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMenuActions set) { return set.Get(); }
        public void SetCallbacks(IMainMenuActions instance)
        {
            if (m_Wrapper.m_MainMenuActionsCallbackInterface != null)
            {
                @Ready.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnReady;
                @Ready.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnReady;
                @Ready.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnReady;
                @Next.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnNext;
                @Next.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnNext;
                @Next.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnNext;
                @Previous.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnPrevious;
                @Previous.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnPrevious;
                @Previous.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnPrevious;
                @Unready.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnUnready;
                @Unready.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnUnready;
                @Unready.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnUnready;
                @Player2Join.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnPlayer2Join;
                @Player2Join.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnPlayer2Join;
                @Player2Join.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnPlayer2Join;
                @Quit.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnQuit;
            }
            m_Wrapper.m_MainMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Ready.started += instance.OnReady;
                @Ready.performed += instance.OnReady;
                @Ready.canceled += instance.OnReady;
                @Next.started += instance.OnNext;
                @Next.performed += instance.OnNext;
                @Next.canceled += instance.OnNext;
                @Previous.started += instance.OnPrevious;
                @Previous.performed += instance.OnPrevious;
                @Previous.canceled += instance.OnPrevious;
                @Unready.started += instance.OnUnready;
                @Unready.performed += instance.OnUnready;
                @Unready.canceled += instance.OnUnready;
                @Player2Join.started += instance.OnPlayer2Join;
                @Player2Join.performed += instance.OnPlayer2Join;
                @Player2Join.canceled += instance.OnPlayer2Join;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
            }
        }
    }
    public MainMenuActions @MainMenu => new MainMenuActions(this);
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
    private int m_KeyboardSecondarySchemeIndex = -1;
    public InputControlScheme KeyboardSecondaryScheme
    {
        get
        {
            if (m_KeyboardSecondarySchemeIndex == -1) m_KeyboardSecondarySchemeIndex = asset.FindControlSchemeIndex("KeyboardSecondary");
            return asset.controlSchemes[m_KeyboardSecondarySchemeIndex];
        }
    }
    private int m_KeyboardPrimarySchemeIndex = -1;
    public InputControlScheme KeyboardPrimaryScheme
    {
        get
        {
            if (m_KeyboardPrimarySchemeIndex == -1) m_KeyboardPrimarySchemeIndex = asset.FindControlSchemeIndex("KeyboardPrimary");
            return asset.controlSchemes[m_KeyboardPrimarySchemeIndex];
        }
    }
    public interface IActionsActions
    {
        void OnThrottlePlus(InputAction.CallbackContext context);
        void OnThrottleMinus(InputAction.CallbackContext context);
        void OnSteeringPlus(InputAction.CallbackContext context);
        void OnSteeringMinus(InputAction.CallbackContext context);
        void OnShoot1(InputAction.CallbackContext context);
        void OnShoot2(InputAction.CallbackContext context);
        void OnShoot3(InputAction.CallbackContext context);
        void OnShoot4(InputAction.CallbackContext context);
        void OnAimPlus(InputAction.CallbackContext context);
        void OnAimMinus(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
    }
    public interface IMainMenuActions
    {
        void OnReady(InputAction.CallbackContext context);
        void OnNext(InputAction.CallbackContext context);
        void OnPrevious(InputAction.CallbackContext context);
        void OnUnready(InputAction.CallbackContext context);
        void OnPlayer2Join(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
    }
}

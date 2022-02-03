//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Scripts/InputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerControl"",
            ""id"": ""9d22fbde-db45-45e9-90c1-6d3507068e6a"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""f002bf04-e018-46ce-89da-098ac6bcc3f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Tug"",
                    ""type"": ""Button"",
                    ""id"": ""d8272b4e-e0c0-47db-8ffa-03b01c18b462"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Stick"",
                    ""type"": ""Button"",
                    ""id"": ""9508e200-2d10-4965-8e01-6a897e9e9d9f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Connect"",
                    ""type"": ""Button"",
                    ""id"": ""91898d00-02d2-41fb-b46e-6654a10f2709"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Disconnect"",
                    ""type"": ""Button"",
                    ""id"": ""4c9c6132-e974-4ba8-ae6f-ae247d3cdf33"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""580a5ec0-dd91-45e3-a090-bf4c9df7a0ab"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bb9e92f7-a48b-41a2-a76d-dc6b638abea9"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b1bf27a-f3e8-4807-837f-6f18e0163752"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be4397c7-ad07-40f4-baaa-86c739e5728f"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c85731c3-0640-44d9-8ff5-e75666c829fe"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Tug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89fe5fd5-0ed8-494a-8ac1-b8d8d491fdcf"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Tug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d87bdff-abdb-4748-b685-e339cf933207"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1204c24-28ad-4031-9041-63e3995d1bf4"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93d48397-4a98-49ca-9929-c88a3522033d"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Press(pressPoint=0.5)"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Connect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""777c9451-5e93-4526-ba1d-27d620ad9e3a"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Connect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57944694-f36c-4b9b-a9ec-7260c4193acc"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Disconnect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75dacd91-1797-41fb-9217-4c3699d6c011"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Disconnect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""88684d3c-8612-4802-a60a-7922e8a4ab9a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""b99061a4-10da-480a-b1be-050f6fdf217e"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""a23c594c-cb6f-4641-9745-ef9e4718467f"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""d902f43a-4eaa-4c14-b75e-a7a51668d803"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""50b02b41-8e8d-42a2-9eb1-34c86f4fd799"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard2"",
            ""bindingGroup"": ""Keyboard2"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerControl
        m_PlayerControl = asset.FindActionMap("PlayerControl", throwIfNotFound: true);
        m_PlayerControl_Jump = m_PlayerControl.FindAction("Jump", throwIfNotFound: true);
        m_PlayerControl_Tug = m_PlayerControl.FindAction("Tug", throwIfNotFound: true);
        m_PlayerControl_Stick = m_PlayerControl.FindAction("Stick", throwIfNotFound: true);
        m_PlayerControl_Connect = m_PlayerControl.FindAction("Connect", throwIfNotFound: true);
        m_PlayerControl_Disconnect = m_PlayerControl.FindAction("Disconnect", throwIfNotFound: true);
        m_PlayerControl_Movement = m_PlayerControl.FindAction("Movement", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerControl
    private readonly InputActionMap m_PlayerControl;
    private IPlayerControlActions m_PlayerControlActionsCallbackInterface;
    private readonly InputAction m_PlayerControl_Jump;
    private readonly InputAction m_PlayerControl_Tug;
    private readonly InputAction m_PlayerControl_Stick;
    private readonly InputAction m_PlayerControl_Connect;
    private readonly InputAction m_PlayerControl_Disconnect;
    private readonly InputAction m_PlayerControl_Movement;
    public struct PlayerControlActions
    {
        private @InputActions m_Wrapper;
        public PlayerControlActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_PlayerControl_Jump;
        public InputAction @Tug => m_Wrapper.m_PlayerControl_Tug;
        public InputAction @Stick => m_Wrapper.m_PlayerControl_Stick;
        public InputAction @Connect => m_Wrapper.m_PlayerControl_Connect;
        public InputAction @Disconnect => m_Wrapper.m_PlayerControl_Disconnect;
        public InputAction @Movement => m_Wrapper.m_PlayerControl_Movement;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlActions instance)
        {
            if (m_Wrapper.m_PlayerControlActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnJump;
                @Tug.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnTug;
                @Tug.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnTug;
                @Tug.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnTug;
                @Stick.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnStick;
                @Stick.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnStick;
                @Stick.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnStick;
                @Connect.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnConnect;
                @Connect.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnConnect;
                @Connect.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnConnect;
                @Disconnect.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnDisconnect;
                @Disconnect.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnDisconnect;
                @Disconnect.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnDisconnect;
                @Movement.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_PlayerControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Tug.started += instance.OnTug;
                @Tug.performed += instance.OnTug;
                @Tug.canceled += instance.OnTug;
                @Stick.started += instance.OnStick;
                @Stick.performed += instance.OnStick;
                @Stick.canceled += instance.OnStick;
                @Connect.started += instance.OnConnect;
                @Connect.performed += instance.OnConnect;
                @Connect.canceled += instance.OnConnect;
                @Disconnect.started += instance.OnDisconnect;
                @Disconnect.performed += instance.OnDisconnect;
                @Disconnect.canceled += instance.OnDisconnect;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public PlayerControlActions @PlayerControl => new PlayerControlActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_Keyboard2SchemeIndex = -1;
    public InputControlScheme Keyboard2Scheme
    {
        get
        {
            if (m_Keyboard2SchemeIndex == -1) m_Keyboard2SchemeIndex = asset.FindControlSchemeIndex("Keyboard2");
            return asset.controlSchemes[m_Keyboard2SchemeIndex];
        }
    }
    public interface IPlayerControlActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnTug(InputAction.CallbackContext context);
        void OnStick(InputAction.CallbackContext context);
        void OnConnect(InputAction.CallbackContext context);
        void OnDisconnect(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
    }
}

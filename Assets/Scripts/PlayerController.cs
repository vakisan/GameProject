//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/PlayerController.inputactions
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

public partial class @PlayerController : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""Road"",
            ""id"": ""ad66fa28-7041-4479-ad7c-1ec53cb4b30b"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""57a12f64-c6cb-48d3-bb9a-35f645069e39"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0baa4bf0-ea7a-47ad-bf0d-b3fd7529cb55"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Water"",
            ""id"": ""939d6ef2-01d7-48b6-a502-4dd5ba4df8d6"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""12479de0-b3da-4007-a326-dce270ac613a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""16247c8e-ddfe-41ef-9455-487288466250"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""b01b9f05-a89e-43e1-9d90-988a468a8775"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bf144fce-24dc-402d-ab56-18648f43b33a"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""ced304cd-4761-4397-b1c9-eeb7e9676294"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""547b29f6-a8c8-4310-bdd7-f4a694373746"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""280fcc76-21cf-4053-800a-22b77d663a2e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""362de970-19bb-4c0b-a203-2ea6e31beb8b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ae5c3780-3aea-482d-b846-ce277e7d4091"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b4eba211-a85a-4567-8d83-dbbbb1f984db"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60fbfa8c-c1f1-4999-b75b-13d4a390b708"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Road
        m_Road = asset.FindActionMap("Road", throwIfNotFound: true);
        m_Road_Jump = m_Road.FindAction("Jump", throwIfNotFound: true);
        // Water
        m_Water = asset.FindActionMap("Water", throwIfNotFound: true);
        m_Water_Move = m_Water.FindAction("Move", throwIfNotFound: true);
        m_Water_Jump = m_Water.FindAction("Jump", throwIfNotFound: true);
        m_Water_Shoot = m_Water.FindAction("Shoot", throwIfNotFound: true);
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

    // Road
    private readonly InputActionMap m_Road;
    private IRoadActions m_RoadActionsCallbackInterface;
    private readonly InputAction m_Road_Jump;
    public struct RoadActions
    {
        private @PlayerController m_Wrapper;
        public RoadActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Road_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Road; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RoadActions set) { return set.Get(); }
        public void SetCallbacks(IRoadActions instance)
        {
            if (m_Wrapper.m_RoadActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_RoadActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_RoadActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_RoadActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_RoadActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public RoadActions @Road => new RoadActions(this);

    // Water
    private readonly InputActionMap m_Water;
    private IWaterActions m_WaterActionsCallbackInterface;
    private readonly InputAction m_Water_Move;
    private readonly InputAction m_Water_Jump;
    private readonly InputAction m_Water_Shoot;
    public struct WaterActions
    {
        private @PlayerController m_Wrapper;
        public WaterActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Water_Move;
        public InputAction @Jump => m_Wrapper.m_Water_Jump;
        public InputAction @Shoot => m_Wrapper.m_Water_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Water; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WaterActions set) { return set.Get(); }
        public void SetCallbacks(IWaterActions instance)
        {
            if (m_Wrapper.m_WaterActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_WaterActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_WaterActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_WaterActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_WaterActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_WaterActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_WaterActionsCallbackInterface.OnJump;
                @Shoot.started -= m_Wrapper.m_WaterActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_WaterActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_WaterActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_WaterActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public WaterActions @Water => new WaterActions(this);
    public interface IRoadActions
    {
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IWaterActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}

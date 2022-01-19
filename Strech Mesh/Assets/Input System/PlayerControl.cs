// GENERATED AUTOMATICALLY FROM 'Assets/Input System/PlayerControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControl"",
    ""maps"": [
        {
            ""name"": ""Control"",
            ""id"": ""a1036ce2-641a-49a6-9b62-596bf1832fa9"",
            ""actions"": [
                {
                    ""name"": ""LeftStick"",
                    ""type"": ""Value"",
                    ""id"": ""be4b1d7c-727c-40d7-bace-be525591ade2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""StickDeadzone(min=0.4)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightStick"",
                    ""type"": ""Value"",
                    ""id"": ""9d9cfd6b-a144-46c3-add8-7eea643293da"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""StickDeadzone(min=0.4)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LBump"",
                    ""type"": ""Button"",
                    ""id"": ""3b8e483f-419b-4c14-8ab0-fb0c3336b72e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RBump"",
                    ""type"": ""Value"",
                    ""id"": ""c5f0223f-8ab2-4eb3-81b4-8b25b3415275"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LShouder"",
                    ""type"": ""Button"",
                    ""id"": ""73843978-ec37-4823-bb41-63b71b113f4b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RShouder"",
                    ""type"": ""Button"",
                    ""id"": ""0ad62e3b-abea-4893-aaed-837a629e95d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LRShouder"",
                    ""type"": ""Button"",
                    ""id"": ""8ca01551-4ed9-4a32-8269-50d7c5746328"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""29ec9e35-5c8f-45ab-af0d-7424858e21a2"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""96505f49-e43d-4d53-ab9d-40f2db8e14ff"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""be2ac715-edc6-40af-9357-dd9c439a5bde"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ab1878a6-261d-4680-a5b9-c7a845f1f561"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a4614774-17b8-479e-b65c-76e380586cec"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""14c9ac42-7a80-446e-9e8b-daa196a30a31"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""752f7dd8-9ead-481c-a697-35de14c61021"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Setas"",
                    ""id"": ""dc77addf-3b0f-4584-a81e-23da29e32a76"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2cf20e99-1b47-4df9-aa4a-4b360f851800"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""71f14790-3190-4e7e-851b-28d0a217a96a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a74c7c6c-96e6-4eb1-b234-898f378ba262"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""dc0b91dc-f2f8-4199-9b2a-8f9444e11978"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3a1a8a2c-7dca-4478-8dd5-3fd07289644c"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LBump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b6d8eb2-bc0e-4fc2-85f9-a955e7ab63f5"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RBump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47891f96-d591-42f0-a3ae-82c27ab6d78d"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RBump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""439f769b-b5c6-454e-a370-a0b7fd1792a5"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LShouder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50fca7c7-250e-4887-944c-2c5c62fd85c2"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LShouder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac8182f3-5dbd-433f-aef1-a1dec136c756"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RShouder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6618ce70-2c96-4e38-9066-9a29e38abc94"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RShouder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""885b918f-17c3-46bd-8f0c-ff2f234d22c0"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LRShouder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""78e9ab5d-7e9c-44fc-810f-45538cff8509"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LRShouder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4fa246f5-5d67-461b-9e24-9e144741f31b"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LRShouder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""352c3779-7282-43b7-8e44-5390de3bac79"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LRShouder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Control
        m_Control = asset.FindActionMap("Control", throwIfNotFound: true);
        m_Control_LeftStick = m_Control.FindAction("LeftStick", throwIfNotFound: true);
        m_Control_RightStick = m_Control.FindAction("RightStick", throwIfNotFound: true);
        m_Control_LBump = m_Control.FindAction("LBump", throwIfNotFound: true);
        m_Control_RBump = m_Control.FindAction("RBump", throwIfNotFound: true);
        m_Control_LShouder = m_Control.FindAction("LShouder", throwIfNotFound: true);
        m_Control_RShouder = m_Control.FindAction("RShouder", throwIfNotFound: true);
        m_Control_LRShouder = m_Control.FindAction("LRShouder", throwIfNotFound: true);
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

    // Control
    private readonly InputActionMap m_Control;
    private IControlActions m_ControlActionsCallbackInterface;
    private readonly InputAction m_Control_LeftStick;
    private readonly InputAction m_Control_RightStick;
    private readonly InputAction m_Control_LBump;
    private readonly InputAction m_Control_RBump;
    private readonly InputAction m_Control_LShouder;
    private readonly InputAction m_Control_RShouder;
    private readonly InputAction m_Control_LRShouder;
    public struct ControlActions
    {
        private @PlayerControl m_Wrapper;
        public ControlActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftStick => m_Wrapper.m_Control_LeftStick;
        public InputAction @RightStick => m_Wrapper.m_Control_RightStick;
        public InputAction @LBump => m_Wrapper.m_Control_LBump;
        public InputAction @RBump => m_Wrapper.m_Control_RBump;
        public InputAction @LShouder => m_Wrapper.m_Control_LShouder;
        public InputAction @RShouder => m_Wrapper.m_Control_RShouder;
        public InputAction @LRShouder => m_Wrapper.m_Control_LRShouder;
        public InputActionMap Get() { return m_Wrapper.m_Control; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlActions set) { return set.Get(); }
        public void SetCallbacks(IControlActions instance)
        {
            if (m_Wrapper.m_ControlActionsCallbackInterface != null)
            {
                @LeftStick.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftStick;
                @LeftStick.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftStick;
                @LeftStick.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftStick;
                @RightStick.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightStick;
                @RightStick.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightStick;
                @RightStick.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightStick;
                @LBump.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnLBump;
                @LBump.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnLBump;
                @LBump.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnLBump;
                @RBump.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnRBump;
                @RBump.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnRBump;
                @RBump.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnRBump;
                @LShouder.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnLShouder;
                @LShouder.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnLShouder;
                @LShouder.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnLShouder;
                @RShouder.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnRShouder;
                @RShouder.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnRShouder;
                @RShouder.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnRShouder;
                @LRShouder.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnLRShouder;
                @LRShouder.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnLRShouder;
                @LRShouder.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnLRShouder;
            }
            m_Wrapper.m_ControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftStick.started += instance.OnLeftStick;
                @LeftStick.performed += instance.OnLeftStick;
                @LeftStick.canceled += instance.OnLeftStick;
                @RightStick.started += instance.OnRightStick;
                @RightStick.performed += instance.OnRightStick;
                @RightStick.canceled += instance.OnRightStick;
                @LBump.started += instance.OnLBump;
                @LBump.performed += instance.OnLBump;
                @LBump.canceled += instance.OnLBump;
                @RBump.started += instance.OnRBump;
                @RBump.performed += instance.OnRBump;
                @RBump.canceled += instance.OnRBump;
                @LShouder.started += instance.OnLShouder;
                @LShouder.performed += instance.OnLShouder;
                @LShouder.canceled += instance.OnLShouder;
                @RShouder.started += instance.OnRShouder;
                @RShouder.performed += instance.OnRShouder;
                @RShouder.canceled += instance.OnRShouder;
                @LRShouder.started += instance.OnLRShouder;
                @LRShouder.performed += instance.OnLRShouder;
                @LRShouder.canceled += instance.OnLRShouder;
            }
        }
    }
    public ControlActions @Control => new ControlActions(this);
    public interface IControlActions
    {
        void OnLeftStick(InputAction.CallbackContext context);
        void OnRightStick(InputAction.CallbackContext context);
        void OnLBump(InputAction.CallbackContext context);
        void OnRBump(InputAction.CallbackContext context);
        void OnLShouder(InputAction.CallbackContext context);
        void OnRShouder(InputAction.CallbackContext context);
        void OnLRShouder(InputAction.CallbackContext context);
    }
}

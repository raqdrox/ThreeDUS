// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controls/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""59ce27a2-796b-4f99-a906-9af0982ad7bc"",
            ""actions"": [
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""780fc1dc-6471-40dd-bf2d-2f41f80f898e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""5814544c-55bb-421d-a1a3-460ceafc6b05"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraSwitch"",
                    ""type"": ""Button"",
                    ""id"": ""ed559f04-89fe-4428-a010-9e3f3474a759"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FpsLook"",
                    ""type"": ""PassThrough"",
                    ""id"": ""30849de7-f285-4f42-9cab-4f38d0356745"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Kill"",
                    ""type"": ""Button"",
                    ""id"": ""acce616a-adde-4d28-bd2c-816d837d4aee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Report"",
                    ""type"": ""Button"",
                    ""id"": ""e7f2148c-afab-4635-9fec-019b640244bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9107fd9d-b7ed-4c11-b4dc-03a25a377fb8"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ec53aa98-f82c-4944-b30c-bfd4975384fb"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""df2a8ac3-ff4e-4937-9e3f-448c83674b06"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e9f2ca0e-cae5-46bf-b5b0-6d951377e069"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f950341e-5a76-4040-bb42-0026b49e0327"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9ce9a8df-61d7-4d66-82a9-8208c027a1b0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b6233a83-98f8-4dd9-9ce6-d19f8ebeefba"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""CameraSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6d87c01-919f-4aa3-8982-e59e2cc08f1e"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""FpsLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20bfd75a-4759-49c6-84c5-e41c4812347f"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Kill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a09d8f00-962b-49f3-b098-c8edc5ae11f7"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Report"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""TaskUI"",
            ""id"": ""76bc8e9b-8f3d-48e3-b250-6e391bd542c4"",
            ""actions"": [
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""c4d35653-be0c-406f-b782-cad3247c54df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ef2c6fbd-477f-4c34-820f-e567dd6b7724"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard/Mouse"",
            ""bindingGroup"": ""Keyboard/Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Use = m_Player.FindAction("Use", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_CameraSwitch = m_Player.FindAction("CameraSwitch", throwIfNotFound: true);
        m_Player_FpsLook = m_Player.FindAction("FpsLook", throwIfNotFound: true);
        m_Player_Kill = m_Player.FindAction("Kill", throwIfNotFound: true);
        m_Player_Report = m_Player.FindAction("Report", throwIfNotFound: true);
        // TaskUI
        m_TaskUI = asset.FindActionMap("TaskUI", throwIfNotFound: true);
        m_TaskUI_Cancel = m_TaskUI.FindAction("Cancel", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Use;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_CameraSwitch;
    private readonly InputAction m_Player_FpsLook;
    private readonly InputAction m_Player_Kill;
    private readonly InputAction m_Player_Report;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Use => m_Wrapper.m_Player_Use;
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @CameraSwitch => m_Wrapper.m_Player_CameraSwitch;
        public InputAction @FpsLook => m_Wrapper.m_Player_FpsLook;
        public InputAction @Kill => m_Wrapper.m_Player_Kill;
        public InputAction @Report => m_Wrapper.m_Player_Report;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Use.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse;
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @CameraSwitch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraSwitch;
                @CameraSwitch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraSwitch;
                @CameraSwitch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraSwitch;
                @FpsLook.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFpsLook;
                @FpsLook.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFpsLook;
                @FpsLook.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFpsLook;
                @Kill.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKill;
                @Kill.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKill;
                @Kill.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKill;
                @Report.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReport;
                @Report.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReport;
                @Report.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReport;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @CameraSwitch.started += instance.OnCameraSwitch;
                @CameraSwitch.performed += instance.OnCameraSwitch;
                @CameraSwitch.canceled += instance.OnCameraSwitch;
                @FpsLook.started += instance.OnFpsLook;
                @FpsLook.performed += instance.OnFpsLook;
                @FpsLook.canceled += instance.OnFpsLook;
                @Kill.started += instance.OnKill;
                @Kill.performed += instance.OnKill;
                @Kill.canceled += instance.OnKill;
                @Report.started += instance.OnReport;
                @Report.performed += instance.OnReport;
                @Report.canceled += instance.OnReport;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // TaskUI
    private readonly InputActionMap m_TaskUI;
    private ITaskUIActions m_TaskUIActionsCallbackInterface;
    private readonly InputAction m_TaskUI_Cancel;
    public struct TaskUIActions
    {
        private @InputMaster m_Wrapper;
        public TaskUIActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Cancel => m_Wrapper.m_TaskUI_Cancel;
        public InputActionMap Get() { return m_Wrapper.m_TaskUI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TaskUIActions set) { return set.Get(); }
        public void SetCallbacks(ITaskUIActions instance)
        {
            if (m_Wrapper.m_TaskUIActionsCallbackInterface != null)
            {
                @Cancel.started -= m_Wrapper.m_TaskUIActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_TaskUIActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_TaskUIActionsCallbackInterface.OnCancel;
            }
            m_Wrapper.m_TaskUIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
            }
        }
    }
    public TaskUIActions @TaskUI => new TaskUIActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard/Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnUse(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnCameraSwitch(InputAction.CallbackContext context);
        void OnFpsLook(InputAction.CallbackContext context);
        void OnKill(InputAction.CallbackContext context);
        void OnReport(InputAction.CallbackContext context);
    }
    public interface ITaskUIActions
    {
        void OnCancel(InputAction.CallbackContext context);
    }
}

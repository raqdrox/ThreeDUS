using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace FrostyScripts.PlayerSystem
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private PlayerInput playerInput;
        private PlayerMaster _Player;


        [SerializeField] private InputAction MovementInput;
        [SerializeField] private InputAction CamInput;
        [SerializeField] private InputAction RunInput;
        [SerializeField] private InputAction JumpInput;
        [SerializeField] private InputAction KillInput;
        [SerializeField] private InputAction InteractInput;
        [SerializeField] private InputAction ReportInput;

        public Vector2 i_Movement => _Player._masterSettings.i_moveEnable ? MovementInput.ReadValue<Vector2>():Vector2.zero;
        public Vector2 i_Cam => _Player._masterSettings.i_camEnable ? CamInput.ReadValue<Vector2>():Vector2.zero;
        public bool i_Run => _Player._masterSettings._alwaysRun ? true: RunInput.ReadValue<float>() == 1f;
        public bool i_Jump => _Player._masterSettings.i_jumpEnable ? JumpInput.ReadValue<float>() == 1f:false;
        public InputAction i_Kill => _Player._masterSettings.i_KillEnable? KillInput:null;
        public InputAction i_Interact => _Player._masterSettings.i_InteractEnable ? InteractInput: null;
        public InputAction i_Report => _Player._masterSettings.i_InteractEnable ? ReportInput: null;

        private void Awake()
        {
            playerInput = new PlayerInput();
            _Player = GetComponent<PlayerMaster>();

        }

        private void OnEnable()
        {
            MovementInput.Enable();
            CamInput.Enable();
            RunInput.Enable();
            JumpInput.Enable();
            KillInput.Enable();
            InteractInput.Enable();
            ReportInput.Enable();
        }
        private void OnDisable()
        {
            MovementInput.Disable();
            CamInput.Disable();
            RunInput.Disable();
            JumpInput.Disable();
            KillInput.Disable();
            InteractInput.Disable();
            ReportInput.Disable();
        }
    }
}
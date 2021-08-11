using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace FrostyPlayerSystem
{
    public class PlayerInputHandler : MonoBehaviour, IInputHandler
    {
        private PlayerInput playerInput;
        private PlayerMaster _Player;


        public Vector2 _movementAxis => _Player._masterSettings.i_moveEnable ? playerInput.CharacterControls.Move.ReadValue<Vector2>():Vector2.zero;
        public Vector2 _camAxis => _Player._masterSettings.i_camEnable ? playerInput.CharacterControls.Look.ReadValue<Vector2>():Vector2.zero;
        public bool _runInput => _Player._masterSettings._alwaysRun ? true:playerInput.CharacterControls.Run.ReadValue<float>() == 1f;
        public bool _jumpInput => _Player._masterSettings.i_jumpEnable ? playerInput.CharacterControls.Jump.ReadValue<float>() == 1f:false;
        public bool _miscKey1 => _Player._masterSettings.i_misc1Enable?playerInput.Abilities.MiscKey1.ReadValue<float>() == 1f:false;
        public bool _miscKey2 => _Player._masterSettings.i_misc2Enable ? playerInput.Abilities.MiscKey2.ReadValue<float>() == 1f: false;

        private void Awake()
        {
            playerInput = new PlayerInput();
            _Player = GetComponent<PlayerMaster>();

        }

        private void OnEnable()
        {
            playerInput.Abilities.Enable();
            playerInput.CharacterControls.Enable();
        }
        private void OnDisable()
        {
            playerInput.Abilities.Disable();
            playerInput.CharacterControls.Disable();
        }
    }
}
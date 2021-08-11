using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrostyPlayerSystem
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMaster : MonoBehaviour
    {
        
        public bool _isDummy = false;
        //Handler Components
        public PlayerMasterSettings _masterSettings;
        public IInputHandler _inputHandler;
        IMovementHandler _movementHandler;
        IAnimationHandler _animationHandler;
        public ICameraHandler _cameraHandler;
        public PlayerCollisionHandler _collisionHandler;
        public PlayerData _playerData;
        public PlayerActionHandler _actionHandler;
        
        /////////Movement/////////
        public CharacterController _characterController;
        public bool isGrounded => _characterController.isGrounded;

        ////////Animation////////
        public Animator _animator;

        ////////Camera////////
        public Transform _lookAt;
        public Transform _Camera;

        ////////Actions////////
        
        public GameObject _playerMid;

        private void Awake()
        {
            //Handler Initializations
            _inputHandler = GetComponent<IInputHandler>();
            _movementHandler = GetComponent<IMovementHandler>();
            _animationHandler = GetComponent<IAnimationHandler>();
            _cameraHandler = GetComponent<ICameraHandler>();
            _playerData = GetComponent<PlayerData>();
            _actionHandler = GetComponent<PlayerActionHandler>();

            //Caching
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponentInChildren<Animator>();
        }
    
        public void SetPlayerData(int id, Color color ,PlayerRole role=PlayerRole.Crewmate,PlayerState state=PlayerState.Alive)
        {
            _playerData._role = role;
            _playerData._playerID = id;
            _playerData._playerColor = color;
            ChangePlayerState(state);
            
            Debug.Log("Player Data Set");
        }

        public void ChangePlayerState(PlayerState state=PlayerState.Dead)
        {
            _playerData._state = state;
            switch (state)
            {
                case PlayerState.Alive:
                    transform.gameObject.layer = _masterSettings._playerLayer;
                    SetLayerRecursively(gameObject, _masterSettings._playerLayer);
                    break;
                case PlayerState.Dead:
                    transform.gameObject.layer =_masterSettings._ghostLayer;
                    SetLayerRecursively(gameObject, _masterSettings._ghostLayer);
                    break;
                default:
                    break;
            }
        }
        public static void SetLayerRecursively(GameObject go, int layerNumber)
        {
            foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
            {
                trans.gameObject.layer = layerNumber;
            }
        }
    }
}
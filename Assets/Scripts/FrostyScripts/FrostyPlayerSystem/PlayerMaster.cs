using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TDUS_Scripts.Data;

//Behavior
//Client Side

namespace FrostyScripts.PlayerSystem
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMaster : NetworkBehaviour
    {
        #region Toggles

        public bool CanMove;
        public bool CanLook;
        public bool CanInteract;
        public bool CanKill;
        public bool CanReport;

        #endregion



        //-------------------------------
        public bool _isDummy = false;
        //Handler Components
        public PlayerMeshHandler _meshHandler;
        public PlayerMasterSettings _masterSettings;
        public PlayerInputHandler _inputHandler;
        PlayerMovementHandler _movementHandler;
        PlayerAnimationHandler _animationHandler;
        public PlayerCollisionHandler _collisionHandler;
        public PlayerData _playerData;
        public PlayerInteractionHandler _actionHandler;
        
        /////////Movement/////////
        public CharacterController _characterController;
        public bool isGrounded => _characterController.isGrounded;

        ////////Animation////////
        public Animator _animator;

        ////////Camera////////
        //public Transform _lookAt;
        public CameraMovementHandler _cameraHandler;
        public Transform _CameraPos;

        ////////Actions////////
        public GameObject _playerMid;






        private void Awake()
        {
            
            //Caching
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponentInChildren<Animator>();
        }
    
        public void SetupPlayer(PlayerData data,Material playerMat)
        {
            Debug.Log("Setting player");
            _playerData = data;
            Debug.Log("Player Data Set");
            ChangePlayerState(data._state);
            Debug.Log("Player State Set");
            _meshHandler.SetPlayerMaterial(playerMat);
            Debug.Log("Player Mat Set");
        }   
        //public void SetPlayerData(int id, Color color ,PlayerRole role=PlayerRole.Crewmate,PlayerState state=PlayerState.Alive)
        //{
         //   _playerData._role = role;
         //   _playerData._playerID = id;
         //   _playerData._playerColor = color;
         //   ChangePlayerState(state);
            
        //    Debug.Log("Player Data Set");
       // }

        public void ChangePlayerState(PlayerState state=PlayerState.Dead)
        {
            _playerData._state = state;
            _collisionHandler.UpdatePlayerCollisionState();
        }


        public int GetPlayerID() => _playerData._playerID;


        public void TogglePlayerMovement(bool toggle)
        {
            CanMove = toggle;
            CanLook = toggle;
        }

        
    }
}
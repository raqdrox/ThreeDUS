using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrostyScripts.PlayerSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/PlayerMasterSettings")]
    public class PlayerMasterSettings : ScriptableObject
    {
        [Header("Gameplay Bools")]
        public bool _alwaysRun = true;

        [Header("Input Settings")]
        public bool i_moveEnable = true;
        public bool i_jumpEnable = true;
        public bool i_runEnable = true;
        public bool i_camEnable = true;
        public bool i_KillEnable = true;
        public bool i_InteractEnable = true;

        [Header("Movement Settings")]
        public float _walkSpeed = 6;
        public float _backwalkSpeed = 2;
        public float _runSpeed = 6;
        public float _backrunSpeed = 3;
        public float _jumpSpeed = 3f;
        public float _gravity = 9.8f;
        public float _forceDivider = 10f;
        public bool _enableVertMove = true;

        [Header("Animation Settings")]
        public float _blendAccelerate = 4.0f;
        public float _blendDeccelerate = 4.0f;
        public float _maxWalkVelocity = 0.5f;
        public float _maxRunVelocity = 2.0f;

        public bool a_moveEnable = true;
        public bool a_runEnable = true;
        public bool a_jumpEnable = false;


        [Header("Camera Settings")]

        public float distance = 10.0f;
        public float sensivity = 4.0f;

        public float SensitivityX = 4.0f;
        public bool InvertX = false;

        public float SensitivityY = 4.0f;
        public bool InvertY = false;

        public float YClampMin = -50.0f;
        public float YClampMax = 50.0f;

        [Header("Layer Settings")] //layerNumber = Mathf.Log(myLayer.value, 2)
        public LayerMask _groundLayer ;
        public LayerMask _envLayer ;
        public LayerMask _playerLayer ;
        public LayerMask _bodyLayer ;
        public LayerMask _ghostLayer ;

        [Header("Activation Range Settings")]
        public int _actRange = 5;

        
    }
}
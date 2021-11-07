using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace FrostyScripts.PlayerSystem
{
    public class PlayerMovementHandler : NetworkBehaviour
    {

        PlayerMaster _Player;

        [Header("Debug")]
        [SerializeField] private Vector3 _moveDirection;


        private bool PlayerJumped => _Player.isGrounded && _Player._inputHandler.i_Jump;

        private void Awake()
        {
            _Player = GetComponent<PlayerMaster>();
        }

        private void HorizontalMove()
        {

            Vector2 movement = _Player._inputHandler.i_Movement;
            float currentSpeed = _Player._inputHandler.i_Run ? (movement.y < 0f ? _Player._masterSettings._backrunSpeed : _Player._masterSettings._runSpeed) : (movement.y < 0f ? _Player._masterSettings._backwalkSpeed : _Player._masterSettings._walkSpeed);
            Vector3 inputDirection = new Vector3(movement.x, 0f, movement.y).normalized;
            Vector3 transformDirection = transform.TransformDirection(inputDirection);
            Vector3 flatMovement = currentSpeed * Time.deltaTime * transformDirection;

            _moveDirection = new Vector3(flatMovement.x, _moveDirection.y, flatMovement.z);

        }

        void RotationHandler()
        {
            transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        }

        private void Move()
        {
            HorizontalMove();
            if(_Player._masterSettings._enableVertMove)
                VerticalMove();

            _Player._characterController.Move(_moveDirection);

        }
        private void VerticalMove()
        {
            if (PlayerJumped)
                _moveDirection.y = _Player._masterSettings._jumpSpeed * (1 / _Player._masterSettings._forceDivider);
            else if (_Player._characterController.isGrounded)
                _moveDirection.y = 0f;
            else
                _moveDirection.y -= _Player._masterSettings._gravity * Time.deltaTime * (1 / _Player._masterSettings._forceDivider);
        }

        private void FixedUpdate()
        {
            if (!isLocalPlayer) return;
            if (_Player.CanMove)
            {
                RotationHandler();
                Move();
            }
        }
    }
}

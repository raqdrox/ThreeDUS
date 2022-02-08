using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
namespace FrostyScripts.PlayerSystem
{
    public class PlayerAnimationHandler : NetworkBehaviour
    {

        private PlayerMaster _Player;

        int JumpingHash;
        int RunningHash;
        int GroundedHash;

        int VelocityZHash;
        int VelocityXHash;

        float _VelocityZ = 0f;
        float _VelocityX = 0f;


        private void Awake()
        {
            _Player = GetComponent<PlayerMaster>();
            VelocityXHash = Animator.StringToHash("VelocityX");
            VelocityZHash = Animator.StringToHash("VelocityZ");
            JumpingHash = Animator.StringToHash("Trigger_Jump");
            RunningHash = Animator.StringToHash("isRunning");
            GroundedHash = Animator.StringToHash("isGrounded");
        }

        void AnimHandler()
        {

            if (_Player._masterSettings.a_runEnable)
                _Player._animator.SetBool(RunningHash, _Player._inputHandler.i_Run);
            if (_Player._masterSettings.a_jumpEnable)
                _Player._animator.SetBool(GroundedHash, _Player.isGrounded);
            if (_Player._inputHandler.i_Jump && _Player.isGrounded && _Player._masterSettings.a_jumpEnable)
                _Player._animator.SetBool(JumpingHash, true);

            if (_Player._masterSettings.a_moveEnable)
                BlendHandler();


        }

        private void BlendHandler()
        {
            Vector2 movement = _Player._inputHandler.i_Movement;

            bool runPressed = _Player._masterSettings.a_runEnable ? _Player._inputHandler.i_Run : false;

            bool leftPressed = movement.x < 0f;
            bool rightPressed = movement.x > 0f;
            bool forwardPressed = movement.y > 0f;
            bool backwardPressed = movement.y < 0f;
            float currentMaxVelocity = runPressed ? _Player._masterSettings._maxRunVelocity : _Player._masterSettings._maxWalkVelocity;

            BlendChangeVelocity(forwardPressed, backwardPressed, rightPressed, leftPressed, runPressed, currentMaxVelocity);
            BlendLockVelocity(forwardPressed, backwardPressed, rightPressed, leftPressed, runPressed, currentMaxVelocity);

            _Player._animator.SetFloat(VelocityXHash, _VelocityX);
            _Player._animator.SetFloat(VelocityZHash, _VelocityZ);
        }

        void BlendChangeVelocity(bool forwardPressed, bool backwardPressed, bool rightPressed, bool leftPressed, bool runPressed, float currentMaxVelocity)
        {
            if (forwardPressed && _VelocityZ < currentMaxVelocity)
            {
                _VelocityZ += Time.deltaTime * _Player._masterSettings._blendAccelerate;
            }

            if (backwardPressed && _VelocityZ > -currentMaxVelocity)
            {
                _VelocityZ -= Time.deltaTime * _Player._masterSettings._blendAccelerate;
            }

            if (leftPressed && _VelocityX > -currentMaxVelocity)
            {
                _VelocityX -= Time.deltaTime * _Player._masterSettings._blendAccelerate;
            }

            if (rightPressed && _VelocityX < currentMaxVelocity)
            {
                _VelocityX += Time.deltaTime * _Player._masterSettings._blendAccelerate;
            }

            if (!backwardPressed && _VelocityZ < 0.0f)
            {
                _VelocityZ += Time.deltaTime * _Player._masterSettings._blendDeccelerate;
            }

            if (!forwardPressed && _VelocityZ > 0.0f)
            {
                _VelocityZ -= Time.deltaTime * _Player._masterSettings._blendDeccelerate;
            }

            if (!leftPressed && _VelocityX < 0.0f)
            {
                _VelocityX += Time.deltaTime * _Player._masterSettings._blendDeccelerate;
            }

            if (!rightPressed && _VelocityX > 0.0f)
            {
                _VelocityX -= Time.deltaTime * _Player._masterSettings._blendDeccelerate;
            }
        }

        void BlendLockVelocity(bool forwardPressed, bool backwardPressed, bool rightPressed, bool leftPressed, bool runPressed, float currentMaxVelocity)
        {
            if (!forwardPressed && !backwardPressed && _VelocityZ != 0.0f && (_VelocityZ > -0.05f && _VelocityZ < 0.05f))
            {
                _VelocityZ = 0.0f;
            }

            if (!leftPressed && !rightPressed && _VelocityX != 0.0f && (_VelocityX > -0.05f && _VelocityX < 0.05f))
            {
                _VelocityX = 0.0f;
            }

            //forward
            if (forwardPressed && runPressed && _VelocityZ > currentMaxVelocity)
            {
                _VelocityZ = currentMaxVelocity;
            }
            else if (forwardPressed && _VelocityZ > currentMaxVelocity)
            {
                _VelocityZ -= Time.deltaTime * _Player._masterSettings._blendDeccelerate;
                if (_VelocityZ > currentMaxVelocity && _VelocityZ < (currentMaxVelocity + 0.05f))
                {
                    _VelocityZ = currentMaxVelocity;
                }
            }
            else if (forwardPressed && _VelocityZ < currentMaxVelocity && _VelocityZ > (currentMaxVelocity - 0.05f))
            {
                _VelocityZ = currentMaxVelocity;
            }
            //Back
            if (backwardPressed && runPressed && _VelocityZ < -currentMaxVelocity)
            {
                _VelocityZ = -currentMaxVelocity;
            }
            else if (backwardPressed && _VelocityZ < -currentMaxVelocity)
            {
                _VelocityZ += Time.deltaTime * _Player._masterSettings._blendDeccelerate;
                if (_VelocityZ < -currentMaxVelocity && _VelocityZ < (-currentMaxVelocity - 0.05f))
                {
                    _VelocityZ = -currentMaxVelocity;
                }
            }
            else if (backwardPressed && _VelocityZ > -currentMaxVelocity && _VelocityZ < (-currentMaxVelocity + 0.05f))
            {
                _VelocityZ = -currentMaxVelocity;
            }
            //Left
            if (leftPressed && runPressed && _VelocityX < -currentMaxVelocity)
            {
                _VelocityX = -currentMaxVelocity;
            }

            else if (leftPressed && _VelocityX < -currentMaxVelocity)
            {
                _VelocityX += Time.deltaTime * _Player._masterSettings._blendDeccelerate;
                if (_VelocityX < -currentMaxVelocity && _VelocityX > (-currentMaxVelocity - 0.05f))
                {
                    _VelocityX = -currentMaxVelocity;
                }
            }
            else if (leftPressed && _VelocityX > -currentMaxVelocity && _VelocityX < (-currentMaxVelocity + 0.05f))
            {
                _VelocityX = -currentMaxVelocity;
            }

            //Right
            if (rightPressed && runPressed && _VelocityX > currentMaxVelocity)
            {
                _VelocityX = currentMaxVelocity;
            }
            else if (rightPressed && _VelocityX > currentMaxVelocity)
            {
                _VelocityX -= Time.deltaTime * _Player._masterSettings._blendDeccelerate;
                if (_VelocityX > currentMaxVelocity && _VelocityX < (currentMaxVelocity + 0.05f))
                {
                    _VelocityX = currentMaxVelocity;
                }
            }
            else if (rightPressed && _VelocityX < currentMaxVelocity && _VelocityX > (currentMaxVelocity - 0.05f))
            {
                _VelocityX = currentMaxVelocity;
            }
        }
        [Client]
        private void FixedUpdate()
        {
            if (!isLocalPlayer) return;
            AnimHandler();
        }
    }
}
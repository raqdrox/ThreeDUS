using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrostyPlayerSystem
{
    public class PlayerActionHandler : ActionHandler
    {
        private PlayerMaster _Player;

        public bool _isenabled = true;

        private void Awake()
        {
            _Player = GetComponent<PlayerMaster>();
        }
        void KeyHandler_a()
        {
            if (!_isenabled)
                return;

            if (_Player._playerData._role == PlayerRole.Imposter)
            {
                Kill();  
            }
            else
            {
                Report();
            }
            StartCoroutine(CoolDown(5));
            
        }

        void KeyHandler_b()
        {
            
        }

        IEnumerator CoolDown(int cdtime = 5)
        {
            _isenabled = false;
            yield return new WaitForSeconds(cdtime);
            _isenabled = true;
        }


        public void Die()
        {
            _Player.ChangePlayerState(PlayerState.Dead);
            print("Dead");

        }

        public void Revive()
        {
            _Player.ChangePlayerState(PlayerState.Alive);
            print("Alive");

        }

        void Kill()
        {
            if (_Player._playerData._state == PlayerState.Dead)
                return;
            PlayerMaster plr =_Player._collisionHandler.GetClosestPlayerInRange();
            if (plr != null)
            {
                print(plr);
                plr._actionHandler.Die();
                //trigger event
            }

        }

        void Report()
        {

        }
        
        void Task()
        {
            
        }

        private void Update()
        {
            if (_isenabled && !_Player._isDummy)
            { 
                if (_Player._inputHandler._miscKey1)
                    KeyHandler_a();
                if (_Player._inputHandler._miscKey2)
                    KeyHandler_b();
            }
        }
    }
}
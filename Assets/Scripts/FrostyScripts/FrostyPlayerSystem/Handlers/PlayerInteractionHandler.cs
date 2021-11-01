using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TDUS_Scripts;
namespace FrostyScripts.PlayerSystem
{
    public class PlayerInteractionHandler : MonoBehaviour
    {
        private PlayerMaster _Player;

        public bool _isenabled = true;
        [SerializeField]private LayerMask interactLayer;

        private void Awake()
        {
            _Player = GetComponent<PlayerMaster>();
        }


        private void OnEnable()
        {
            _Player._inputHandler.i_Interact.performed += Interact;
        }
        private void OnDisable()
        {
            _Player._inputHandler.i_Interact.performed += Interact;
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

        public void ChangePlayerInteractionState(PlayerInteractionState state)
        {
            _Player._playerData._intState = state;
            switch (state)
            {
                case PlayerInteractionState.FREE:
                    _Player.TogglePlayerMovement(true);
                    break;
                case PlayerInteractionState.TASK:
                    _Player.TogglePlayerMovement(false);
                    break;
                case PlayerInteractionState.CAM:
                    _Player.TogglePlayerMovement(false);
                    break;
                default:
                    break;
            }
        }
        void Interact(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed) 
            {
                RaycastHit hit;
                Ray ray = _Player._cameraHandler._Camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

                if(Physics.Raycast(ray , out hit , interactLayer))
                {
                    if (hit.transform.tag == "Interactables")
                    {
                        if (!hit.transform.GetChild(0).gameObject.activeInHierarchy)
                            return;
                        Task_Interactable temp = hit.transform.GetComponent<Task_Interactable>();
                        temp.Trigger(_Player);
                    }
                }

            }
        }


    }
}
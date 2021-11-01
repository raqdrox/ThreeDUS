using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrostyScripts.Events;
using FrostyScripts.PlayerSystem;
namespace TDUS_Scripts
{
    public class Task_Interactable : MonoBehaviour
    {
        [SerializeField]private GameObject TaskPrefab;
        GameObject highlight;

        Task _currTask=null;

        private void OnEnable()
        {
            highlight = transform.GetChild(0).gameObject;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag=="Player")
            {
                highlight.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                highlight.SetActive(false);
            }
        }

        public void Trigger(PlayerMaster User)
        {


            //Check Player Task Availability
            if (User._playerData._intState != PlayerInteractionState.FREE && _currTask != null)
            {
                Debug.Log("Canceling Current Task");
                _currTask.EndTask();
                Destroy(_currTask.gameObject);
                _currTask = null;
                User._actionHandler.ChangePlayerInteractionState(PlayerInteractionState.FREE);
                return;
            }
            if (User._playerData._intState != PlayerInteractionState.FREE && _currTask == null)
            {
                Debug.LogWarning("Trigger Warning : Player Interaction State is not FREE. Resetting Player Interaction State");
                User._actionHandler.ChangePlayerInteractionState(PlayerInteractionState.FREE);
                return;
            }
            if (User._playerData._intState == PlayerInteractionState.FREE && _currTask != null)
            {
                Debug.LogWarning("Trigger Warning : Interactable Has A Previous Task Enabled");
            }
            if (User._playerData._intState == PlayerInteractionState.FREE && _currTask != null)
            {
                _currTask = Instantiate(TaskPrefab).GetComponent<Task>();
                _currTask.StartTask(User);
            }
            
        }

    }
}
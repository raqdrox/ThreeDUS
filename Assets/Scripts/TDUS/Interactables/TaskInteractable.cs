using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrostyScripts.Events;
using FrostyScripts.PlayerSystem;

//Behavior

//Client Side


namespace TDUS_Scripts.Interactions
{
    public class TaskInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField]private Task TaskObject=null;
        [SerializeField] GameObject Highlight;

        public bool IsEnabled;

        public bool Usable { get => IsEnabled; set => IsEnabled = value; }


        private void OnTriggerEnter(Collider other)
        {
            if(other.tag=="Player")
            {
                Highlight.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                Highlight.SetActive(false);
            }
        }

        public void Trigger(PlayerMaster User)
        {
            if (TaskObject.TaskCompleted || !IsEnabled)
                return;

            if (User._playerData._intState != PlayerInteractionState.FREE && TaskObject.TaskRunning)
            {
                Debug.Log("Canceling Current Task");
                TaskObject.EndTask();
                TaskObject.ResetTask();
                User._actionHandler.ChangePlayerInteractionState(PlayerInteractionState.FREE);
                return;
            }
            if (User._playerData._intState != PlayerInteractionState.FREE && !TaskObject.TaskRunning)
            {
                Debug.LogWarning("Trigger Warning : Player Interaction State is not FREE. Resetting Player Interaction State");
                User._actionHandler.ChangePlayerInteractionState(PlayerInteractionState.FREE);
                return;
            }
            if (User._playerData._intState == PlayerInteractionState.FREE && TaskObject.TaskRunning)
            {
                Debug.LogWarning("Trigger Warning : Interactable Has A Previous Task Enabled");
            }
            if (User._playerData._intState == PlayerInteractionState.FREE && !TaskObject.TaskRunning)
            {
                TaskObject.ResetTask();
                TaskObject.StartTask(User);
            }
            
        }

    }
}
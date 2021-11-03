using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrostyScripts.PlayerSystem;
using FrostyScripts.Events;
using FrostyScripts.Misc;
using UnityEngine.UI;
using System;

//Behavior
//Client Side


namespace TDUS_Scripts.Interactions
{
    public class DummyTask : Task
    {
        private static new readonly TaskType Type=TaskType.DUMMY_TASK;


        [SerializeField] private GameObject TaskUI;
        [SerializeField] private Button TaskUIBtn;

        Coroutine taskloop=null;


        public override void StartTask(PlayerMaster usr)
        {
            IsRunning = true;
            User = usr;
            User._actionHandler.ChangePlayerInteractionState(PlayerInteractionState.TASK);
            taskloop=StartCoroutine(PlayTask());
        }


        IEnumerator PlayTask()
        {
            print("Playing task");
            TaskUI.SetActive(true);
            yield return new WaitForUIButtons(TaskUIBtn);
            TaskUI.SetActive(false);
            print("Ending task");
            IsComplete = true;
            taskloop = null;
            EndTask();
        }




        public override void EndTask()
        {
            IsRunning = false;
            if (taskloop != null)
                StopCoroutine(taskloop);
            
            User._actionHandler.ChangePlayerInteractionState(PlayerInteractionState.FREE);
            if (IsComplete)
                EventManager.TriggerEvent(GameEvents.CREWMATE_TASK_ENDED, new TaskFinishData(User.GetPlayerID(), TaskID));
        }

        public override void ResetTask()
        {
            IsComplete = false;
            TaskUI.SetActive(false);
        }
    }
}
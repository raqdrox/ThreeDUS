using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrostyScripts.PlayerSystem;
using FrostyScripts.Events;
using FrostyScripts.Misc;
using UnityEngine.UI;
using System;

namespace TDUS_Scripts
{
    public class DummyTask : Task
    {
        private static new readonly TaskType Type=TaskType.DUMMY_TASK;


        [SerializeField] private GameObject TaskUI;
        [SerializeField] private Button TaskUIBtn;



        public override void StartTask(PlayerMaster usr)
        {
            IsRunning = true;
            User = usr;
            User._actionHandler.ChangePlayerInteractionState(PlayerInteractionState.TASK);
            var t_startData = new TaskStartData();
            t_startData.Player = usr;
            t_startData.Type = Type;
            EventManager.TriggerEvent(GameEvents.CREWMATE_TASK_STARTED, t_startData);

            StartCoroutine(PlayTask());
        }


        IEnumerator PlayTask()
        {
            print("Playing task");
            TaskUI.SetActive(true);
            yield return new WaitForUIButtons(TaskUIBtn);
            TaskUI.SetActive(false);
            print("Ending task");
            EndTask();
        }




        public override void EndTask()
        {
            IsRunning = false;
            User._actionHandler.ChangePlayerInteractionState(PlayerInteractionState.FREE);
            var t_endData = new TaskEndData();
            t_endData.Player = User;
            t_endData.Type = Type;
            t_endData.TaskCompleted = IsComplete;
            EventManager.TriggerEvent(GameEvents.CREWMATE_TASK_ENDED, t_endData);
        }


    }
}
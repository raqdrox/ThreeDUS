using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrostyScripts.PlayerSystem;
using FrostyScripts.Events;
using FrostyScripts.Misc;
using UnityEngine.UI;
using System;
using Mirror;
using TDUS_Scripts.Managers;
//Behavior
//Client Side


namespace TDUS_Scripts.Interactions
{
    public class DummyTask : Task
    {
        public new TaskType Type=>TaskType.DUMMY_TASK;
        

        [SerializeField] private GameObject TaskUI;
        [SerializeField] private Button TaskUIBtn;
        Coroutine taskloop=null;

        [Client]
        public override void StartTask(PlayerMaster usr)
        {
            base.StartTask(usr);
            taskloop =StartCoroutine(PlayTask());
        }

        [Client]
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



        [Client]
        public override void EndTask()
        {
            if (taskloop != null)
                StopCoroutine(taskloop);

            //EventManager.TriggerEvent(GameEvents.CREWMATE_TASK_ENDED, new TaskFinishData(User.GetPlayerID(), TaskID));
            base.EndTask();
        }

        [Client]
        public override void ResetTask()
        {
            TaskUI.SetActive(false);
            base.ResetTask();

        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrostyScripts.PlayerSystem;
using UnityEditor;
using Mirror;
using TDUS_Scripts.Managers;
namespace TDUS_Scripts.Interactions
{
    public enum TaskType
    {
        DUMMY_TASK,
    }

    public abstract class Task : NetworkBehaviour
    {
        protected bool IsRunning = false;
        protected bool IsComplete = false;
        LevelTaskManager taskManager => LevelTaskManager.instance;
        protected PlayerMaster User=null;

        public TaskType Type { get; }

        public bool TaskRunning => IsRunning;

        public bool TaskCompleted => IsComplete;
        [Client]
        public virtual void StartTask(PlayerMaster usr)
        {

            ResetTask();
            print("task started");
            IsRunning = true;
            User = usr;
        }
        [Client]
        public virtual void EndTask()
        {
            IsRunning = false;
            taskManager.OnTaskEnded(User.GetPlayerID(), TaskCompleted);
            print("task ended");
        }
        [Client]
        public virtual void ResetTask()
        {
            IsRunning = false;
            IsComplete = false;
            User = null;
        }
 
    }


}
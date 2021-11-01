using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrostyScripts.PlayerSystem;
namespace TDUS_Scripts
{
    public enum TaskType
    {
        DUMMY_TASK,
    }

    public abstract class Task : MonoBehaviour
    {
        protected bool IsRunning = false;
        protected bool IsComplete = false;

        protected PlayerMaster User=null;

        protected static TaskType Type;

        public bool GetTaskStatus => IsRunning;

        public abstract void StartTask(PlayerMaster User);

        public abstract void EndTask();

         
    }


}
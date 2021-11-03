using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrostyScripts.PlayerSystem;
using UnityEditor;

namespace TDUS_Scripts.Interactions
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

        protected int TaskID=-1;

        protected static TaskType Type;

        public bool TaskRunning => IsRunning;

        public bool TaskCompleted => IsComplete;

        public abstract void StartTask(PlayerMaster User);

        public abstract void EndTask();

        public abstract void ResetTask();
 
    }


}
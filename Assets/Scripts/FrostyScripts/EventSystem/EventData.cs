using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrostyScripts.PlayerSystem;
using TDUS_Scripts;
namespace FrostyScripts.Events
{
    public abstract class EventData 
    {
        
    }

    public class TaskStartData : EventData
    {
        public PlayerMaster Player;
        public TaskType Type;
    }

    public class TaskEndData : EventData
    {
        public bool TaskCompleted;
        public PlayerMaster Player;
        public TaskType Type;
    }

    public class KillData : EventData
    {
        public PlayerMaster Culprit;
        public PlayerMaster Victim;
    }

    public class SabotageData : EventData
    {
        public PlayerMaster Culprit;
        public PlayerMaster Victim;
    }
    public class MeetingCallData : EventData
    {
        public PlayerMaster Caller;
        public bool Reported;
    }




}
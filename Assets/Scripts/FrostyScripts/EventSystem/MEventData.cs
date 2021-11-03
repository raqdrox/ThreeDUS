using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrostyScripts.PlayerSystem;
using TDUS_Scripts;
using TDUS_Scripts.Interactions;
namespace FrostyScripts.Events
{
    public interface MEventData { } // Marker Interface


    public class DummyEventData :  MEventData
    {
        public int PlayerID;

        public DummyEventData(int plr)
        {
            PlayerID = plr;
        }
    }

    public class TaskFinishData :  MEventData
    {
        public int PlayerID;
        public int TaskID;


        public TaskFinishData(int plrid, int taskid)
        {
            PlayerID = plrid;
            TaskID = taskid;
        }
    }

    public class KillData :  MEventData
    {
        public int KillerID;
        public int VictimID;


        public KillData(int cul, int vic)
        {
            KillerID = cul;
            VictimID = vic;
        }
    }

    public class SabotageData :  MEventData
    {
        public int PlayerID;
        public SabotageType Type;


        public SabotageData(int plr,SabotageType type)
        {
            PlayerID = plr;
            Type = type;
        }
    }
    public class MeetingCallData :  MEventData
    {
        public int PlayerID;
        public bool IsReport;


        public MeetingCallData(int plr,bool reported)
        {
            PlayerID = plr;
            IsReport = reported;
        }
    }




}
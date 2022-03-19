using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDUS_Scripts_OLD.Data;
namespace FrostyScripts.PlayerSystem
{
    public enum PlayerRole
    {
        Crewmate,
        Imposter
    }
    public enum PlayerState
    {
        Alive,
        Dead
    }

    public enum PlayerInteractionState
    {
        FREE,
        TASK,
        CAM
    }




    public class PlayerData 
    {
        public int _playerID;
        public PColor _playerColor;
        public PlayerRole _role;
        public PlayerState _state;
        public PlayerInteractionState _intState=PlayerInteractionState.FREE;
        public int CurrentTaskID=-1;
    }
}
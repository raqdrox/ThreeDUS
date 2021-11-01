using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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



    [CreateAssetMenu(menuName = "ThreeUSData/Player")]
    public class PlayerData : ScriptableObject
    {
        public int _playerID;
        public Color _playerColor;
        public PlayerRole _role;
        public PlayerState _state;
        public PlayerInteractionState _intState;
    }
}
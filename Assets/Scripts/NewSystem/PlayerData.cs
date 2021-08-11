using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrostyPlayerSystem
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
    public class PlayerData : MonoBehaviour
    {
        public int _playerID;
        public Color _playerColor;
        public PlayerRole _role;
        public PlayerState _state;

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrostyPlayerSystem;

public class TogglePlayerState : MonoBehaviour
{
    PlayerMaster _Player;
    bool alive = true;
    private void Awake()
    {
        _Player = GetComponent<PlayerMaster>();
    }

    public void ToggleState()
    {
        if (alive)
        { 
            _Player._actionHandler.Die(); 
            alive = false;
        }
        else
        {
            _Player._actionHandler.Revive();
            alive = true;
        }
    }
}

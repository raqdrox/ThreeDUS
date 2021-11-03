using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrostyScripts.Events;
using FrostyScripts.PlayerSystem;

namespace TDUS_Scripts
{
    public interface IInteractable
    {
        public bool Usable { get; set; }
        public void Trigger(PlayerMaster User);
    }
}
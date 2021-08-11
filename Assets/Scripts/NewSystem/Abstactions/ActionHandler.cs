using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrostyPlayerSystem
{
    public abstract class ActionHandler : MonoBehaviour
    {
        public virtual bool _enabled { get; set; }
    }
}
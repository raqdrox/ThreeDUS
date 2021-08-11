using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrostyPlayerSystem
{
    public class JumpAction : MonoBehaviour, IPlayerActions
    {
        public string _taskName => "Jump";

        public bool hasStartedAction => throw new System.NotImplementedException();

        public void EndAction()
        {
            throw new System.NotImplementedException();
        }

        public void Perform()
        {
            throw new System.NotImplementedException();
        }

        public void StartAction()
        {
            throw new System.NotImplementedException();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrostyPlayerSystem
{
    public class KillAction : MonoBehaviour, IPlayerActions
    {
        public string _taskName => "Kill";
        private bool _started = false;
        public bool hasStartedAction => _started;

        public void StartAction()
        {
            _started = true;
            Debug.Log("Started");
            Perform();
        }

        public void Perform()
        {
            Debug.Log("Performed");
            EndAction();
        }

        public void EndAction()
        {
            _started = false;
            Debug.Log("Ended");
        }
    }
}
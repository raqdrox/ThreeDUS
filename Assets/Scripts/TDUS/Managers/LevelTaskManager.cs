using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDUS_Scripts_OLD.Interactions;
using TDUS_Scripts_OLD.Data;
using Mirror;
using System;
using FrostyScripts.PlayerSystem;
//Manager
//Server Side
namespace TDUS_Scripts_OLD.Managers
{
    [Serializable]
    public class TaskMap
    {
        public int TaskID;
        public TaskType Type;
        public TaskInteractable InteractiveObj;
    }

    public class LevelTaskManager : NetworkBehaviour
    {
        public static LevelTaskManager instance;
        Dictionary<int, List<int>> PlayerAssignedTasks;
        List<int> GlobalActiveTasks;

        PlayerManager playerManager => PlayerManager.instance;

        [SerializeField] List<TaskMap> TaskConfig;

        [SerializeField] List<Task> TaskScripts;

        //public TaskInteractable GetTaskInteractableByID(int taskID) => TaskInteractables[taskID];

        private void Awake()
        {
            instance = this;
        }


        public List<int> GetTasksForPlayer(int playerID) => PlayerAssignedTasks[playerID];


        public bool IsPlayerAssignedTask(int playerID, int taskID) => true;//PlayerAssignedTasks[playerID].Contains(taskID);

        [Server]
        public void StartPlayerTask(int playerID, TaskInteractable interactable)
        {
            TaskMap taskData = GetTaskDataFor(interactable);
            if (!IsPlayerAssignedTask(playerID, taskData.TaskID))
                return;

            PlayTask(playerManager.GetConnFromID(playerID), GetTaskScriptFromType(taskData.Type),taskData.TaskID);

        }

        [Server] public TaskMap GetTaskDataFor(int taskid) => TaskConfig.Find(item => item.TaskID == taskid);
        [Server] public TaskMap GetTaskDataFor(TaskInteractable interactable) => TaskConfig.Find(item => item.InteractiveObj == interactable);

        [Server] public Task GetTaskScriptFromType(TaskType Type) => TaskScripts.Find(item=>item.Type==Type);


        [TargetRpc]
        public void PlayTask(NetworkConnection conn,Task task,int taskID)
        {
            var player = playerManager.GetPlayerObjectFromConn(conn);
            print(player);
            print(player.GetPlayerID());
            player._actionHandler.ChangePlayerInteractionState(PlayerInteractionState.TASK);
            player._playerData.CurrentTaskID = taskID;
            task.StartTask(player);
        }

        [Command(requiresAuthority = false)]
        public void OnTaskEnded(int playerID, bool completed)
        {
            var player = playerManager.GetPlayerObjectFromID(playerID);
            player._actionHandler.ChangePlayerInteractionState(PlayerInteractionState.FREE);
            if (!IsPlayerAssignedTask(playerID, player._playerData.CurrentTaskID))
            {
                Debug.LogError("Player Interacted With Unassigned Task");
            return; 
            }


            if (completed)
                print("completed Task");//Remove player._playerData.CurrentTaskID from assigned ids and do global stuff

            player._playerData.CurrentTaskID = -1;


        }



    }
}

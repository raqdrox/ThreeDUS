using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using FrostyScripts.PlayerSystem;
using TDUS_Scripts.Data;
using System.Linq;
using System;

namespace TDUS_Scripts.Managers
{
    
    public class PlayerManager : NetworkBehaviour
    {
        public static PlayerManager instance = null;
        [SerializeField] List<Transform> SpawnPoints;
        MatManager matManager=> MatManager.instance;

        List<PColor> AvailableColors = Enum.GetValues(typeof(PColor)).Cast<PColor>().ToList();
        List<int> AvailableIDs = Enumerable.Range(1, 10).ToList();

        Dictionary<NetworkConnection, PlayerMaster> SpawnedPlayers = new Dictionary<NetworkConnection, PlayerMaster>(); // use MultiKeyDictionary for this

        private void Awake()
        {
            instance = this;
        }


        [Server]
        public GameObject SpawnPlayer(NetworkConnection conn,GameObject playerPrefab)
        {
            var spawn = GetSpawnPoint();
            var player = Instantiate(playerPrefab, spawn.position, spawn.rotation).GetComponent<PlayerMaster>();

            PlayerData data = GetDummyData();
            Material Pmat = matManager.GetMatFromPCol(data._playerColor);
            print(Pmat);
            player.SetupPlayer(data,Pmat);
            print("Done Setting up Player");
            SpawnedPlayers[conn] = player.GetComponent<PlayerMaster>();
            print("Spawned Player");
            return player.gameObject;
        }



        public void DespawnPlayer(NetworkConnection conn)
        {
            AvailableIDs.Add(SpawnedPlayers[conn]._playerData._playerID);
            AvailableIDs.Sort();
            AvailableColors.Add(SpawnedPlayers[conn]._playerData._playerColor);
        }


        [Server]
        public Transform GetSpawnPoint()
        {
            return SpawnPoints[UnityEngine.Random.Range(0, SpawnPoints.Count)];
        }
        

       [Server]
        public PlayerData GetDummyData()
        {
            var pdata = new PlayerData();
            pdata._intState = PlayerInteractionState.FREE;
            pdata._playerID = AvailableIDs[0];
            AvailableIDs.RemoveAt(0);
            pdata._role = PlayerRole.Crewmate;
            pdata._state = PlayerState.Alive;
            pdata._playerColor = AvailableColors[UnityEngine.Random.Range(0, AvailableColors.Count)];
            print(pdata._playerColor);
            AvailableColors.Remove(pdata._playerColor);
            return pdata;
        }
        [Server]
        public PlayerMaster GetPlayerObjectFromID(int id)
        { // use MultiKeyDictionary 
            return SpawnedPlayers.First(item => item.Value.GetPlayerID() == id).Value;
        }
        [Server]
        public PlayerMaster GetPlayerObjectFromConn(NetworkConnection conn)
        { // use MultiKeyDictionary 
            return SpawnedPlayers[conn];
        }
        [Server]
        public NetworkConnection GetConnFromID(int id)
        { // use MultiKeyDictionary 
            return SpawnedPlayers.First(item => item.Value.GetPlayerID() == id).Key;
        }
        

    }
}
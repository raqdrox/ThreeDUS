using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TDUS_Scripts.Data;
using FrostyScripts.PlayerSystem;
using System.Linq;
using System;

namespace TDUS_Scripts.Managers
{
    public class NetworkManagerTDUS : NetworkManager
    {
        [SerializeField] private PlayerData DefaultPlayerData;
        [SerializeField] List<Transform> SpawnPoints;
        [SerializeField] PlayerMaterials MatConfig;
        Dictionary<NetworkConnection,PlayerMaster> SpawnedPlayers = new Dictionary<NetworkConnection, PlayerMaster>();

        List<PColor> AvailableColors= Enum.GetValues(typeof(PColor)).Cast<PColor>().ToList();


        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            var player = SpawnPlayer(DefaultPlayerData, conn);
            NetworkServer.AddPlayerForConnection(conn, player); 
        }

        public GameObject SpawnPlayer(PlayerData data, NetworkConnection conn)
        {

            var spawn = GetSpawnPoint();
            var player = Instantiate(playerPrefab, spawn.position, spawn.rotation).GetComponent<PlayerMaster>();
            print(player);
            SpawnedPlayers[conn]= player;
            player._playerData = data;
            data._playerColor = AvailableColors[UnityEngine.Random.Range(0, AvailableColors.Count)];
            AvailableColors.Remove(data._playerColor);
            SetPlayerColor(player, data._playerColor);
            return player.gameObject;
        }

        public Transform GetSpawnPoint()
        {
            return SpawnPoints[UnityEngine.Random.Range(0, SpawnPoints.Count)];
        }

       // public PlayerMaster GetPlayerFromID(int id)
       // {
            //return SpawnedPlayers.First(item => item.Value.GetPlayerID() == id);
       // }

        public void SetPlayerColor(PlayerMaster player, PColor col)
        {
            player._meshHandler.SetPlayerMaterial(MatConfig.matmaps.First(item => item.color == col).mat);
        }
        public override void OnServerDisconnect(NetworkConnection conn)
        {
            AvailableColors.Add(SpawnedPlayers[conn]._playerData._playerColor);
            NetworkServer.DestroyPlayerForConnection(conn);
        }
    }
}
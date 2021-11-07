using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using FrostyScripts.PlayerSystem;
using TDUS_Scripts.Data;
using Mirror;
//Manager
//Server Side
namespace TDUS_Scripts.Managers
{

    public class PlayerManager : NetworkBehaviour
    {
        
        [SerializeField] GameObject PlayerPrefab;
        [SerializeField] List<Transform> SpawnPoints;
        [SerializeField] PlayerMaterials MatConfig;

        List<PlayerMaster> SpawnedPlayers = new List<PlayerMaster>();



        public GameObject SpawnPlayer(PlayerData data)
        {
            
            var spawn = GetSpawnPoint();
            var player = Instantiate(PlayerPrefab, spawn.position, spawn.rotation).GetComponent<PlayerMaster>();
            SpawnedPlayers.Add(player);
            player._playerData = data;
            SetPlayerColor(player,(PColor)Random.Range(0,3));
            return player.gameObject;
        }

        public Transform GetSpawnPoint()
        {
            return SpawnPoints[Random.Range(0, SpawnPoints.Count)];
        }

        public PlayerMaster GetPlayerFromID(int id)
        {
            return SpawnedPlayers.First(item => item.GetPlayerID() == id);
        }

        public void SetPlayerColor(PlayerMaster player,PColor col)
        {
            //player._meshHandler.SetPlayerMaterial(MatConfig._mats[col]);
        }

    }
}
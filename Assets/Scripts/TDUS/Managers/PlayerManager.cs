using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using FrostyScripts.PlayerSystem;

//Manager
//Server Side
namespace TDUS_Scripts.Managers
{

    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] GameObject PlayerPrefab;
        [SerializeField] List<Transform> SpawnPoints;

        List<PlayerMaster> SpawnedPlayers = new List<PlayerMaster>();



        public void SpawnPlayer(PlayerData data)
        {
            var player = Instantiate(PlayerPrefab, SpawnPoints[0].position,SpawnPoints[0].rotation).GetComponent<PlayerMaster>();
            print(player);
            SpawnedPlayers.Add(player);
            //SetPlayerSpawn(player);
            player._playerData = data;
            //object ownership stuff
        }

        public void SetPlayerSpawn(PlayerMaster player)
        {
            player.gameObject.transform.position = SpawnPoints[0].position;
            player.gameObject.transform.rotation = SpawnPoints[0].rotation;
        }

        public PlayerMaster GetPlayerFromID(int id)
        {
            return SpawnedPlayers.First(item => item.GetPlayerID() == id);
        }
        

    }
}
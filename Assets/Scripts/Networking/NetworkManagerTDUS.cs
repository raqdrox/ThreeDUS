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
        PlayerManager _playerManager => PlayerManager.instance;

        [Server]
        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            print("AddingPlayer");
            var player = _playerManager.SpawnPlayer(conn, playerPrefab);
            print(player);
            NetworkServer.AddPlayerForConnection(conn, player); 
        }

        [Server]
        public override void OnServerDisconnect(NetworkConnection conn)
        {
            _playerManager.DespawnPlayer(conn);
            NetworkServer.DestroyPlayerForConnection(conn);
        }
    }
}
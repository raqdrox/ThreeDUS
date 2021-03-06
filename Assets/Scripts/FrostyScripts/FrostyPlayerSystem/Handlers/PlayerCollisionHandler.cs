using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
namespace FrostyScripts.PlayerSystem
{
    public class PlayerCollisionHandler : NetworkBehaviour
    {
        private PlayerMaster _Player;
        public bool _ghostMode => false;

        //layermasks
        int _groundLayerMask => 1<< _Player._masterSettings._groundLayer;
        int _envLayerMask => 1 << _Player._masterSettings._envLayer;
        int _playerLayerMask => 1 << _Player._masterSettings._playerLayer;
        int _bodyLayerMask => 1 << _Player._masterSettings._bodyLayer;
        int _ghostLayerMask => 1 << _Player._masterSettings._ghostLayer;

        //values
        float range => _Player._masterSettings._actRange;
        
        private void Awake()
        {
           _Player=GetComponent<PlayerMaster>();
        }


        public PlayerMaster[] GetPlayersInRange()
        {
            return GetCollidersOfType<PlayerMaster>(_playerLayerMask);
        }

        public PlayerMaster GetClosestPlayerInRange()
        {
           PlayerMaster[] players= GetCollidersOfType<PlayerMaster>(_playerLayerMask);
            KeyValuePair<PlayerMaster,float> nearestPlayer = new KeyValuePair<PlayerMaster, float>(null,range+1);
            foreach(PlayerMaster plr in players)
            {
                float distance = (_Player.gameObject.transform.position - plr.gameObject.transform.position).magnitude;
                if(distance<nearestPlayer.Value && plr._playerData._playerID != _Player._playerData._playerID && plr._playerData._role==PlayerRole.Crewmate)
                {
                    nearestPlayer = new KeyValuePair<PlayerMaster, float>(plr, distance);
                }
            }
            return nearestPlayer.Key;
        }


        public T[] GetCollidersOfType<T>(int layer=0)
        {
            Collider[] colls = Physics.OverlapSphere(_Player._playerMid.transform.position, range, layer);
            List<T> filtered=new List<T>();
            foreach(Collider col in colls)
            {
                if (col.gameObject.GetComponent<T>() != null)
                    filtered.Add(col.gameObject.GetComponent<T>());
            }
            return filtered.ToArray();
        }

        public void UpdatePlayerCollisionState()
        {
            switch (_Player._playerData._state)
            {
                case PlayerState.Alive:
                    SetLayerRecursively(_Player.gameObject,(int)Mathf.Log(_Player._masterSettings._playerLayer.value, 2));
                    break;
                case PlayerState.Dead:
                    SetLayerRecursively(_Player.gameObject, (int)Mathf.Log(_Player._masterSettings._ghostLayer.value, 2));
                    break;
                default:
                    break;
            }
        }

        public static void SetLayerRecursively(GameObject go, int layerNumber)
        {
            go.layer = layerNumber;
            foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
            {
                trans.gameObject.layer = layerNumber;
            }
        }
    }
}
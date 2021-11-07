using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
namespace FrostyScripts.PlayerSystem
{

    public class PlayerMeshHandler : NetworkBehaviour
    {
        private PlayerMaster _Player;

        [SerializeField]private List<SkinnedMeshRenderer> _PlayerMeshes;



        public void SetPlayerMaterial(Material mat)
        {
            foreach (var mesh in _PlayerMeshes)
            {
                mesh.materials[0] = mat;
            }
        }
    }
}
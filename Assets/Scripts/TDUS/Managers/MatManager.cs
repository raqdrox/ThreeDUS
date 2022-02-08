using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using UnityEngine;
using Mirror;
namespace TDUS_Scripts.Data
{

    public class MatManager : NetworkBehaviour
    {
        
        [SerializeField]private PlayerMaterials matConfig;

        public static MatManager instance;

        private void Awake()
        {
            instance = this;
        }
        [Server]
        public Material GetMatFromPCol(PColor col)
        {
            return matConfig.matMaps.Find(item => item.color == col).mat;
        }
    }
}
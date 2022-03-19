using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using UnityEngine;
using Mirror;
namespace TDUS_Scripts_OLD.Data
{
    public enum PColor
    {
        RED,
        GREEN,
        BLUE
    }

    [Serializable]
    public class MatMap
    {
        public PColor color;
        public Material mat;
    }


    [CreateAssetMenu(menuName = "ThreeDUSData/PlayerMaterials")]
    public class PlayerMaterials : ScriptableObject //attach to playermanager
    {
        public List<MatMap> matMaps;

    }

   
}
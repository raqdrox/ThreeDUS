using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

namespace TDUS_Scripts.Data
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
        public List<MatMap> matmaps;

    }
}
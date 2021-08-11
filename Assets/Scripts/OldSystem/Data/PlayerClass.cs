using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    public int ID;
    public Color PlayerColor;
    public bool HasControl=false;
    public bool IsAlive = true;
    public bool IsImposter = false;
    public static PlayerClass localPlayer;
    public GameObject AlivePlayer, GhostPlayer, DeadPlayer;

    private void Start()
    {
        if(HasControl)
        {
            localPlayer = this;
        }
    }

    public void SetCol(Color col)
    {
        PlayerColor = col;
        SkinnedMeshRenderer PlayerMat = GetComponentInChildren<SkinnedMeshRenderer>();
        Material[] mats = PlayerMat.materials;
        mats[0].color=col;
        PlayerMat.materials = mats;
    }

    public Vector3 GetPlayerCoords()
    {
        Vector3 position;
        if (IsAlive)
        {
            position = AlivePlayer.transform.position;
        }
        else
        {
            position = GhostPlayer.transform.position;
        }
        return position;
    }
}

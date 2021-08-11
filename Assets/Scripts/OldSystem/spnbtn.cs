using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spnbtn : MonoBehaviour
{
    public int id=0;
    public int ColID = 0;
    public PlayerSpawner spn;

    public void SetcolID(int cid)
    {
        ColID = cid;
    }


    public void btn_Spawn(bool isPlayer)
    {
        spn.Spawn(isPlayer, ColID);
    }

    public void btn_despawn()
    {
        spn.DeSpawn();
    }

}

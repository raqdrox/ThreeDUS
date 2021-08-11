using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBodyData : MonoBehaviour
{
    public int PlayerID;
    public Color BodyColor;
    public bool VisState=true;
    public GameObject BodyObj;


    public void SetInvisible()
    {
        VisState = false;
        BodyObj.SetActive(false);
    }

    public Vector3 GetBodyCoords()
    {
        return BodyObj.transform.position;
    }

    public void SetBodyCoords(Vector3 pos)
    {
        BodyObj.transform.position=pos;
    }

    public void SetColor(Color col)
    {
        BodyColor = col;
        MeshRenderer PlayerMat=BodyObj.GetComponent<MeshRenderer>();
        Material[] mats = PlayerMat.materials;
        mats[0].color= col;
        mats[1].color = col;
        PlayerMat.materials = mats;
    }
}

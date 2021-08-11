using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Color[] cols;
    public int idRange = 6;
    public GameObject PlayerObj;
    public Transform SpawnZoneObj;
    private Transform[] SpawnZone;
    public List<int> SpawnedIDS;
    private void Awake()
    {
        SpawnZone = SpawnZoneObj.GetComponentsInChildren<Transform>();
    }
    public GameObject Spawn(bool IsPlayer,int ColorID)
    {
        int GenID = GeneratePlayerID();
        GameObject SpawnedPlayer = Instantiate(PlayerObj, SpawnChooser(), Quaternion.identity);
        SpawnedPlayer.GetComponent<PlayerClass>().ID=GenID;
        SpawnedPlayer.GetComponent<PlayerClass>().SetCol(cols[ColorID]);
        SpawnedPlayer.gameObject.tag = "Player";
        if(IsPlayer)
        {
            SpawnedPlayer.GetComponent<PlayerClass>().HasControl=true;
        }
        SpawnedIDS.Add(GenID);
        return SpawnedPlayer;
    }

  /*  public void DeSpawn(int id)
    {
        if(SpawnedIDS.Contains<int>(id))
        {
            var objects = GameObject.FindGameObjectsWithTag("Player");
            foreach (var obj in objects)
            {
                if(obj.GetComponent<PlayerClass>().ID==id)
                {
                    Destroy(obj);
                    SpawnedIDS.Remove(id);
                }

            }
        }
    }*/

    public void DeSpawn()
    {

        var objects = GameObject.FindGameObjectsWithTag("Player");
        foreach (var obj in objects)
        {
            Destroy(obj.transform.parent.gameObject);
            
        }
        SpawnedIDS.Clear();
    }

    private int GeneratePlayerID()
    {
        int id;
        int i=0;
        do
        {
            id = Random.Range(0, idRange);
            i++;
        } while (SpawnedIDS.Contains<int>(id)&&i<10);
        return id;
    }

    private Vector3 SpawnChooser()
    {

        return SpawnZone[Random.Range(0, SpawnZone.Length)].position;
    }
}

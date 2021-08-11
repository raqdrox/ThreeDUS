using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TaskSpawner : MonoBehaviour
{
    public GameObject TaskObj;
    public Transform SpawnZoneObj;
    private Transform[] SpawnZone;

    public void Awake()
    {
        SpawnZone = SpawnZoneObj.GetComponentsInChildren<Transform>();
    }

    public void Start()
    {
        for(int i = 0 ; i < SpawnZone.Length ; i++)
        {
            Spawn(i);
        }
    }
    public GameObject Spawn(int i)
    {

        GameObject SpawnedPlayer = Instantiate(TaskObj, SpawnZone[i].position, Quaternion.identity);
        SpawnedPlayer.tag ="Tasks";
        return SpawnedPlayer;
    }


    public void DeSpawn()
    {

        var objects = GameObject.FindGameObjectsWithTag("Tasks");
        foreach (var obj in objects)
        {
            Destroy(obj);
            
        }
        
    }


    private Vector3 SpawnChooser()
    {

        return SpawnZone[Random.Range(0, SpawnZone.Length)].position;
    }
}

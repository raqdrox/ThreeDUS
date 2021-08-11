using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Meeting : MonoBehaviour
{
    private GameObject Player; 
    private GameObject[] NPC;
    public GameObject SpawnZoneObj; 
    public Transform[] SpawnZone;
    private List<int> UsedSpawnIndexes;
    private void Awake()
    {
        UsedSpawnIndexes = new List<int>();
        SpawnZoneObj = GameObject.FindWithTag("PlayerSpawns");
        SpawnZone = SpawnZoneObj.GetComponentsInChildren<Transform>();

        Player = GameObject.FindWithTag("Player");

        NPC = GameObject.FindGameObjectsWithTag("NPC");
 
    }

    private void Start()
    {
        foreach(GameObject obj in NPC)
        {
            Debug.Log(obj);
            obj.GetComponentInChildren<NPCMovementScript>().SetPosition(SpawnZone[GetSpawnId()]);
        }
        Player.GetComponentInChildren<PlayerMovementScript>().SetPosition(SpawnZone[GetSpawnId()]);
        Debug.Log(Player.GetComponentInChildren<PlayerMovementScript>());

        Debug.Log("Meeting Ended");
        Destroy(transform.parent.gameObject);
    }

    int GetSpawnId()
    {
        int pos_id;
        do
        {
            pos_id = Random.Range(1, SpawnZone.Length);
        } while (UsedSpawnIndexes.Contains<int>(pos_id));
        UsedSpawnIndexes.Add(pos_id);
        return pos_id;
    }
}

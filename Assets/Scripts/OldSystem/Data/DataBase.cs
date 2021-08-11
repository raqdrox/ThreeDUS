using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase
{
    private int PlayerCount;
    private Dictionary<int,PlayerData> Players;
    private Dictionary<int,PlayerModeData> ModeData;

    public DataBase()
    {
        Players = new Dictionary<int, PlayerData>();
        ModeData = new Dictionary<int, PlayerModeData>();
        PlayerCount = 0;
    }

    public void AddPlayer(int add_id,int add_cid,GameObject add_obj)
    {
        Players.Add(add_id,new PlayerData(add_cid, add_obj));
        PlayerCount++;
    }


    public void SetupGameMode(Dictionary<int,string> recieved_data)
    {
        foreach(KeyValuePair<int,string> data in recieved_data)     //create entry for each playerID
        {
            char[] decodedData = data.Value.ToCharArray();          //decode data string to get variable values

            if(decodedData[0]=='1')                                 // 1 = imposter , 0 = crewmate
                ModeData.Add(data.Key, new PlayerModeData(true));   //create imposter
            else
                ModeData.Add(data.Key, new PlayerModeData(false));  //create imposter

            PlayerModeData modeObj = ModeData[data.Key];
            for (int i = 1 ; i < decodedData.Length ; i++ )         //Assign TaskIDs to PlayerID
            {
                modeObj.TaskAdder(decodedData[i]);                  
            }

        }
    }
}

public struct PlayerData
{
    public int PlayerColorID;    //ColorId Ranges from 0 - N-1 (where N = Number Of Colours)
    public GameObject PlayerObj; //Reference to Player Gameobject

    public PlayerData(int p_cid,GameObject p_obj)
    {
        PlayerColorID = p_cid;
        PlayerObj = p_obj; 
    }
}

public struct PlayerModeData
{
    public bool isImposter;                         //Types  false(Default) = Crewmate , true = Imposter 
    public bool isAlive;                         //States 0 = Dead/Ejected , 1(Default) = Alive  
    public Dictionary<int,bool> Tasks;      //Assigned Task ID List To PlayerID


    public PlayerModeData(bool isimp)
    {
        isImposter = isimp;
        isAlive = true;
        Tasks=new Dictionary<int, bool>();
    }

    public void TaskAdder(int t_id)
    {
        Tasks.Add(t_id,true);
    }
}
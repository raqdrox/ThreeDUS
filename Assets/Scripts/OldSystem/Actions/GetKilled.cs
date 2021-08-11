using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKilled : MonoBehaviour
{
    private PlayerClass Player;
    public Transform morgue;
    public ParticleSystem BloodParticles;

    private void Awake()
    {
        BloodParticles = GetComponentInChildren<ParticleSystem>();
        Player = GetComponent<PlayerClass>();
    }
    private void SwitchPlayerModels()
    {
        Player.AlivePlayer.SetActive(false);
        Player.GhostPlayer.SetActive(true);
    }

    private void PlaceDeadModel()
    {
        BloodParticles.Play();
        GameObject deadbody=Instantiate(Player.DeadPlayer, Player.GetPlayerCoords(), Quaternion.identity,morgue);
        deadbody.GetComponent<DeadBodyData>().SetColor(Player.PlayerColor);
    }

    public void Killed()
    {
        if (Player.IsAlive)
        {
            Debug.Log("Killed");
            Player.IsAlive = false;
            PlaceDeadModel();
            SwitchPlayerModels();
        }
    }

}

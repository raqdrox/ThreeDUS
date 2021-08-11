using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTask : MonoBehaviour
{

    public bool isActive = true;
    private bool inTrigger;
    private InputMaster inputs;
    private PlayerClass PlayerObj;


    private void Awake()
    {
        inputs = new InputMaster();
    }
    void OnTriggerEnter(Collider coll)
    {

        inTrigger = true;
        PlayerObj = coll.GetComponentInParent<PlayerClass>();

    }

    void OnTriggerExit(Collider coll)
    {
        inTrigger = false;
        PlayerObj = null;
    }

    private void OnEnable()
    {
        inputs.Player.Enable();
    }

    private void OnDisable()
    {
        inputs.Player.Disable();
    }
    private void FixedUpdate()
    {
        if(inputs.Player.Kill.ReadValue<float>()==1f && inTrigger &&isActive)
        {
            if (PlayerObj.IsImposter)
            { 
                this.gameObject.GetComponentInParent<GetKilled>().Killed();
                isActive = false;
            }
        }
    }
}

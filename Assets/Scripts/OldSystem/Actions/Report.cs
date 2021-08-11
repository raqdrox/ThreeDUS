using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Report : MonoBehaviour
{
    public bool isActive = true;
    private bool inTrigger;
    private InputMaster inputs;
    private PlayerClass PlayerObj;
    public GameObject meeting;

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
        if (inputs.Player.Report.ReadValue<float>() == 1f && inTrigger && isActive)
        {
            DeadBodyData[] bodies=GameObject.FindObjectsOfType<DeadBodyData>();
            foreach(DeadBodyData obj in bodies)
            {
                Destroy(obj);
            }
            Instantiate(meeting);
            Debug.Log("meeting");
            isActive = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Task1 : MonoBehaviour, ITrigger 
{
    
    public bool isActive = true;
    public bool isCompleted = false;
    public GameObject TaskUI;
    private PlayerMovementScript PlayerObj;
    private bool inTrigger = false;
    private bool isPlaying = false;
    private InputMaster inputs;
    private Toggle[] ButtonArray;

    private void Awake()
    {
        this.inputs = new InputMaster();
        this.ButtonArray= TaskUI.GetComponentsInChildren<Toggle>();
        
    }
    
    private void OnEnable()
    {
        this.inputs.Player.Enable();
        this.inputs.TaskUI.Enable();
    }

    private void OnDisable()
    {
        this.inputs.Player.Disable();
        this.inputs.TaskUI.Disable();
    }

    public void EndTask()
    {
        PlayerObj.HasControl = true;
        this.TaskUI.SetActive(false);
        this.isActive = false;
        this.isPlaying = false;
        this.isCompleted = true;
        Debug.Log("Task Ended");

    }

    public void StartTask()
    {
        PlayerObj.HasControl = false;
        this.isPlaying = true;
        Debug.Log("Task Started");
        this.TaskSetup();
    }

    public void CancelTask()
    {
        PlayerObj.HasControl = true;
        this.TaskUI.SetActive(false);
        this.isPlaying = false;
        Debug.Log("Task Cancelled");
    }


    public void FixedUpdate()
    {

        if (this.isActive && !this.isPlaying && this.inTrigger)
        {
            if (this.inputs.Player.Use.ReadValue<float>() == 1f)
            {
                this.StartTask();
            }
            
        }

        //Task
        if (this.isPlaying && this.inTrigger)
        {
            if (this.inputs.TaskUI.Cancel.ReadValue<float>() == 1f)
            {
                this.CancelTask();
            }

            this.CheckStatus();
        }

    }

    void OnTriggerEnter(Collider Player)
    {
        if(Player.gameObject.tag!="Player")
        {
            Physics.IgnoreCollision(Player, GetComponent<Collider>());
        }
        this.inTrigger = true;
        PlayerObj = Player.gameObject.GetComponent<PlayerMovementScript>();
    }

    void OnTriggerExit(Collider Player)
    {
        this.inTrigger = false;
        PlayerObj = null;
    }

    private void CheckStatus()
    {
        foreach(Toggle obj in ButtonArray)
        {
            if(obj.isOn==false)
            {
                return;
            }
        }
        this.EndTask();
    }


    public void TaskSetup()
    {
        Debug.Log("setting up");
        //Initialize Task
        int i = 3;
        foreach(Toggle obj in ButtonArray)
        {
            obj.isOn = false;
        }
        while(i>0)
        {
            Toggle obj=ButtonArray[Random.Range(0, ButtonArray.Length)];
            if(!obj.isOn)
            {
                obj.isOn = true;
                i--;
            }
        }
        this.TaskUI.SetActive(true);

        
    }

}

using UnityEngine;
public class NPCMovementScript : MonoBehaviour
{
    [Header("Movement Values")]
    [Range(0f,20f)]
    public float speed = 6f;
    [Range(0f, 10f)]
    public float Mousespeed = 4f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    public bool UseGravity = true;

    [Header("Animators")]
    public Animator PlayerAnim;

    private Vector3 moveVector;
    private CharacterController controller;
    public bool HasControl;
    

    private void Awake()
    {
        HasControl = true;
        controller = GetComponent<CharacterController>();
        PlayerAnim.SetBool("IsWalking", true);
    }

    void FixedUpdate()
    {
        if (UseGravity)
        { Gravity(); }
        //if (HasControl)
        //{ 
        //MovePlayer();
        //}

    }

    void Gravity() //Apply Gravity to PlayerModel
    {
        this.moveVector = Vector3.zero;

        if (controller.isGrounded == false)
        {
            this.moveVector += Physics.gravity;
        }

        controller.Move(this.moveVector * Time.deltaTime);
    }

    void TurnPlayer()
    {

        transform.rotation = Quaternion.Euler(0, 0, 0);
    }


    public void SetPosition(Transform pos)
    {
        transform.position = pos.position;
        transform.rotation = pos.rotation;
    }

    void MovePlayer() //Check for inputs and move to corresponding direction
    {

        //Vector2 movement = inputs.Player.Move.ReadValue<Vector2>();
        float horizontal = 0f;//movement.x;
        float vertical = 0f;//movement.y;
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.2f)
        {
            PlayerAnim.SetBool("IsWalking", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref this.turnSmoothVelocity, this.turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            //TurnPlayer();
            //PlayerAnim.SetBool("IsWalking", false);
        }
    }
}


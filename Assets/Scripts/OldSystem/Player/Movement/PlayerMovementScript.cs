using UnityEngine;
public class PlayerMovementScript : MonoBehaviour
{
    [Header("Movement Values")]
    [Range(0f,20f)]
    public float speed = 6f;
    [Range(0f, 10f)]
    public float Mousespeed = 4f;
    public float turnSmoothTime = 0.1f;
    public bool UseGravity=true;
    private float turnSmoothVelocity;
    

    [Header("Animators")]
    public Animator PlayerAnim;
    public PlayerCamSwitcher CamAnim;


    private InputMaster inputs;
    private Vector3 moveVector;
    private CharacterController controller;
    private Transform cam;
    public bool HasControl;

    private void Awake()
    {
        HasControl = true;
        inputs = new InputMaster();
        this.cam = Camera.main.transform;
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        Gravity();
        if (HasControl)
        { 
        MovePlayer();
        }

    }

    public void ToggleCursor()
    {
        if (Cursor.visible == true)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnEnable()
    {
        inputs.Player.Enable();
    }

    private void OnDisable()
    {
        inputs.Player.Disable();
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

        transform.rotation = Quaternion.Euler(0, cam.eulerAngles.y, 0);
    }

    public void SetPosition(Transform pos)
    {
        transform.position = pos.position;
        transform.rotation = pos.rotation;
    }


    void MovePlayer() //Check for inputs and move to corresponding direction
    {

        Vector2 movement = inputs.Player.Move.ReadValue<Vector2>();
        float horizontal = movement.x;
        float vertical = movement.y;
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.2f)
        {
            if (CamAnim.CamMode != 0)
            { PlayerAnim.SetBool("IsWalking", true); }
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref this.turnSmoothVelocity, this.turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            if (CamAnim.CamMode == 0)
            { TurnPlayer(); }
            else
            { PlayerAnim.SetBool("IsWalking", false); }
        }
    }
}


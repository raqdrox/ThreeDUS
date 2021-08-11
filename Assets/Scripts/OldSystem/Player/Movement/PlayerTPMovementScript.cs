using UnityEngine;
namespace Player
{
    public class PlayerTPMovementScript : PlayerClass
    {
        public CharacterController controller;
        public Transform cam;
        public float speed = 6f;
        public float Mousespeed = 4f;
        public float turnSmoothTime = 0.1f;
        float turnSmoothVelocity;
        public Animator PlayerAnim;
        private InputMaster inputs= null;
        private Vector3 moveVector;
        private void Awake()
        {
            inputs = new InputMaster();
            var objects = GameObject.FindGameObjectsWithTag("MainCamera");
            foreach (var obj in objects)
            {
                this.cam = obj.GetComponent<Transform>();
            }
        }
        void Update()
        {
            Gravity();
            MovePlayer();
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
            this.inputs.Player.Enable();
        }

        private void OnDisable()
        {
            this.inputs.Player.Disable();
        }

        void Gravity()
        {
            this.moveVector = Vector3.zero;

            if (this.controller.isGrounded == false)
            {
                this.moveVector += Physics.gravity;
            }

            this.controller.Move(this.moveVector * Time.deltaTime);
        }

        void TurnPlayer()
        {

            transform.rotation = Quaternion.Euler(0, cam.eulerAngles.y, 0);
        }

        void MovePlayer()
        {

            Vector2 movement = this.inputs.Player.Move.ReadValue<Vector2>();
            float horizontal = movement.x;
            float vertical = movement.y;
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            if (direction.magnitude >= 0.2f)
            {
                this.PlayerAnim.SetBool("IsWalking", true);
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref this.turnSmoothVelocity, this.turnSmoothTime);
                this.transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                this.controller.Move(moveDir.normalized * speed * Time.deltaTime);

            }
            else
            {
                TurnPlayer();
                this.PlayerAnim.SetBool("IsWalking", false);
            }
        }
    }
}


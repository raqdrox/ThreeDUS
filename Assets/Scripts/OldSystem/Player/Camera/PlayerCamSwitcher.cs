using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamSwitcher : MonoBehaviour
{
    [SerializeField]
    private InputMaster input;
    private Animator CamAnim;
    public int CamMode;
    public GameObject PlayerModel;

    private void Awake()
    {
        CamAnim = GetComponent<Animator>();
        input = new InputMaster();
        PlayerModel.SetActive(false);
        CamAnim.Play("FPSCam");
        CamMode = 0;
    }

    void Start()
    {
        input.Player.CameraSwitch.performed += _ => SwitchState();

    }

    void SwitchState()
    {
        switch(CamMode)
        {
            case 0: CamAnim.Play("TopCam"); CamMode = 1;
                PlayerModel.SetActive(true);
                break;
            case 1: CamAnim.Play("BackCam"); CamMode = 2;
                PlayerModel.SetActive(true);
                break;
            case 2: CamAnim.Play("FPSCam"); CamMode = 0;
                PlayerModel.SetActive(false);
                break;

        }
    }


    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
}

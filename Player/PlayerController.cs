using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [Tooltip("If The Character Currently Has Movement")]
    public bool hasControl;
    [Tooltip("The Current Control Type, 0 is KeyBoard, 1 is Controller")]
    public int ControlType;
    //The speed At Which The Player Moves
    [Header("Movement")]
    PlayerControls controls;
    [SerializeField] [Tooltip("The Speed At Which The Player Moves")]
    private float speed = 1f;
    [Tooltip("The Current Speed Multiplier")]
    public float speedMultiplier = 1f;
    [SerializeField] [Tooltip("The CharacterController Component Attached To The Player")]
    private CharacterController controller;
    [SerializeField] [Tooltip("The Speed At Which The Player Rotates")]
    private float cameraRotateSpeed = 10f;
    [SerializeField] [Tooltip("THe Animator Component On Character")]
    private Animator anim;

    public Vector3 velocity;

    [Header("Gravity Control")]
    public Vector3 gravityVector = new Vector3(0, 0f, 0f);
    bool isGrounded = false;
    [SerializeField] [Tooltip("Gravity")]
    private float gravityScale = 9.81f;
    [SerializeField] [Tooltip("The Position The Player Checks How Far The Ground Is Away")]
    private Transform groundCheck;
    [SerializeField] [Tooltip("The Distance Ground Is Checked For")]
    private float groundCheckDistance = 0.2f;
    [SerializeField] [Tooltip("Layers Which Contain The Ground")]
    private LayerMask groundCheckLayers;

    private void Awake() {
        controls = new PlayerControls();

        controls.Gameplay.MoveKeyBoard.ReadValue<Vector2>();
    }

    //Update Contains All The Essential Code For It To Move
    private void Update() {
        //Player Movement & Rotation
        if(hasControl == true) {
            switch (ControlType) {
                case 0:
                    velocity = new Vector3(controls.Gameplay.MoveKeyBoard.ReadValue<Vector2>().x, 0f, controls.Gameplay.MoveKeyBoard.ReadValue<Vector2>().y);
                    break;
                case 1:
                    velocity = new Vector3(controls.Gameplay.MoveController.ReadValue<Vector2>().x, 0f, controls.Gameplay.MoveController.ReadValue<Vector2>().y);
                    break;
                default:
                    Debug.LogError("Controller Type Does Not Exist");
                    break;
            }
            anim.SetFloat("Move", velocity.magnitude);

            if(velocity.magnitude > 0) {
                transform.forward = Vector3.Lerp(transform.forward, Vector3.Normalize(velocity), Time.deltaTime * cameraRotateSpeed); 
            }

            controller.Move(velocity * speed * Time.deltaTime); 
        }

        //Applying Gravity
        if(isGrounded == false) {
            gravityVector -= Vector3.up * Time.deltaTime * gravityScale;  
        }else {
            gravityVector = new Vector3(0f, 0f, 0f);
        }

        controller.Move(gravityVector * Time.deltaTime);  

        //Ground Checks
        isGrounded = Physics.Raycast(groundCheck.position, groundCheck.TransformDirection(Vector3.down), groundCheckDistance, groundCheckLayers);
    }

    private void OnEnable() {
        controls.Enable();
    }

    private void OnDisable() {
        controls.Disable();
    }
}

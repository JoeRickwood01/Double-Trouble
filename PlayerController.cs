using UnityEngine;

public class PlayerController : MonoBehaviour {
    //The speed At Which The Player Moves
    [Header("Movement")]
    [SerializeField] [Tooltip("The Speed At Which The Player Moves")]
    private float speed = 1f;
    [Tooltip("The Current Speed Multiplier")]
    public float speedMultiplier = 1f;
    [SerializeField] [Tooltip("The CharacterController Component Attached To The Player")]
    private CharacterController controller;
    [SerializeField] [Tooltip("The Speed At Which The Player Rotates")]
    private float cameraRotateSpeed = 10f;

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

    //Update Contains All The Essential Code For It To Move
    private void Update() {
        //Player Movement & Rotation
        float x = Input.GetAxis("Horizontal") * speed * speedMultiplier;
        float y = Input.GetAxis("Vertical") * speed * speedMultiplier;

        Vector3 velocity = new Vector3(x, 0f, y);

        if(velocity.magnitude > 0) {
            transform.forward = Vector3.Lerp(transform.forward, Vector3.Normalize(velocity), Time.deltaTime * cameraRotateSpeed); 
        }

        controller.Move(velocity * Time.deltaTime); 

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
}

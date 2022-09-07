using UnityEngine;

public class FPSController : MonoBehaviour {
    public CharacterController controller;
    public Transform playerCam, playerRoot;
    public float speed, lookSensitivity;
    float rotX, rotY;

    void Start() { Cursor.lockState = CursorLockMode.Locked; }

    void Update() {
        rotX -= Input.GetAxis("Mouse Y");
        rotY += Input.GetAxis("Mouse X");
        rotX = Mathf.Clamp(rotX, -90f, 90f);
        playerCam.rotation = Quaternion.Euler(rotX, rotY, 0f);
        playerRoot.rotation = Quaternion.Euler(0f, rotY, 0f);
        Vector2 movementVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        controller.Move((((playerRoot.forward * movementVector.y + playerRoot.right * movementVector.x) * speed) + new Vector3(0f, -9.81f, 0f)) * Time.deltaTime);
    }
}

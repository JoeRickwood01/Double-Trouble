using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour { //Very Basic Simple Top Down Player Controller, Very Compact But Still Readable
    public CharacterController controller; [SerializeField] private float speed; public bool active; public bool usesController; public Transform camRig; //Place Camera Under The Camera Rig, Then Offset The Camera To Look At The Camera Rig, Character Controller Is Regular Character Controller Setup
    public InputAction playerMoveKeyBoard;
    public InputAction playerMoveController;

    private void OnEnable() {
        playerMoveKeyBoard.Enable();
        playerMoveController.Enable();
    }

    private void OnDisable() {
        playerMoveKeyBoard.Enable();
        playerMoveController.Enable();
    }

    void Update() { //Gathers Input From User, Moves Camera Rig, Moves Player Based On Input From User || USES OLD INPUT SYSTEM FOR SIMPLICITY ||
        if(active == true) {
            switch (usesController) {
                case true:
                    Vector2 movementController = playerMoveController.ReadValue<Vector2>();
                    movementController = movementController * speed;
                    controller.Move((camRig.forward * movementController.y + camRig.right * movementController.x) * Time.deltaTime);
                    break;
                case false:
                    Vector2 movementKeyBoard = playerMoveKeyBoard.ReadValue<Vector2>();
                    movementKeyBoard = movementKeyBoard * speed;
                    controller.Move((camRig.forward * movementKeyBoard.y + camRig.right * movementKeyBoard.x) * Time.deltaTime);
                    break;  
            }
        }

        controller.Move(new Vector3(0f, -9.81f, 0f) * Time.deltaTime);
    }
}

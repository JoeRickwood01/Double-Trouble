using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerControllerTest : MonoBehaviour {
    public float moveX = 0;
    public float moveY = 0;

    public float mouseY = 0f;
    public float mouseX = 0f;

    public float playerSpeed;
    public float playerRotation;

    public float gravity;

    public CharacterController controller;

    void Update() {
        if(Input.GetKey(KeyCode.A)) {
            moveX = -1f;
        }
        if(Input.GetKey(KeyCode.D)) {
            moveX = 1f;
        }
        if(Input.GetKey(KeyCode.S)) {
            moveY = -1f;
        }
        if(Input.GetKey(KeyCode.W)) {
            moveY = 1f;
        }

        controller.Move(new Vector3(moveX, gravity, moveY));
    }
}

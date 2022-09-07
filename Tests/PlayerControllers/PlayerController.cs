using UnityEngine;

public class PlayerController : MonoBehaviour { //Very Basic Simple Top Down Player Controller, Very Compact But Still Readable
    public CharacterController controller; public Transform camRig; [SerializeField] private float speed; //Place Camera Under The Camera Rig, Then Offset The Camera To Look At The Camera Rig, Character Controller Is Regular Character Controller Setup

    void Update() { //Gathers Input From User, Moves Camera Rig, Moves Player Based On Input From User || USES OLD INPUT SYSTEM FOR SIMPLICITY ||
        camRig.position = Vector3.Lerp(camRig.position, transform.position, Time.deltaTime * 3f);
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * speed, 0f, Input.GetAxis("Vertical") * speed); // Gather Input Vector We Can Ignore Y Axis So We Set It To 0f
        controller.Move((movement + new Vector3(0f, -9.81f, 0f)) * Time.deltaTime);
    }
}

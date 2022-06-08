using UnityEngine;

public class CameraController : MonoBehaviour {   
    [Tooltip("The Targeted Player")]
    public Transform player;
    Vector3 pos;
    [SerializeField] [Tooltip("The Speed At Which The Camera Interpolates To The Players Position")]
    private float cameraSmoothSpeed = 2f;
    [SerializeField] [Tooltip("The World Space Offset Of The Camera")]
    private Vector3 offset = new Vector3(0f, 0f, 0f);
    [Tooltip("The Distance The Camera Follows At With Its Direction Into Account")]
    public float followDistance = 10f;
    [SerializeField] [Tooltip("The Rotation Of The Camera")]
    private Quaternion cameraRotation = Quaternion.Euler(0f, 0f, 0f);
    [SerializeField] [Tooltip("The Speed At Which The Camera Rotates")]
    private float cameraRotateSpeed = 4f;

    //Update Calls Every Frame
    private void Update() {
        pos = player.position - (transform.forward * followDistance) + offset;
        //Lerp is short for interpolate which means it slowly changing the value over time
        transform.rotation = Quaternion.Lerp(transform.rotation, cameraRotation, Time.deltaTime * cameraRotateSpeed);
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * cameraSmoothSpeed);
    }
}

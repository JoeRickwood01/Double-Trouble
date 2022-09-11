using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform target;
    public float targetAngle;

    void Update() {
        if(Vector3.Distance(transform.position, target.position) >= 0.1f) {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 3f);
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, targetAngle, 0f), Time.deltaTime * 3f);
    }
}

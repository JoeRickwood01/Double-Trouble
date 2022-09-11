using UnityEngine;

//Contains Code To Detect Enters A Button
public class VolumeTrigger : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if(other.transform.GetComponent<PressureButton>()) {
            other.transform.GetComponent<PressureButton>().Activate();
        }
        if(GetComponent<PlayerController>() && other.transform.GetComponent<CameraTrigger>()) {
            GetComponent<PlayerController>().camRig.GetComponent<CameraController>().targetAngle = other.transform.GetComponent<CameraTrigger>().targetAngle;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.transform.GetComponent<PressureButton>()) {
            other.transform.GetComponent<PressureButton>().Deactivate();
        } 
    }
}

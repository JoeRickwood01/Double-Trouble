using UnityEngine;

public class LookAt : MonoBehaviour {
    public Transform cam;
    
    private void Update() {
        transform.LookAt(cam);
    }
}

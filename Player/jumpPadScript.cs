using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPadScript : MonoBehaviour {
    public Vector3 modifiedGravityVector;
    public LayerMask jumpPad;
    [SerializeField] [Tooltip("The Position Of The Players Feet")]
    private Transform feet;
    [SerializeField] [Tooltip("The Distance Which The Player Checks For Ground & Things")]
    private float groundCheckDistance;
    // Start is called before the first frame update
    void Start() {
        modifiedGravityVector = GetComponent<PlayerController>().gravityVector;
       
    }

    void FixedUpdate() {

        if(Physics.Raycast(feet.position, feet.TransformDirection(Vector3.down), groundCheckDistance, jumpPad))
        {
            Debug.Log("ITS WORKING");
        }
    }
}

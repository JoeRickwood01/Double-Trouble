using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minecart : MonoBehaviour {
    [SerializeField]
    private Transform railCheck;
    [SerializeField]
    private float railCheckDistance;
    [SerializeField]
    private LayerMask railLayers;
    public bool foundRail;

    public Vector3 velocity;
    public Rigidbody rb;
    public float minecartSpeed;


    private void Update() {
        RaycastHit railHit;
        foundRail = Physics.Raycast(railCheck.position, railCheck.TransformDirection(Vector3.down), out railHit, railCheckDistance, railLayers);

        rb.velocity = velocity;
    } 
}

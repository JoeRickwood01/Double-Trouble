using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour {
    [Header("General")]
    [SerializeField]
    private Animator playerAnim;
    PlayerControls controls;
    
    [Header("Raycasts")]
    [SerializeField]
    private Transform interactionCheck;
    [SerializeField]
    private float interactionCheckDistance;
    [SerializeField]
    private LayerMask interactionLayers;
    [SerializeField]
    private GameObject interactionIndicator;
    [SerializeField]
    private LayerMask minecartLayers;
    bool foundInteraction = false;
    bool foundMinecart;

    RaycastHit minecartHit;
    RaycastHit interactionHit;

    [Header("Interact")]
    [SerializeField]
    private Transform hands;
    [SerializeField]
    private float throwVelocity;

    private void Awake() {
        controls = new PlayerControls();
    }

    private void Update() {
        if(hands.childCount > 0) {
            foundInteraction = Physics.Raycast(hands.position, interactionCheck.TransformDirection(Vector3.forward), out interactionHit, interactionCheckDistance, interactionLayers);
        }else {
            foundInteraction = Physics.Raycast(interactionCheck.position, interactionCheck.TransformDirection(Vector3.forward), out interactionHit, interactionCheckDistance, interactionLayers);
        }

        if(hands.childCount < 1) {
            foundMinecart = Physics.Raycast(interactionCheck.position, interactionCheck.TransformDirection(Vector3.forward), out minecartHit, interactionCheckDistance, minecartLayers);
        }

        if(foundInteraction == true) {
            interactionIndicator.SetActive(true);
        }else {
            interactionIndicator.SetActive(false);
        }

        switch (GetComponent<PlayerController>().ControlType) {
            case 0:
                controls.Gameplay.InteractKeyBoard.performed += ctx => PickupDrop();
                break;
            case 1:
                controls.Gameplay.InteractController.performed += ctx => PickupDrop();
                break;
            default:
                Debug.LogError("Control Type Does Not Exist");
                break;
        }

        if(foundMinecart == true) {
            if(minecartHit.transform.GetComponent<Minecart>().foundRail == true) {
                Vector2 vel = Vector2.zero;
            switch (GetComponent<PlayerController>().ControlType) {
                case 0:
                    vel = controls.Gameplay.MoveKeyBoard.ReadValue<Vector2>();
                    break;
                case 1:
                    vel = controls.Gameplay.MoveController.ReadValue<Vector2>();
                    break;
                default:
                    Debug.LogError("Control Type Does Not Exist");
                    break;
            }
                Vector3 move = new Vector3(vel.x * minecartHit.transform.GetComponent<Minecart>().minecartSpeed, 0f, vel.y * minecartHit.transform.GetComponent<Minecart>().minecartSpeed);
                minecartHit.transform.GetComponent<Minecart>().velocity = move;
            }
        }


        //Sets The Animation States
        if(hands.childCount > 0) {
            playerAnim.SetBool("HoldingObject", true);
        }else {
            playerAnim.SetBool("HoldingObject", false);
        }
    }

    void PickupDrop() {
        if(hands.childCount > 0) {
            foundInteraction = Physics.Raycast(hands.position, interactionCheck.TransformDirection(Vector3.forward), out interactionHit, interactionCheckDistance, interactionLayers);
        }else {
            foundInteraction = Physics.Raycast(interactionCheck.position, interactionCheck.TransformDirection(Vector3.forward), out interactionHit, interactionCheckDistance, interactionLayers);
        }

        if(hands.childCount > 0) {
            hands.GetChild(0).GetComponent<Rigidbody>().velocity += transform.forward * throwVelocity + GetComponent<PlayerController>().velocity; 
            if(hands.GetChild(0).transform.GetComponent<Rigidbody>() != null) {
                hands.GetChild(0).transform.GetComponent<Rigidbody>().isKinematic = false;
            }
            hands.GetChild(0).parent = null;
        }

        if(foundInteraction == true) {
            interactionHit.transform.parent = hands;
            interactionHit.transform.position = hands.position;
            interactionHit.transform.rotation = Quaternion.Euler(0f, transform.rotation.y, 0f);
            if(hands.GetChild(0).transform.GetComponent<Rigidbody>() != null) {
                hands.GetChild(0).transform.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    private void OnEnable() {
        controls.Enable();
    }

    private void OnDisable() {
        controls.Disable();
    }
}

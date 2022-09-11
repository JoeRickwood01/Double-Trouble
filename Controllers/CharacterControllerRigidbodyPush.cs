using UnityEngine;

//This Class Activates Functionality For Character Controllers To PushRigidbodies
public class CharacterControllerRigidbodyPush : MonoBehaviour {
    [SerializeField]
    private float pushForce; //The Force At Which The Character Controller Pushes The Rigidbody

    //OnControllerColliderHit Detect When The Character Controller On Object Collides With Object
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        Rigidbody rb = hit.collider.attachedRigidbody; //Creates A Temporary Rigidbody Variable Then Assigns It To The Collided Object

        if(rb != null) { //Checks If The Set Rigidbody != null Then Moves The Rigidbody If It Is Not
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0f;
            forceDirection.Normalize();

            rb.AddForceAtPosition(forceDirection * pushForce, transform.position, ForceMode.Impulse);
        }   
    }
}

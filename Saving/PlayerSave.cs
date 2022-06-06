using UnityEngine;

public class PlayerSave : MonoBehaviour {
    Transform savePoint;

    //OnTriggerEnter method is called when the player enters a collider Trigger
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("SavePoint")) {
            if(other.GetComponent<Animator>() == null || other.GetComponent<SavePoint>() == null) {
                //Throws Error To Help With Bug Testing
                Debug.LogError("Animator Or SavePoint Component Could Not Be Found On Current Save Point");
                return;
            }
            savePoint = SavePointManager.savePoints[other.GetComponent<SavePoint>().savePointID];
            if(other.GetComponent<SavePoint>().activated == false) {
                other.GetComponent<Animator>().SetTrigger("Activate");
                other.GetComponent<SavePoint>().activated = true;
            }
        }
    }
}

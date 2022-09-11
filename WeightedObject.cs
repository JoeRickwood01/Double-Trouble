using UnityEngine;

public class WeightedObject : MonoBehaviour {
    public float weight;


    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("WeightedButton")) {
            if(weight >= other.GetComponent<WeightedButton>().requiredWeight) { 
                other.GetComponent<WeightedButton>().Activate();
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("WeightedButton")) {
            if(weight >= other.GetComponent<WeightedButton>().requiredWeight) { 
                other.GetComponent<WeightedButton>().Deactivate();
            }
        }
    }
}

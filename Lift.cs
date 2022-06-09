using UnityEngine;

public class Lift : MonoBehaviour {
    [SerializeField] [Tooltip("The Lower Y Coordinate Of The Lift")]
    private float lowerLevel;
    [SerializeField] [Tooltip("The Upper Y Coordinate Of The Lift")]
    private float upperLevel;
    [SerializeField] [Tooltip("The Speed At Which The Lift Operates")]
    private float liftSpeed;

    float currentLevel;

    public void Activate() {
        SwapLevel();
    }

    private void Update() {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, currentLevel, transform.position.z), Time.deltaTime * liftSpeed);
    }

    float SwapLevel() {
        if(currentLevel >= upperLevel - 0.05f) {
            currentLevel = lowerLevel;
        }else if(currentLevel <= lowerLevel + 0.05f) {
            currentLevel = upperLevel;
        }
        return currentLevel;
    }
}

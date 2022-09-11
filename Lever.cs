using UnityEngine;

public class Lever : MonoBehaviour {
    bool Activated;
    [SerializeField] [Tooltip("Lift Which Is Activated")]
    private Lift lift;
    [SerializeField] [Tooltip("Animator Attached To Lever")]
    private Animator anim;

    public void Activate() {
        Activated = !Activated;
        anim.SetBool("Activated", Activated);
        lift.Activate(); 
    }
}

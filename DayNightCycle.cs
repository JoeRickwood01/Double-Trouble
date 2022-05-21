using UnityEngine;

//This Script Will Change The Environment To Reflect Different Day/Night Cycles
public class DayNightCycle : MonoBehaviour {
    [Tooltip("The Tint Of The Directional Light(Sun) Changes Based On Time Of Day")] [SerializeField]
    private Gradient sunTint;
    [Tooltip("The Current Time Of The In Game World")] [SerializeField]
    private float time;
    [Tooltip("The Total Length Of The Day")]
    public float dayLength;
    [Tooltip("The Directional Light Used In The Scene")] [SerializeField]
    private new Light light;

    /*Update Method Is Called Every Frame, In This Update Method, The Method Changes The Current time(variable) by Time.deltaTime which takes the 
    time since the last frame, this means we can get accurate time calculations so the day lengths will be the same every time */
    private void Update() {
        time += Time.deltaTime;
        if(time >= dayLength) {
            time = 0f;
        }
        ChangeComponents();
    }

    //Chnages Light Color And Rotation
    private void ChangeComponents() {
        light.transform.rotation = Quaternion.Euler((time / dayLength) * 360, 0f, 0f);
        light.color = sunTint.Evaluate(time / dayLength);
    }
}

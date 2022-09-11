using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    [SerializeField] private Transform[] StopPoints; //The Points Which The Platform Stops At
    [SerializeField] private float platformSpeed; //The Speed Aat Which The Platform Moves

    public bool isActive = false; //If The Platform Is Activate
    int currentPoint = 0; //The CurrentPoint Which The Platform Moves To, integers are easier to store than a transform

    void Update() {
        if(isActive == true) {
            transform.position = Vector3.MoveTowards(transform.position, StopPoints[currentPoint].position, Time.deltaTime * platformSpeed);
            if(Vector3.Distance(transform.position, StopPoints[currentPoint].position) < 0.05f) {
                currentPoint++;
                if(currentPoint > StopPoints.Length - 1) {
                    currentPoint = 0;
                }
            }
        }else {
            if(StopPoints[0] != null) {
                transform.position = Vector3.MoveTowards(transform.position, StopPoints[0].position, Time.deltaTime * platformSpeed);
            }
        }
    }
}

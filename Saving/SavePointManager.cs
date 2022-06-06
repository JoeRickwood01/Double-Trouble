using UnityEngine;

public class SavePointManager : MonoBehaviour {
    public Transform savePointParent;
    public static Transform[] savePoints;

    private void Start() {
        savePoints = FindSavePoints();
    }

    Transform[] FindSavePoints() {
        savePoints = new Transform[savePointParent.childCount];
        for (int i = 0; i < savePointParent.childCount; i++) {
            savePoints[i] = savePointParent.GetChild(i);
        }
        return savePoints;
    }
}

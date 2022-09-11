using UnityEngine;

public class WeightedButton : MonoBehaviour {
    public Type objectType;
    public float requiredWeight;

    public void Activate() {
        switch (objectType) {
            case Type.ObjectMove:
                break;
        }
    }

    public void Deactivate() {
        switch (objectType) {
            case Type.ObjectMove:
                break;
        }
    }
}

public enum Type {
    ObjectMove,
}

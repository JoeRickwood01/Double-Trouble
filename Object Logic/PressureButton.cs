using UnityEngine;

//Button Script Which Is The Activated Button Code
public class PressureButton : MonoBehaviour {
    public ButtonType buttonType;

    public GameObject affectedObject;

    GameObject explodeEffect;

    private void Start() {
        explodeEffect = Resources.Load<GameObject>("Explode");
    }

    //Button Activation Method
    public void Activate() {
        switch (buttonType) {
            case ButtonType.MoveObject:
                affectedObject.GetComponent<MovingPlatform>().isActive = true;
                break;
            case ButtonType.DestroyObject:
                if(affectedObject != null) {
                    Vector3 pos = affectedObject.transform.position;
                    Destroy(affectedObject);
                    Instantiate(explodeEffect, pos, Quaternion.identity);
                }
                break;
        }
    }

    public void Deactivate() {
        switch (buttonType) {
            case ButtonType.MoveObject:
                affectedObject.GetComponent<MovingPlatform>().isActive = false;
                break;
            case ButtonType.DestroyObject:
                if(affectedObject != null) {
                    Vector3 pos = affectedObject.transform.position;
                    Destroy(affectedObject);
                    Instantiate(explodeEffect, pos, Quaternion.identity);
                }
                break;
        }
    }
}

//Enum Contains Data Types, In This Case It Will Affect What The Button Activated Does
public enum ButtonType {
    MoveObject,
    DestroyObject
}
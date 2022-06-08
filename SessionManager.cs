using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Session Manager Sets Up Cameras And Such
public class SessionManager : MonoBehaviour {
    [Tooltip("0 is Local SinglePlayer, 1 is Local Multiplayer, 2 is Online Multiplayer")]
    public int sessionType;
    [SerializeField] [Tooltip("The Cameras For Each Player")]
    public Camera[] playerCam;
    [SerializeField] [Tooltip("The Player Controllers")]
    public Transform[] players;
    PlayerControls controls;

    public bool whichPlayer;

    private void Awake() {
        controls = new PlayerControls();

        controls.Gameplay.SwapCharacterKeyBoard.performed += ctx => SwapCharacter();
        controls.Gameplay.SwapCharacterController.performed += ctx => SwapCharacter();
    }

    private void Start() {
        switch (sessionType) {
            case 0:
                LocalSinglePlayerStart();
                break;
            case 1:
                LocalMultiPlayerStart();
                break;
            case 2:
                OnlineMultiPlayerStart();
                break;
            default:
                Debug.LogError("Incorrect Game Session Type");
                break;
        }
    }

    void SwapCharacter() {
        whichPlayer = !whichPlayer;
        if(whichPlayer == true) {
            playerCam[0].gameObject.GetComponent<CameraController>().player = players[0];
            players[0].GetComponent<PlayerController>().hasControl = true;
            players[1].GetComponent<PlayerController>().hasControl = false;
        }else {
            playerCam[0].gameObject.GetComponent<CameraController>().player = players[1];
            players[1].GetComponent<PlayerController>().hasControl = true;
            players[0].GetComponent<PlayerController>().hasControl = false;
        }
    }

    public void LocalSinglePlayerStart() {
        Debug.Log("Started Single Player Game");
        playerCam[0].gameObject.SetActive(true);
        playerCam[1].gameObject.SetActive(false);
        playerCam[0].rect = new Rect(0f, 0f, 1f, 1f);
        playerCam[1].rect = new Rect(0f, 0f, 1f, 1f);
        players[0].GetComponent<PlayerController>().hasControl = true;
    } 

    public void LocalMultiPlayerStart() {
        Debug.Log("Started Local Multiplayer Game");
        playerCam[0].gameObject.SetActive(true);
        playerCam[1].gameObject.SetActive(true);
        playerCam[0].rect = new Rect(-0.5f, 0f, 1f, 1f);
        playerCam[1].rect = new Rect(0.5f, 0f, 1f, 1f);

        players[1].GetComponent<PlayerController>().hasControl = true;
        players[0].GetComponent<PlayerController>().hasControl = true;

        players[0].GetComponent<PlayerController>().ControlType = 0;
        players[1].GetComponent<PlayerController>().ControlType = 1;
    }

    public void OnlineMultiPlayerStart() {
        Debug.Log("Started Online Multiplayer Game");
    }

    private void OnEnable() {
        controls.Enable();
    }

    private void OnDisable() {
        controls.Disable();
    }
}

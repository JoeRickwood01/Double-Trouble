using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour {
    public List<PlayerController> players;
    public List<CameraController> cameras;
    public int currentPlayer;
    public GameMode gameMode = GameMode.Singleplayer;

    public InputAction SwapCharacterControl;

    public static GameManager manager;

    private void OnEnable() {
        SwapCharacterControl.Enable();
    }

    private void OnDisable() {
        SwapCharacterControl.Disable();
    }

    //Sets The Static Instance Of The Script To This
    void Awake() {
        manager = this;
    }

    //Starts Game With The Correct Player Selected And Disables The Rest Of The Players If In Singleplayer Mode
    public void StartGame() {
        if(gameMode == GameMode.Singleplayer) {
            for (int i = 0; i < players.Count; i++) {
                if(i == currentPlayer) {
                    players[i].active = true;
                }else {
                    players[i].active = false;
                }
            }
        }
    }

    void Update() {
        switch (gameMode) {
            case GameMode.Singleplayer:
                SwapCharacterControl.performed += ctx => SwapCharacter();
                break;
            case GameMode.LocalMultiplayer:
                break;
        }
    }

    public void SwapCharacter() {
        currentPlayer++;
        if(currentPlayer > players.Count - 1) {
            currentPlayer = 0;
        }
        for (int i = 0; i < players.Count; i++) {
            if(i == currentPlayer) {
                players[i].active = true;
                cameras[0].target = players[i].gameObject.transform;
            }else {
                players[i].active = false;
            }
        }
    }
}

public enum GameMode {
    Singleplayer,
    LocalMultiplayer
}

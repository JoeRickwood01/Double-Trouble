using UnityEngine;

public class GameInitializer : MonoBehaviour {
    void Start() { //Runs On The First Frame, After Awake
        Transform currentRig = null;
        Camera currentCam = null; 
        PlayerController currentPlayer = null;
        switch (GameManager.manager.gameMode) { //Checks Which Gamemode The Manager Is Currently Set To
            case GameMode.Singleplayer: //If Game Is Singleplayer, Creates 2 Players And 1 Camera, Then Sets The Current Target For The Camera To The First Player
                currentRig = new GameObject("Camera Rig", typeof(CameraController)).transform;
                currentCam = new GameObject("Camera", typeof(Camera)).GetComponent<Camera>();
                GameManager.manager.cameras.Add(currentRig.gameObject.GetComponent<CameraController>());
                currentCam.gameObject.transform.SetParent(currentRig);
                currentCam.gameObject.transform.position = new Vector3(0f, 7.25f, -10.5f);
                currentCam.gameObject.transform.rotation = Quaternion.Euler(25f, 0f, 0f);
                for (int i = 0; i < 2; i++) {
                    currentPlayer = Instantiate(Resources.Load<GameObject>("Player"), new Vector3(0f + i * 2, 2, 0f), Quaternion.identity).GetComponent<PlayerController>();
                    if(i == 0) {
                        currentPlayer.active = true;
                        currentRig.GetComponent<CameraController>().target = currentPlayer.transform;
                    }else {
                        currentPlayer.active = false;
                    }
                    currentPlayer.camRig = currentRig;
                    GameManager.manager.players.Add(currentPlayer);
                }
                break;
            case GameMode.LocalMultiplayer: //If Game Is Local Multiplayer (One On Controller, One On KeyBoard), Creates 2 Players And 2 Cameras And Sets Camera Targets Accordingly
                for (int i = 0; i < 2; i++) {
                    currentPlayer = Instantiate(Resources.Load<GameObject>("Player"), new Vector3(0f + i * 2, 2, 0f), Quaternion.identity).GetComponent<PlayerController>();
                    currentPlayer.active = true;
                    if(i == 1) {
                        currentPlayer.usesController = true;
                    }
                    GameManager.manager.players.Add(currentPlayer);
                    currentRig = new GameObject("Camera Rig" + i, typeof(CameraController)).transform;
                    currentRig.GetComponent<CameraController>().target = currentPlayer.transform;
                    currentRig.transform.position = currentPlayer.gameObject.transform.position;
                    currentCam = new GameObject("Camera" + i, typeof(Camera)).GetComponent<Camera>();
                    GameManager.manager.cameras.Add(currentRig.gameObject.GetComponent<CameraController>());
                    if(i == 0) {
                        currentCam.rect = new Rect(0, 0f, 0.5f, 1f);
                    }else {
                        currentCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
                    }
                    currentCam.gameObject.transform.SetParent(currentRig);
                    currentCam.gameObject.transform.position = new Vector3(0f, 7.25f, -10.5f);
                    currentCam.gameObject.transform.rotation = Quaternion.Euler(25f, 0f, 0f);
                }
                break;
        }
        GameManager.manager.StartGame(); //Calls The StartGame Method On The Game Manager Once Finished

        Destroy(this.gameObject); //Destroys Object After Finished Running The Previous Code
    }
}

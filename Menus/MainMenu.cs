using System;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;

//Script Which Controls Button Presses On The Main Menu
public class MainMenu : MonoBehaviour {
    [Header("Camera")]
    [Tooltip("The Physical Camera In Scene")] [SerializeField]
    private Transform cam;
    [Tooltip("The String Of The Name Of The Current Screen")] [SerializeField]
    private string currentScreen = "Title Screen";
    [Tooltip("The Speed At Which The Camera Will Interpolate Positions")] [SerializeField]
    private float camMoveSpeed;
    [Tooltip("The Speed At Which The Camera Will Interpolate Rotations")] [SerializeField]
    private float camRotateSpeed;

    [Header("Settings")]
    public GameSettings settings;
    string path = "";
    string persistentPath = "";
    public AudioMixer mixer;

    /*  The camTitleScreenTransform is a transform which contains position rotation and scale, however ,
        I will only be using the Position And Rotation, This Variables Will be used to show different
        views for the camera on different screens */
    [Tooltip("The Transform Which Contains The Position And Rotation For The Camera")]
    public Transform camTitleScreenTransform;

    /*  The camOptionsScreenTransform does the same as the camTitleScreenTransform but used for the Position
        And Rotation of the camera in the options screen */
    [Tooltip("Position Of Camera In The Options Screen")]
    public Transform camOptionsScreenTransform;

    /* The camStartGameScreenTransform does the same as the camTitleScreenTransform but used for the Position
        And Rotation of the camera in the opitions screen */
    [Tooltip("Position Of Camera In The Start Game Screen")]
    public Transform camStartGameScreenTransform;

    //Called At The First Frame Of Initialization
    private void Start() {
        CreateSettings();
        SetPaths();
        if(File.Exists(path)) {
            SaveData(new GameSettings(settings.volume, settings.quality, settings.fullScreen, DateTime.Now.Month));
            settings = LoadData();
        }else {
            SaveData(settings);
            settings = LoadData();
        }
        SetSettings();
    }

    //Update Calls Every Frame Of The Game
    private void Update() {
        //If The Current Screen Is The Title Screen Then The Camera Position And Rotation Will Interpolate To The Positon And Rotation Of camTitleScreenTransform
        if(currentScreen == "Title Screen") {
            cam.position = Vector3.Lerp(cam.position, camTitleScreenTransform.position, Time.deltaTime * camMoveSpeed);
            cam.rotation = Quaternion.Lerp(cam.rotation, camTitleScreenTransform.rotation, Time.deltaTime * camRotateSpeed);
        }
        //If The Current Screen Is The Options Screen Then The Camera Position And Rotation Will Interpolate To The Positon And Rotation Of camOptionsScreenTransform
        if(currentScreen == "Options Screen") {
            cam.position = Vector3.Lerp(cam.position, camOptionsScreenTransform.position, Time.deltaTime * camMoveSpeed);
            cam.rotation = Quaternion.Lerp(cam.rotation, camOptionsScreenTransform.rotation, Time.deltaTime * camRotateSpeed);
        }
        //If The Current Screen Is The Options Screen Then The Camera Position And Rotation Will Interpolate To The Positon And Rotation Of camOptionsScreenTransform
        if(currentScreen == "Start Game Screen") {
            cam.position = Vector3.Lerp(cam.position, camStartGameScreenTransform.position, Time.deltaTime * camMoveSpeed);
            cam.rotation = Quaternion.Lerp(cam.rotation, camStartGameScreenTransform.rotation, Time.deltaTime * camRotateSpeed);
        }
    }

    //Buttons Externaly Will Call This Function When Changing Screens, This Will Change The String "currentScreen"
    public void SetScreen(string scr) {
        currentScreen = scr;
    }

    //Method Which Quits The Game On Call Of Method
    public void Quit() {
        Application.Quit();
    }

    //Sets The Save Paths (path and perisistantPath) to the paths inside of the application folders
    public void SetPaths() {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "UserSettings.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "UserSettings.json";
    }

    //Saves The Data Into A .Json File At The Path
    public void SaveData(GameSettings data) {
        SetPaths();
        string json = JsonUtility.ToJson(data);

        Debug.Log("Created : " + json);

        using StreamWriter writer = new StreamWriter(path);
        writer.Write(json);
    }

    //Loads Data From The path
    public GameSettings LoadData() {
        SetPaths();
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();

        Debug.Log("loaded : " + json);

        return JsonUtility.FromJson<GameSettings>(json);
    }

    //Creates Game Settings
    public void CreateSettings() { 
        settings = new GameSettings(-45.2f, 4, true, DateTime.Now.Month);
    }

    //Sets Settings And Applys them
    public void SetSettings() {
        QualitySettings.SetQualityLevel(settings.quality);
        mixer.SetFloat("MasterVolume", settings.volume);
        Screen.fullScreen = settings.fullScreen;
    }
}

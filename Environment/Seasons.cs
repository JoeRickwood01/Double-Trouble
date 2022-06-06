using System.IO;
using UnityEngine;

//this class handles seasonal changes to the game, other scripts will use the currentColorTint to change tree leaves and grass tint and color 
public class Seasons : MonoBehaviour {
    [Header("Settings")]
    GameSettings settings;
    string path = "";
    string persistentPath = "";
    string currentSeason;
    [Tooltip("The Gradient Is Sampled Based On Season")] [SerializeField]
    private Gradient seasonColorTint;
    [Tooltip("The Evaluated Color From The seasonColorTint Gradient")]
    public Color currentColorTint;

    //The Start Method Is Called On The First Frame
    private void Start() {
        LoadData();
        CheckSeason();
    }

    //Checks And Sets The Season Of The Game
    void CheckSeason() {
        currentColorTint = seasonColorTint.Evaluate(settings.month / 12f);
    }

    //Sets The Save Paths (path and perisistantPath) to the paths inside of the application folders
    public void SetPaths() {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "UserSettings.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "UserSettings.json";
    }

    //Loads Data From The path
    public GameSettings LoadData() {
        SetPaths();
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();

        return JsonUtility.FromJson<GameSettings>(json);
    }
}

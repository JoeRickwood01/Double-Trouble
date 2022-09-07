using UnityEngine;
using UnityEngine.SceneManagement; //Requires SceneMangement Module Referennce So We Can Use The Api To Swap Game Scenes

public class MenuManager : MonoBehaviour {
    //Change Current Game Scene To The Main Menu
    public void ChangeSceneToMenu() {
        SceneManager.LoadScene("Menu");
    }

    //Change Current Game Scene To The In Game Scene
    public void ChangeSceneToGame() {
        SceneManager.LoadScene("Game");
    }

    //Quits Application
    public void Quit() {
        Application.Quit();
    }
}

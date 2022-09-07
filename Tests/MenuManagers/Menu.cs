using UnityEngine;
using UnityEngine.SceneManagement; //Requires SceneMangement Module Referennce So We Can Use The Api To Swap Game Scenes

//Menu Class Contains Methods Which Change Scene From One To Another e.g. game to main menu
public class Menu : MonoBehaviour {
    //Changed Current Scene To Another Based On An Inputed string | sceneName |
    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    //Quits Application Safely By Calling The Application Method
    public void Quit() {
        Application.Quit();
    }
}

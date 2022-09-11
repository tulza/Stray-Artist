using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Achievement()
    {
        Debug.Log("Load Achievement Menu");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Menu"));
    }   

    public void LoadGame()
    {
        Debug.Log("Load Game");
        //Load Scene Game
        SceneManager.LoadScene("Game");
    }   

    public void QuitGame()
    {
        Debug.Log("Quitting Application");
        Application.Quit();
    }
}

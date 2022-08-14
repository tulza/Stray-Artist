using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        Debug.Log("Load Game");
        SceneManager.LoadScene("Game");
    }   

    public void QuitGame()
    {
        Debug.Log("Quitting Application");
        Application.Quit();
    }
}

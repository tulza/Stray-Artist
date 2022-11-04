using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    [SerializeField] GameObject ButtonUI;
    void Start() {
        ButtonUI.SetActive(true);
    }

    public void NewGame()
    {
        Debug.Log("Loading New Game");
        LoadSystem.NewGame();
    } 

    public void LoadGame()
    {
        Debug.Log("Continue Game");
        LoadSystem.ContinueGame();
    }   

    public void QuitGame()
    {
        Debug.Log("Quitting Application");
        Application.Quit();
    }
}

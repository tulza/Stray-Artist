using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void BackToGame()
    {
        FindObjectOfType<PlayerMenuControl>().Resume();
    }   

    public void Option()
    {

    }   

    public void SaveAndExit()
    {
        Time.timeScale = 1f;
        Debug.Log("Exitting");
        SceneManager.LoadScene("Main Menu");
    }
}

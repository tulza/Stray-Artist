using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    //Resume the game
    public void BackToGame()
    {
        FindObjectOfType<PlayerMenuControl>().Resume();
    }   

    //Exit to menu
    public void Exit()
    {
        Time.timeScale = 1f;
        Debug.Log("Exitting");
        SceneManager.LoadScene("Main Menu");
    }
}

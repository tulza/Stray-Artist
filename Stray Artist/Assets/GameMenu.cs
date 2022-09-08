using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void BackToGame()
    {

    }   

    public void Option()
    {

    }   

    public void SaveAndExit()
    {
        Debug.Log("Exitting");
        SceneManager.LoadScene("Main Menu");
    }
}

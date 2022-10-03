using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject AchievementUI;
    [SerializeField] GameObject ButtonUI;
    void Start() {
        AchievementUI.SetActive(false);
        ButtonUI.SetActive(true);
    }

    //These methods runs inside unity and does not require Start() or Update()
    public void Achievement()
    {
        Debug.Log("Load Achievement Menu");
       AchievementUI.SetActive(true);
       ButtonUI.SetActive(false);
    }
    public void UnLoadAchievement()
    {
        Debug.Log("UnLoading Achievement Menu");
       AchievementUI.SetActive(false);
       ButtonUI.SetActive(true);
    }      

    public void LoadGame()
    {
        Debug.Log("Load Game");
        //Load Scene Game
        SceneManager.LoadScene("Tutorial");
    }   

    public void QuitGame()
    {
        Debug.Log("Quitting Application");
        Application.Quit();
    }
}

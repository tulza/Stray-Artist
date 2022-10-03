using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuControl : MonoBehaviour
{
    public GameObject EscapeMenuUI;
    public static bool GameIsPause;

    //Start is called before the first frame update
    private void Start() {
        GameIsPause = false;
        EscapeMenuUI.SetActive(false);
    }
     

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //If game is already paused, resume game
            if(GameIsPause)
            {
                Debug.Log("Resuming");
                Resume();
            }
            //If game is not paused, pause game
            else
            {
                Debug.Log("Pausing");
                Pause();
            }
        }
    }

    void Pause()
    {
        //Open up the EscapeUI, stops time.
        EscapeMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    //For Resuming the game, public allows access to button press
    public void Resume()
    {
        //Close up the EscapeUI, resume time.
        EscapeMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }
}

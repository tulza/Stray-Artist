using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuControl : MonoBehaviour
{
    public GameObject EscapeMenuUI;
    public bool GameIsPause;

    //Start is called before the first frame update
    private void Start() {
        GameIsPause = false;
        EscapeMenuUI.SetActive(false);
    }
     

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(GameIsPause)
            {
                Debug.Log("Resuming");
                Resume();
            }
            else
            {
                Debug.Log("Pausing");
                Pause();
            }
        }
    }

    void Pause()
    {
        EscapeMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    void Resume()
    {
        EscapeMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }
}

using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCheckpoint : MonoBehaviour
{   
    string Default = @"";
    string FileName = @"Assets/Save/Save.txt";
    bool CanSave = false;
    bool IsFadeIn = false;
    public CanvasGroup UIFade;

    // Start is called before the first frame update
    void Start()
    {
        //alpha of UI starts at 0 meaning 0 opacity
        UIFade.alpha = 0;
        LoadSave();
    }

    void Update() 
    {
        //Boolean check every frame 
        if(IsFadeIn)
        {
            //if IsFadeIn == True, increase alpha(opacity) of UI
            UIFade.alpha += Time.deltaTime*8;
        }
        else
        {
            //if IsFadeIn == False, decrease alpha(opacity) of UI
            UIFade.alpha -= Time.deltaTime*8;
        }     
    }

    public void LoadSave()
    {
        // If there isn't a file create a file
        if (! File.Exists(FileName))
        {
            using (StreamWriter sw = File.CreateText(FileName))
            {
                sw.Close();
            }
            
        }


    }

    public void NewCheckpoint()
    {

    }

    //entering the trigger of checkpoint enables saving and UI 
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Checkpoint")
        {
            Debug.Log("Enter Checkpoint");
            CanSave = true;
            IsFadeIn = true;
        }
    }

    //exiting the trigger of checkpoint disables saving and UI
    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Checkpoint")
        {
            Debug.Log("Exit Checkpoint");
            CanSave = false;
            IsFadeIn = false;
        }
    }
}

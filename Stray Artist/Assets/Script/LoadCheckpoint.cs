using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCheckpoint : MonoBehaviour
{   
    string Default = @"";
    string textFile = @"Assets/Save/Save.txt";
    bool CanSave = false;
    bool IsFadeIn = false;

    //interaction indicator UI
    public CanvasGroup UIFade;

    // Start is called before the first frame update
    void Start()
    {
        //alpha of UI starts at 0 meaning 0 opacity
        UIFade.alpha = 0;
        LoadSave();
        Savetesting();
    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.E) && CanSave == true)
        {
            WriteSave();
        }

        UIFading();
           
    }

    public void LoadSave()
    {
        // If there isn't a file create a file
        if (! File.Exists(textFile))
        {
            using (StreamWriter sw = File.CreateText(textFile))
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

    void WriteSave()
    {

        string text = File.ReadAllText(textFile); 
    }

    void UIFading()
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

    void Savetesting()
    {
        //Find all game object with tag Checkpoint
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("Checkpoint");
            //Testing to see if it is able to log position
            //for future game saving mech
            foreach(GameObject oj in gameObjects)
            {
                Debug.Log($"{oj.name}\n{oj.transform.position}");
            }
    }
}

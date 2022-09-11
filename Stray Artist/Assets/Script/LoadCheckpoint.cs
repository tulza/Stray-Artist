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
    public GameObject IndicatorUI;
    public CanvasGroup UIFade;

    // Start is called before the first frame update
    void Start()
    {
        UIFade.alpha = 0;
        LoadSave();
    }

    void Update() 
    {
        if(IsFadeIn)
        {
            UIFade.alpha += Time.deltaTime*8;
        }
        else
        {
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

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Checkpoint")
        {
            Debug.Log("Enter Checkpoint");
            CanSave = true;
            IsFadeIn = true;
        }
    }

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

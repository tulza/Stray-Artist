using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCheckpoint : MonoBehaviour
{   
    [SerializeField] public GameObject Player;
    [SerializeField] public GameObject CpLocation;
    string textFile = @"Assets/Save/Save.txt";
    bool CanSave = false;
    bool IsFadeIn = false;

    //interaction indicator UI
    public CanvasGroup UIFade;

    // 
    void Awake()
    {
        //alpha of UI starts at 0 meaning 0 opacity
        UIFade.alpha = 0;
        LoadSave();
    }

    void Update() 
    {
        UIFading();

        if(Input.GetKeyDown(KeyCode.E) && CanSave == true)
        {
            Debug.Log($"saving at {CpLocation.name}");
            WriteSave();
        }
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

        string[] pos = File.ReadAllText(textFile).Split(',');
        float[] SaveAxis = new float[3]{0,-102,0};

        for(int i = 0; i < pos.Length-1 ; i++)
        {
            SaveAxis[i] = float.Parse(pos[i].Trim('(').Trim(')'));
            Debug.Log(SaveAxis[i]);
        }
        Player.transform.position = new Vector3(SaveAxis[0],SaveAxis[1],SaveAxis[2]);
       
    }



    void WriteSave()
    {
        using (StreamWriter sw = File.CreateText(textFile)) 
        {
            sw.WriteLine(CpLocation.transform.position);
        }
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

    //entering the trigger of checkpoint enables saving and UI 
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Checkpoint")
        {
            CanSave = true;
            IsFadeIn = true;

            //Set the trigger's gameobject as Checkpoint location when saving
            CpLocation = other.gameObject;
        }
    }

    //exiting the trigger of checkpoint disables saving and UI
    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Checkpoint")
        {
            CanSave = false;
            IsFadeIn = false;
        }
    }

}

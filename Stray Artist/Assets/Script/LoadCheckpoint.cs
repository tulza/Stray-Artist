using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCheckpoint : MonoBehaviour
{   
    
    [SerializeField] public GameObject Player;
    [SerializeField] public GameObject CpLocation;
    string LocationSavetxt = @"Assets/Save/LocationSave.txt";
    string PaintSavetxt = @"Assets/Save/PaintSave.txt";
    bool CanSave = false;
    bool IsFadeIn = false;

    //interaction indicator UI
    public CanvasGroup UIFade;


    void Awake()
    {
        //Load paint collected for this save
        PaintCollecting.PaintsCollected = new List<string>();

        //alpha of UI starts at 0 meaning 0 opacity
        UIFade.alpha = 0;
        LoadSave(); // load position
        UnloadPaint(); // unload collected paints
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

    void UnloadPaint()
    {
        string[] PaintCollected = File.ReadAllText(PaintSavetxt).Split(",");

        //Foreach paint that has been collected add into the list of paint
        foreach(string paint in PaintCollected)
        {
           PaintCollecting.PaintsCollected.Add(paint.Trim());
        }
    }

    public void LoadSave()
    {
        // If there isn't a file create a file
        if (! File.Exists(LocationSavetxt))
        {
            using (StreamWriter sw = File.CreateText(LocationSavetxt))
            {
                sw.Close();
            }
        }
        
        if (! File.Exists(PaintSavetxt))
        {
            using (StreamWriter sw = File.CreateText(PaintSavetxt))
            {
                sw.Close();
            }
        }
    
        //read content of save and split by line
        string ReadLctTxt = File.ReadAllText(LocationSavetxt);

        //Get saved player position
        string[] PlayerPosition = ReadLctTxt.Split(",");
        float[] SaveAxis = new float[3]{0,-102,0}; // default pos
        
        //convert string from to as float array
        for(int i = 0; i < PlayerPosition.Length-1 ; i++)
        {
            SaveAxis[i] = float.Parse(PlayerPosition[i].Trim('(').Trim(')'));
        }
        //load player to save location
        Player.transform.position = new Vector3(SaveAxis[0],SaveAxis[1],SaveAxis[2]);
       
       
       /*
        //Read Paint save
        string[] PaintCollected = File.ReadAllText(PaintSavetxt).Split(",");
        //Foreach paint that has been collected 
        foreach(string paint in PaintCollected )
        {
            if(string.IsNullOrWhiteSpace(paint) == false)
            {
                //Find the paint's game object and hides because it's already collected
                GameObject.Find(paint.Trim()).SetActive(false); 
            }
        }
        */
    }

    void WriteSave()
    {
        using (StreamWriter sw = File.CreateText(LocationSavetxt)) 
        {
            //Save Location
            sw.WriteLine(CpLocation.transform.position);
        }

        using (StreamWriter sw = File.CreateText(PaintSavetxt)) 
        {
            //Save collected Paint 
            sw.WriteLine(string.Join(",", PaintCollecting.PaintsCollected));
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

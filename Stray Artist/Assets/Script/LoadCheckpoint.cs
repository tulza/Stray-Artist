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
        LoadPaint();
    }

    void Update() 
    {
        UIFading();

        if(Input.GetKeyDown(KeyCode.E) && CanSave == true)
        {
            Debug.Log($"saving at {CpLocation.name}");
            foreach(string paint in PaintCollecting.PaintsCollected)
            {
                //testing to see if it would collect
                Debug.Log(paint);
            }
            WriteSave();
        }
    }

    void LoadPaint()
    {
        //Foreach paint that has been collected 
        foreach(string paint in PaintCollecting.PaintsCollected)
        {
            //Find the paint's game object and set it inactive because it's already collected
            GameObject.Find(paint).SetActive(false);
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
    
        //read content of save and split by line
        string[] ReadFile = File.ReadAllText(textFile).Split(Environment.NewLine);

        db($">{ReadFile[0]}\n>{ReadFile[1]}");
        //Get saved player position
        string[] PlayerPosition = ReadFile[0].Split(",");
        float[] SaveAxis = new float[3]{0,-102,0};
        
        //find array size
        for(int i = 0; i < PlayerPosition.Length-1 ; i++)
        {
            //Convert into float and trim the bracket
            SaveAxis[i] = float.Parse(PlayerPosition[i].Trim('(').Trim(')'));
        }
        Player.transform.position = new Vector3(SaveAxis[0],SaveAxis[1],SaveAxis[2]);
       
       
       string[] PaintCollected = ReadFile[1].Split(",");
       
        //Foreach paint that has been collected 
        foreach(string paint in PaintCollected )
        {
            if(String.IsNullOrWhiteSpace(paint) == true)
            {
                //Find the paint's game object and hides because it's already collected
                GameObject.Find(paint.Trim()).SetActive(false); 
            }
        }
    }

    void WriteSave()
    {
        using (StreamWriter sw = File.CreateText(textFile)) 
        {
            sw.WriteLine(CpLocation.transform.position);
            sw.WriteLine(string.Join(", ", PaintCollecting.PaintsCollected.ToArray()));
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


    void db(string a)
    {
        Debug.Log($"==================\n{a}\n==================");
    }
}

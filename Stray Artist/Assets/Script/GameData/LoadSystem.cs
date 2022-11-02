using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSystem : MonoBehaviour
{
    
    static string ObjectTofind = "Player";
    static string SaveTextLocation = @"Stray Artist_Data/LocationSave.txt";
    static string scene;
    static Vector3 position;
    static Vector3 defaultPosition = new Vector3(-173.07f,-93.25f,0);
    [SerializeField] static public GameObject Player;

    //Load game from save file
    public static void ContinueGame(){
        FindObjectOfType<PlayerLoader>().LoadPlayer();
        LoadSave();
    }

    //Start new game
    public static void NewGame(){
        ClearSave();

        PaintManager.CollectedPaint = new List<string>{};
        PaintManager.SelectedStage = 0;

        FindObjectOfType<PlayerLoader>().LoadPlayer();
        Player = GameObject.Find(ObjectTofind);
        Player.transform.position = defaultPosition;
        SceneManager.LoadScene("Tutorial");
    }
    
    //Load game
    static void LoadSave(){
    //read textfile
    string ReadTextFileContent = File.ReadAllText(SaveTextLocation);
    Debug.Log(ReadTextFileContent);

        // If the save is not empty, load game
        if(string.IsNullOrEmpty(ReadTextFileContent)!= true)
        {
            string[] format = ReadTextFileContent.Split("/");
            scene = format[0];

            //Get Vector3 position
            string[] Vector3Array =  format[1].Split(",");
            position.x = float.Parse(Vector3Array[0]);
            position.y = float.Parse(Vector3Array[1]);
            position.z = float.Parse(Vector3Array[2]);

            //Maybe do like list contain true and destroy
            if(string.IsNullOrEmpty(format[2])!= true)
            {
                PaintManager.CollectedPaint.Clear();
                string[] paints = format[2].Split(",");
                foreach(string paint in paints){
                    Debug.Log(paint);
                    //add all collected paint in the save to the collected paint list save script
                    PaintManager.CollectedPaint.Add(paint);
                }
            }
            
            //Find player and load player to the correct position
            Player = GameObject.Find(ObjectTofind);
            Player.transform.position = position;
            Debug.Log(position);

            //load scene
            SceneManager.LoadScene(scene);
        }

        //If no save start a new save.
        else{
            NewGame();
        }
    }
    
    //clear text file for new game
    static void ClearSave(){
        File.WriteAllText(SaveTextLocation,"");
    }
}

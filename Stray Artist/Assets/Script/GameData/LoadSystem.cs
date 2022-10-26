using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSystem : MonoBehaviour
{
    
    static string ObjectTofind = "Player";
    static string SaveTextLocation = @"Assets/Save/LocationSave.txt";
    static string scene;
    static Vector3 position;
    static Vector3 defaultPosition = new Vector3(-173.07f,-93.25f,0);
    [SerializeField] static public GameObject Player;

    public static void ContinueGame(){
        FindObjectOfType<PlayerLoader>().LoadPlayer();
        LoadSave();
    }

    public static void NewGame(){
        ClearSave();

        FindObjectOfType<PlayerLoader>().LoadPlayer();
        Player = GameObject.Find(ObjectTofind);
        Player.transform.position = defaultPosition;
        SceneManager.LoadScene("Tutorial");
    }

    static void LoadSave(){
    string ReadTextFileContent = File.ReadAllText(SaveTextLocation);
    Debug.Log(ReadTextFileContent);

        if(string.IsNullOrEmpty(ReadTextFileContent)!= true)
        {
            string[] format = ReadTextFileContent.Split("/");
            scene = format[0];

            string[] Vector3Array =  format[1].Split(",");
            position.x = float.Parse(Vector3Array[0]);
            position.y = float.Parse(Vector3Array[1]);
            position.z = float.Parse(Vector3Array[2]);
            
            Player = GameObject.Find(ObjectTofind);
            Player.transform.position = position;
            Debug.Log(position);

            SceneManager.LoadScene(scene);
        }

        else{
            NewGame();
        }
    }
    
    //clear text file for new game
    static void ClearSave(){
        File.WriteAllText(SaveTextLocation,"");
    }
}

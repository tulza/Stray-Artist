using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    Transform t_;
    string SaveTextLocation = @"Assets/Save/LocationSave.txt";
    string stage;
    float[] position = new float[3];

    public static bool CanSave = false;

    void Awake()
    {
        t_ = GetComponent<Transform>();
        //Get Checkpoint data and check if savefile exist
        CreateSaveFile();
        GetCheckPointData();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E) && CanSave == true && SaveIndicatorFade.isFading != true) 
        {
            Debug.Log("Saving Data");
            SaveIndicatorFade.isFading = true;
            WriteSave();
        }
    }

    void GetCheckPointData(){
    position[0] = t_.position.x; 
    position[1] = t_.position.y;
    position[2] = t_.position.z;
    stage = gameObject.scene.name;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            CanSave = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            CanSave = false;
        }
    }

    void WriteSave(){
        using (StreamWriter sw = File.CreateText(SaveTextLocation)) 
        {
            //Write Scene, location, and all collected paint into the file
            sw.Write($"{stage}/{string.Join(",", position)}");
            Debug.Log("Saving");
        }
    }

    //clear text file for new game
    void ClearSave(){
        File.WriteAllText(SaveTextLocation,"");
    }

    void CreateSaveFile(){
        if (! File.Exists(SaveTextLocation))
        {
            using (StreamWriter sw = File.CreateText(SaveTextLocation))
            {
                sw.Close();
            }
        }
    }
}

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    Transform t_; // Checkpoint transform
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
        //Save when player press E and is not already saving
        if(Input.GetKeyDown(KeyCode.E) && CanSave == true && SaveIndicatorFade.isFading != true) 
        {
            Debug.Log("Saving Data");
            SaveIndicatorFade.isFading = true;
            WriteSave();
        }
    }

    //Get checkpoint's axis
    void GetCheckPointData(){
    position[0] = t_.position.x; 
    position[1] = t_.position.y;
    position[2] = t_.position.z;
    stage = gameObject.scene.name; //Get stage name
    }

    //Allow saving if player is in range
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            CanSave = true;
        }
    }

    //Disable saving if player is not in range
    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            CanSave = false;
        }
    }

    //Write game data into the game save
    void WriteSave(){
        using (StreamWriter sw = File.CreateText(SaveTextLocation)) 
        {
            //Write Scene, location, and all collected paint into the file
            sw.Write($"{stage}/{string.Join(",", position)}/{string.Join(",", PaintManager.CollectedPaint)}");
            Debug.Log("Saving");
        }
    }

    //clear text file for new game
    void ClearSave(){
        File.WriteAllText(SaveTextLocation,"");
    }
    
    //Create a new text file if the text file does not already exist
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{   
    //Gameobjects
    public SpriteRenderer Portal;
    public GameObject Pointer;
    public StageColor[] Stages;
    

    public static string CurrentScene;
    int StageCount;
    //Stage count starts at 1;
    public static int SelectedStage = 0;
    public static Vector3 CurrentLoadToPosition;


    void Start() {  
        //Start stage count from 0
        SelectedStage = 0;
        //count from 1 so to array is -1
        StageCount = Stages.Length-1;
        Debug.Log(StageCount);
        Portal.color = Stages[0].newColor;
        CurrentScene = Stages[SelectedStage].SceneToLoad;
        CurrentLoadToPosition = Stages[SelectedStage].LoadToPosition;

    }

    public void ChangeStageLeft(){
        //If index is not equal to 0 allow changes to stage to the left
        if(SelectedStage != 0)
        {
            SelectedStage--;
            Pointer.transform.Translate(new Vector3(-4f,0,0));
            ChangePortal();
        }
    }

    //If index is not equal to n number of total stage allow changes to stage to the right
    public void ChangeStageRight(){
        if(SelectedStage != StageCount)
        {
            SelectedStage++;
            Pointer.transform.Translate(new Vector3(4f,0,0));
            ChangePortal();
        }
    }

    //Change the portal color, and scene destination 
    void ChangePortal(){
        //change portal
        Portal.color = Stages[SelectedStage].newColor;
        CurrentScene = Stages[SelectedStage].SceneToLoad;
        CurrentLoadToPosition = Stages[SelectedStage].LoadToPosition;
            Debug.Log(CurrentScene);
    }
}

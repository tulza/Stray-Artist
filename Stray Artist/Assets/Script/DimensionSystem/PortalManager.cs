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
    public static int StageIndexCount;
    //Stage count starts at 1;
    public static int SelectedStage = 0;
    public static Vector3 CurrentLoadToPosition;


    void Awake() {  
        //Get stage selected from paint manager 
        SelectedStage = PaintManager.SelectedStage;
        Pointer.transform.Translate(new Vector3(4f*PaintManager.SelectedStage,0,0));
        //count from 1 so to array is -1
        StageIndexCount = Stages.Length-1;
        Portal.color = Stages[SelectedStage].newColor;
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
        if(SelectedStage != StageIndexCount)
        {
            SelectedStage++;
            Pointer.transform.Translate(new Vector3(4f,0,0));
            ChangePortal();
        }
    }

    //Change the portal color, and scene destination 
    void ChangePortal(){
        //Save current selected stage
        PaintManager.SelectedStage = SelectedStage;
        //change portal
        Portal.color = Stages[SelectedStage].newColor;
        CurrentScene = Stages[SelectedStage].SceneToLoad;
        CurrentLoadToPosition = Stages[SelectedStage].LoadToPosition;
            Debug.Log(CurrentScene);
    }
}

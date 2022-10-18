using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public SpriteRenderer Portal;
    public GameObject Pointer;
    public StageColor[] Stages;

    public static Color CurrentColor;
    public static string CurrentScene;
    int StageCount;
    //Stage count starts at 1;
    public static int SelectedStage = 0;


    void Start() {  
        //count from 1 so to array is -1
        StageCount = Stages.Length-1;
        Debug.Log(StageCount);
        Portal.color = Stages[0].newColor;
        CurrentColor = Stages[SelectedStage].newColor;
        CurrentScene = Stages[SelectedStage].SceneToLoad;
    }

    public void ChangeStageLeft(){
        if(SelectedStage != 0)
        {
            SelectedStage--;
            Pointer.transform.Translate(new Vector3(-4f,0,0));
            ChangePortal();
        }
    }

    public void ChangeStageRight(){
        if(SelectedStage != StageCount)
        {
            SelectedStage++;
            Pointer.transform.Translate(new Vector3(4f,0,0));
            ChangePortal();
        }
    }

    void ChangePortal(){
        Portal.color = Stages[SelectedStage].newColor;
        CurrentColor = Stages[SelectedStage].newColor;
        CurrentScene = Stages[SelectedStage].SceneToLoad;
            Debug.Log(CurrentScene);
    }
}

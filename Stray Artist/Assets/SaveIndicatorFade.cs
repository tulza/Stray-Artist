using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveIndicatorFade : MonoBehaviour
{
    public CanvasGroup AllowSaveIndicator;
    public CanvasGroup SaveIndicator;
    public TextMeshProUGUI SavingTxt;

    public static bool isFading;
    float SaveTimer = 0;

    void Start() {
        //Set Canvas opacity to 0
        AllowSaveIndicator.alpha = 0;
        SaveIndicator.alpha = 0;
    }

    void Update() {
        AllowSaving();   
        FadePanelSaveIndicator();
    }

    void AllowSaving(){
        if(SaveSystem.CanSave == true){
            AllowSaveIndicator.alpha += 6 * Time.deltaTime;
        }
        else{
            AllowSaveIndicator.alpha -= 6 * Time.deltaTime;
        }  
    }

    void FadePanelSaveIndicator(){
        
        if(isFading == true)
        {
            SaveIndicator.alpha += 5 * Time.deltaTime;
            SaveTimer += 1 * Time.deltaTime;

            if(SaveTimer>=1.6f)
            {
                isFading = false;
                SaveTimer = 0;
            }
            else if (SaveTimer>=1.2f){
                SavingTxt.text = "Saving...";
            }
            else if (SaveTimer>=0.8f){
                SavingTxt.text = "Saving..";
            }
            else if (SaveTimer>=0.4f){
                SavingTxt.text = "Saving.";
            }
            else{
                SavingTxt.text = "Saving";
            }
        }
        else{
            SaveTimer = 0f;
            SaveIndicator.alpha -= 5 * Time.deltaTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterMapUI : MonoBehaviour
{
    //Public to allow instance in editor
    public TextMeshProUGUI  EnteringUI;
    CanvasGroup TextCG;
    public string EnteringText;
    bool peaked = false;
    float time;
    
    void Start() {
        //change text
        EnteringUI.text = EnteringText;
        //Get canvas group
        TextCG = EnteringUI.GetComponent<CanvasGroup>();
        time = 0;
        TextCG.alpha = 0;
    }

    void Update() {
        //fade in the UI
        if (peaked == false){
            time += Time.deltaTime;

            //Fade in after 0.5 second of entering the stage
            if(time >= 0.5f){
                //Length of fade in from 0 to 1 is 1.33 second (1/0.75)
                TextCG.alpha += 0.75f * Time.deltaTime;

                    //After 5 second allow the UI to fade out
                    if (time >= 5f)
                    {
                        peaked = true;
                    }
                }
        }
        else
        {
            TextCG.alpha -= 1.5f * Time.deltaTime;
        }

    }
}

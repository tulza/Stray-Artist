using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayControl : MonoBehaviour
{
    bool IsDisplayingControl;
    public CanvasGroup ControlManualCG;
    float MaxAlpha;

    void Start() {
        //Get Max alpha of the manual which is the starting alpha
        IsDisplayingControl = false;
        MaxAlpha = ControlManualCG.alpha;
        ControlManualCG.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Get input for K to show control manual
        if(Input.GetKey(KeyCode.K)){
            IsDisplayingControl = true;
        }
        else{
            IsDisplayingControl = false;
        }
        DisplayControlFade();
    }

    //Control fade of the control manual
    void DisplayControlFade(){
        if(IsDisplayingControl == true && ControlManualCG.alpha <= MaxAlpha ){
            ControlManualCG.alpha += 1 * Time.deltaTime;
        }
        else if(IsDisplayingControl == false){
            ControlManualCG.alpha -= 2 * Time.deltaTime;
        }
    }
}

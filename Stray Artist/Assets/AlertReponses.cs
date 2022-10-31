using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlertReponses : MonoBehaviour
{
    public GameObject AlertDisplay;
    TextMeshPro AlertDisplayTMPro;
    static int MaxPaintCount;
    static int CurrentPaintCount;

    private void Start() {
        AlertDisplayTMPro = AlertDisplay.GetComponent<TextMeshPro>();
        Calculate();
    }

    public void Calculate(){
        MaxPaintCount = PortalManager.StageIndexCount + 1;
        CurrentPaintCount = PaintManager.CollectedPaint.Count;

        if(MaxPaintCount == CurrentPaintCount){
            AlertDisplayTMPro.text = "Max Paint, Thank you!";
        }
        else if((int)(MaxPaintCount/2) <= CurrentPaintCount){
            AlertDisplayTMPro.text = $"moderate amount of paint!";
        }
        else if(CurrentPaintCount != 0){
            AlertDisplayTMPro.text = $"Very Low paint!";
        }
        else{
            AlertDisplayTMPro.text = "No paint available!";
        }
    }
}

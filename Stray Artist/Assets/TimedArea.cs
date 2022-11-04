using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedArea : MonoBehaviour
{
    public CanvasGroup Timer;
    bool IsInTimerArea = false;

    private void Start() {
        //timer invisible at start
        Timer.alpha = 0;
    }

    private void Update() {
    //show timer UI by changing alpha, (on/off) depending on IsInTimerArea
        if(IsInTimerArea){
            Timer.alpha += 2 * Time.deltaTime;
        }
        else if(IsInTimerArea == false){
            Timer.alpha -= 2 * Time.deltaTime;
        }
    }

    //enable timer UI
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
        IsInTimerArea = true;
        }
    }

    //disable timer UI
    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
        IsInTimerArea = false;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeChallenge : MonoBehaviour
{

    public TextMeshProUGUI TimeToDisplay;
    public GameObject ChallengeObjective;
    public float initialTimer;
    float PityTimer;
    float CurrentTime;

    bool IsInChallenge;
    bool CanPlay;

    // Start is called before the first frame update
    void Start()
    {
        TimeToDisplay.text = "---";
        PityTimer = initialTimer;
        IsInChallenge = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && IsInChallenge == false)
        {   
            IsInChallenge = true;
            ChallengeObjective.SetActive(false);
            CurrentTime = PityTimer;
        }
        
        TimeDisplay();
    }


    void TimeDisplay(){
        if(IsInChallenge == true)
        {
            CurrentTime -= 1 * Time.deltaTime;
            TimeToDisplay.text  = Convert.ToString((int)CurrentTime);
            if(CurrentTime <= 0)
            {
                LostChallenge();
            }
        }
    }

    void LostChallenge(){
        //reset Challenge
        TimeToDisplay.text = "---";
        ChallengeObjective.SetActive(true);
        IsInChallenge = false;
        //Add time by 1;
        PityTimer += 1;
    }

    //Can start Challenge
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
        CanPlay = true;
        }
    }

    //Cannot start Challenge
    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
        CanPlay = false;
        }
    }
}

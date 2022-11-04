using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeChallenge : MonoBehaviour
{
    //UI
    public GameObject ChallengeUIPrefab;
    public CanvasGroup InstantiatedChallengeUICG;
    //Timer
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
        //Instance UI and set alpha to 0
        InstantiatedChallengeUICG = GameObject.Instantiate(ChallengeUIPrefab).transform.GetChild(0).GetChild(0).GetComponent<CanvasGroup>();
        InstantiatedChallengeUICG.alpha = 0;
        //Initial value of timer
        TimeToDisplay.text = "---";
        PityTimer = initialTimer;
        IsInChallenge = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If keydown, start the challenge
        if(Input.GetKeyDown(KeyCode.E) && IsInChallenge == false && CanPlay == true)
        {   
            //ChallengeObjective(door) is disable to allow the player through during challenge
            IsInChallenge = true;
            ChallengeObjective.SetActive(false);
            CurrentTime = PityTimer;
        }
        
        //update timer
        TimeDisplay();
        //update UI
        StartIndicator();

    }

    void StartIndicator(){
        //Fade in UI if not in challenge and can play
        if(IsInChallenge == false && CanPlay){
            InstantiatedChallengeUICG.alpha += 2 * Time.deltaTime;
        }
        //fade out UI
        else if(CanPlay == false){
                InstantiatedChallengeUICG.alpha -= 2 * Time.deltaTime;
        }
    }

    void TimeDisplay(){
        if(IsInChallenge == true)
        {
            //make time go down by 1 per second
            CurrentTime -= 1 * Time.deltaTime;

            //Get timer in increment of integer 
            TimeToDisplay.text  = Convert.ToString((int)CurrentTime);
            //If timer ran out lose challenge 
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
        //Add time by 1 to make it easier for the player next time
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

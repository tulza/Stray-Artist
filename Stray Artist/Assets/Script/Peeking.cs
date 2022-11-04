using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Peeking : MonoBehaviour
{

    //Player and object to follow
    public Transform ObjectToFollow;
    CinemachineVirtualCamera Vcam;
    GameObject Player;

    //UI
    public GameObject PeakUIPrefab;
    public CanvasGroup InstantiatedPeakUICG;
    //Conditions
    bool IsPeeking = false;
    bool CanPeak = false;
    //camera management
    public float camSize;
    float playerCam;
    // Start is called before the first frame update
    void Awake()
    {
        //Get gameobject of vcam and player
        Vcam = GameObject.FindWithTag("Vcam").GetComponent<CinemachineVirtualCamera>();
        Player = GameObject.FindWithTag("Player");
        
        //Instance UI and set alpha to 0
        InstantiatedPeakUICG = GameObject.Instantiate(PeakUIPrefab).transform.GetChild(0).GetChild(0).GetComponent<CanvasGroup>();
        InstantiatedPeakUICG.alpha = 0;
        //Get player's camera size
        playerCam = Vcam.m_Lens.OrthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        //
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(IsPeeking == false && CanPeak){
                //Get player cam size then set to it to the map viewing size
                playerCam = Vcam.m_Lens.OrthographicSize;
                Vcam.m_Lens.OrthographicSize = camSize;

                //Follow place to peak instead of player
                IsPeeking = true;
                Vcam.Follow = ObjectToFollow;
            }
        else if(CanPeak){
                //Reset back to player cam size and make camera follow the player
                IsPeeking = false;
                Vcam.m_Lens.OrthographicSize = playerCam;
                Vcam.Follow = Player.transform;
            }
        }
        DisplayUI();
    }

    void DisplayUI(){
        //Fade in UI if can peak
        if(CanPeak){
            InstantiatedPeakUICG.alpha += 2 * Time.deltaTime;
            //disable UI when peaking
            if(IsPeeking){
                InstantiatedPeakUICG.alpha = 0;
            }
        }
        //Fade out UI if can't peak
        else if(CanPeak == false){
            InstantiatedPeakUICG.alpha -= 2 * Time.deltaTime;
        }

        
    }

    //find is can peak if player in the trigger
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            CanPeak = true;
        }

    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player")
        {   
            //disable can peak
            CanPeak = false;
            //if player is not following player reset the camera
            if(Vcam.Follow != Player.transform){
            Vcam.m_Lens.OrthographicSize = playerCam;
            Vcam.Follow = Player.transform;
            }
        }
    }
    
}

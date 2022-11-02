using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EndGamePainting : MonoBehaviour
{
    public CanvasGroup EndIndicator;
    public GameObject Credits;
    public GameObject EnderGameObject;
    public GameObject invsWall;
    public CanvasGroup ThankYou;
    GameObject Player;
    CanvasGroup CreditsCg;
    CinemachineVirtualCamera Vcam;

    bool CanEnd = false;
    bool isEnding = false;
    bool PlayingCredits = false;

    float timer;

    void End(){
        invsWall.SetActive(true);
        PlayerMenuControl.CanPause = false;
        Destroy(EnderGameObject.GetComponent<BoxCollider2D>());
        Vcam.Follow = EnderGameObject.transform;
        EndIndicator.alpha = 0;
        isEnding = true;    
    }

    // Start is called before the first frame update
    void Start()
    {
        invsWall.SetActive(false);
        CreditsCg = Credits.GetComponent<CanvasGroup>();
        Player = GameObject.FindWithTag("Player");
        Vcam = GameObject.FindWithTag("Vcam").GetComponent<CinemachineVirtualCamera>();
        EndIndicator.alpha = 0;
        CreditsCg.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {   if(isEnding == false){
            if(Input.GetKeyDown(KeyCode.E) && CanEnd == true) 
            {
                End();
            }
            AllowEndCheck();
        }
        else{
            timer += 1 * Time.deltaTime;
            EnderGameObject.transform.Translate(new Vector3(-3 * Time.deltaTime,3 * Time.deltaTime,0));

            if(timer >= 5f && PlayingCredits == false){
                Debug.Log("credits");
                PlayingCredits = true;
                
            }

            if(PlayingCredits && timer <= 52f){
                CreditsCg.alpha += 0.2f * Time.deltaTime;
                Credits.transform.Translate(new Vector3(0,100 * Time.deltaTime,0));
            }
            else if(timer >= 53f){
                ThankYou.alpha -= 0.2f * Time.deltaTime;

                if(timer >= 59f){
                    Destroy(Player);
                    PlayerMenuControl.CanPause = true;
                    FindObjectOfType<GameMenu>().Exit();
                }
            }
        }
    }

    void AllowEndCheck(){
        if(CanEnd == true){
            EndIndicator.alpha += 5 * Time.deltaTime;
        }
        else{
            EndIndicator.alpha -= 5 * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        CanEnd = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        CanEnd = false;
    }
}

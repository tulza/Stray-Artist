using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionWall : MonoBehaviour
{
    //Get instance of necessary objects
    public Vector3 LoadToPosition;
    public string sceneToLoad;
    public GameObject FadeSceneChangePrefab;
    public CanvasGroup InstantiatedFadeScreen;
    GameObject Player;
    
    bool IsChanging = false;

    //Get canvasgroup of the Instantiated gameobject
    void Awake() {
        InstantiatedFadeScreen = Instantiate(FadeSceneChangePrefab).GetComponent<CanvasGroup>();
        InstantiatedFadeScreen.alpha = 0;
    }

    void Update() {
        //If in trigger, change the scene to the area of (sceneToLoad)
        if(IsChanging == true)
        {
            //fade in rate
            InstantiatedFadeScreen.alpha += Time.deltaTime*5;
        }
        //Only if scene has fully faded
        if(InstantiatedFadeScreen.alpha >= 1)
        {
            RelocatePlayer.repositionPlayer(LoadToPosition);
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    //Find if player enter the trigger 
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            IsChanging = true;
        }
    }
    

}

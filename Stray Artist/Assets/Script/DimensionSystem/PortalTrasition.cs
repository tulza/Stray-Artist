using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTrasition : MonoBehaviour
{
    
    public GameObject FadeSceneChangePrefab;
    CanvasGroup InstantiatedFadeScreen;
    SpriteRenderer InstantiatedFadeColor;
    bool IsChanging = false;

    //Get canvasgroup of the Instantiated gameobject
    void Start() {
        InstantiatedFadeScreen = Instantiate(FadeSceneChangePrefab).GetComponent<CanvasGroup>();
        InstantiatedFadeScreen.alpha = 0;
    }

     void Update() {
        
        //If in trigger, change the scene to the area of (sceneToLoad)
        if(IsChanging == true)
        {
            InstantiatedFadeScreen.alpha += Time.deltaTime*3;
        }
        //Only if scene has fully faded
        if(InstantiatedFadeScreen.alpha >= 1)
        {
            RelocatePlayer.repositionPlayer(PortalManager.CurrentLoadToPosition);
           SceneManager.LoadScene(PortalManager.CurrentScene);
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

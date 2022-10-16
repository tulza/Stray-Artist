using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionWall : MonoBehaviour
{
    public GameObject FadeSceneChangePrefab;
    public CanvasGroup InstantiatedFadeScreen;
    public Object sceneToLoad;
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
            InstantiatedFadeScreen.alpha += Time.deltaTime*5;
        }
        //Only if scene has fully faded
        if(InstantiatedFadeScreen.alpha >= 1)
        {
            SceneManager.LoadScene(sceneToLoad.name);
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

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

    void Start() {
        InstantiatedFadeScreen = Instantiate(FadeSceneChangePrefab).GetComponent<CanvasGroup>();
        InstantiatedFadeScreen.alpha = 0;
    }

    void Update() {
        
        if(IsChanging == true)
        {
            InstantiatedFadeScreen.alpha += Time.deltaTime*5;
        }

        if(InstantiatedFadeScreen.alpha >= 1)
        {
            SceneManager.LoadScene(sceneToLoad.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            IsChanging = true;
        }
    }
    

}

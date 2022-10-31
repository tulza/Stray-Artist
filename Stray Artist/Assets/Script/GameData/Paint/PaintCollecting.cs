using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCollecting : MonoBehaviour
{   
    public GameObject CompleteStagePrefab;
    public GameObject AlreadyCompletedStagePrefab;

    private void Start() {
        if(CollectedPaintChecker.CollectedPaint.Contains(gameObject.name)){
        AlreadyCompleteStage();
        Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D Paint) {

        //only active to game object with tag paint 
        if(Paint.gameObject.tag == "Player")
        {
            CompleteStage();
            CollectedPaintChecker.CollectedPaint.Add(gameObject.name);
            Destroy(gameObject);
        }
    }

    //instance a "stage completed" prefab
    void CompleteStage()
    {
        Instantiate(CompleteStagePrefab, new Vector3(0,0,0), Quaternion.identity);
    }
    
    //instance a "stage has already completed" prefab
    void AlreadyCompleteStage()
    {
        Instantiate(AlreadyCompletedStagePrefab, new Vector3(0,0,0), Quaternion.identity);
    }
}

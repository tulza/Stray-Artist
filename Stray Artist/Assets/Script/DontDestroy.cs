using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private GameObject[] playerInstance;
        
    void Awake(){

        DontDestroyOnLoad (this); 
        playerInstance = GameObject.FindGameObjectsWithTag("Player");
    
        if(playerInstance.Length >=2)
        {
            Destroy(gameObject);
        }
    }
}

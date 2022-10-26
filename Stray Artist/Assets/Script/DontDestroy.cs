using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private GameObject[] playerInstance;
        
    //Make the object with this script type of DontDestroyOnLoad or
    //make player the type of DontDestroyOnLoad and destory copy of it.
    void Awake(){
        DontDestroyOnLoad (this); 
        playerInstance = GameObject.FindGameObjectsWithTag("Player");

        if(playerInstance.Length >=2)
        {
            Destroy(gameObject);
        }
    }
}

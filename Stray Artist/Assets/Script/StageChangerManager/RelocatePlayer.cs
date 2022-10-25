using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelocatePlayer : MonoBehaviour
{
     public static GameObject Player;
     public static GameObject cam;

    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.Find("Player");
        cam = GameObject.Find("Main Camera");

    }
   
    public static void repositionPlayer(Vector3 LoadToPosition){
    Player.transform.position = LoadToPosition;
    cam.transform.position = LoadToPosition;
    }
}

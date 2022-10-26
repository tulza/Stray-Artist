using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class RelocatePlayer : MonoBehaviour
{
     public static GameObject Player;
     public static CinemachineVirtualCamera cam;

    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.Find("Player");
        cam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();

    }
   
   //Reposition player to the position to load to
    public static void repositionPlayer(Vector3 LoadToPosition){
    Player.transform.position = LoadToPosition;
    cam.ForceCameraPosition(new Vector3(LoadToPosition.x,LoadToPosition.y+10,LoadToPosition.z), Quaternion.identity);
    }
}
